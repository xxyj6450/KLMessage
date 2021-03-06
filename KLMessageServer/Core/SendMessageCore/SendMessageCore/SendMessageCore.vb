﻿Imports System
Imports System.Xml
Imports System.Threading
Imports System.Runtime.Remoting.Messaging
Imports System.Collections
Imports System.Data
Imports log4net
Imports log4net.Config

Public Class SendMessageCore
    '私有字段定义
 
    Private _TotalCount As Long, _SendCount As Long, _SuccessedCount As Long, _SessionMessageCount As Long, _SessionSendCount As Long
    Dim _Wait As New System.Threading.AutoResetEvent(False)
     
    Private _StartTime As Long
    Private _ThreadCount As Long
    Private _ThreadIndex As Long
 
    '存储关键字
    Private Shared dt_Keywords As System.Data.DataSet
    Private Shared Users As System.Collections.Generic.Dictionary(Of String, UserInfo)

    '错误码定义
    Public Enum enumKLErrors As Long
        SEND_MESSAGE_SUCCESSED = 0
        NO_CONTENT_ERROR = -10000                            '没有短信内容
        NO_RECIPIENTS_ERROR = -10001                         '没有正确的联系人
        KEYWORDS_ERROR = -10002                              '敏感字检查失败
        ADD_NEW_MESSAGE_ERROR = -10003                       '申请消息资源失败
        ERROR_SERIALNUMBER = -10004                          '号码错误
        ADD_NEW_MESSAGE_SKIPED = -10005                      '跳过消息资源申请
        LACK_OF_ACCOUNTS = -10006                              '账号资源不足
        SEND_MESSAGE_ERROR = -10007
        GET_MESSAGEID_ERROR = -10008
        GET_CONNECTION_ERROR = -10009
        USER_LOGIN_ERROR = -10010
        OTHER_ERROR = -10099
    End Enum

    '发送状态,用于表示短信发送期间的各个状态
    Public Enum enumSendEvent As Long
        StartSendEvent = 0
        BeginGetMessageIDEvent = 1
        EndGetMessageIDEvent = 2
        BeginGetConnectionIDEvent = 3
        EndGetConnectionIDEvent = 4
        BeginSendMessageEvent = 5
        EndSendMessageEvent = 6
        BeginReportMessageEvent = 7
        EndReportMessageEvent = 8
        FinishedSendMEssageEvent = 9
    End Enum
    '事件定义
    '开始发送短信,在整批短信发送时触发一次,可用于记录线程信息
    Public Event BeginSendMessage(UserMessageID As String, SessionID As String, TotalCount As Long, StartTime As Long, Content As String, Usercode As String)
    '报告每条短信的发送状态,只记录一条短信从发送开始到发送结束的过程,可用于显示每条短信的发送状态
    Public Event ReportMessageStatus(SendEvent As enumSendEvent, MessageInfo As MessageInfo)
    '报告短信发送进度,记录整个短信发送过程的进度,可用于短信的整体发送进度,速度,时长与预计剩余时间
    Public Event ReportProgress(UserMessageID As String, SessionID As String, TotalCount As UInt64, SendCount As UInt64, SuccessedCount As Long, SpentTime As UInt64, Information As String)
    '报告杂项信息,报告各种各样的信息,包括异常,警告,成功,状态等信息,可用于输出调试或日志信息
    Public Event ReportInformation(Status As Long, Information As String, Param As Object)
    '发送短信结束,在整批短信发送结束时报告此消息,触发一次,可用于处理线程信息
    Public Event SendCompeleted(UserMessageID As String, SessionID As String, TotalCount As UInt64, SendCount As UInt64, SuccessedCount As Long, SpentTime As UInt64, Status As Long)

    'ThreadMode：0 自动线程，使用线程池 1：单线程 其他值：指定线程数
    Public Function SendMessage(Version As String, UserMessageID As String, SessionID As String, MessageType As Integer, _
                                Usercode As String, Password As String, RecipientList() As String, Content As String, _
                                CallbackURL As String, ThreadMode As Integer, _
                                MaxBatchSize As Integer, InvockPersecond As Double, QueueSize As Long, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean,
                                IP As String, MAC As String, CPUID As String, DISKID As String, ComputerName As String, ComputerUserName As String) As Integer
        Dim Recipients(0 To 3) As ArrayList
        Dim Nettype As Integer, MaxBatchNumber As Integer, Keywords As String
        Dim RetryTimes As Integer = 0
        If SessionID = "" Then SessionID = Guid.NewGuid().ToString
        SendProgressLog = log4net.LogManager.GetLogger("SendProgressLog")
        '开始发送短信
        _StartTime = System.Environment.TickCount

        RaiseEvent BeginSendMessage(UserMessageID, SessionID, _TotalCount, _StartTime, Content, Usercode)
        '内容检查
        If Content = "" Then
            RaiseEvent SendCompeleted(UserMessageID, SessionID, 0, 0, 0, 0, enumKLErrors.NO_CONTENT_ERROR)
            SendProgressLog.Error("请先输入消息内容后再发送.")

            Throw New Exception("请先输入消息内容后再发送.")
            Return enumKLErrors.NO_CONTENT_ERROR
        End If

        If RecipientList.Length = 0 Then
            RaiseEvent SendCompeleted(UserMessageID, SessionID, 0, 0, 0, 0, enumKLErrors.NO_RECIPIENTS_ERROR)
            Throw New Exception("没有联系人,请指定联系人")
            Return enumKLErrors.NO_RECIPIENTS_ERROR
        End If

        If Users Is Nothing Then Users = New System.Collections.Generic.Dictionary(Of String, UserInfo)
        SyncLock Users
            RaiseEvent ReportInformation(0, "用户鉴权,已登录" & Users.ContainsKey(Usercode.ToUpper), Nothing)
            If Not (Users.ContainsKey(Usercode.ToUpper) AndAlso Users(Usercode.ToUpper).NextLoginDate >= Now) Then
                Try
                    Dim _UserInfo As New UserInfo
                    RaiseEvent ReportInformation(0, "用户登录", Nothing)
                    _UserInfo.Login(Usercode, Password, Version, IP, MAC, ComputerName, ComputerUserName, CPUID, DISKID)
                    If Users.ContainsKey(Usercode.ToUpper) Then
                        Users(Usercode.ToUpper) = _UserInfo
                    Else
                        Users.Add(Usercode.ToUpper, _UserInfo)
                    End If

                Catch ex As Exception
                    RaiseEvent SendCompeleted(UserMessageID, SessionID, 0, 0, 0, 0, enumKLErrors.NO_CONTENT_ERROR)
                    Throw New Exception("用户登录失败" & ex.Message)
                    Return enumKLErrors.USER_LOGIN_ERROR
                End Try
            End If
        End SyncLock
        QueueSize = IIf(Users(Usercode.ToUpper).QueueSize = 0, QueueSize, Users(Usercode.ToUpper).QueueSize)
        If QueueSize = 0 Then QueueSize = 500
        '获取联系人列表
        _TotalCount = 0 : _SendCount = 0 : _ThreadCount = 0 : _ThreadIndex = 0
        Recipients = ReadRecipients(RecipientList)
        For i As Long = 0 To 3
            If Not (Recipients(i) Is Nothing) And i < 3 Then _TotalCount = _TotalCount + Recipients(i).Count
            If i = 3 And Not (Recipients(i) Is Nothing) Then
                RaiseEvent ReportInformation(enumKLErrors.ERROR_SERIALNUMBER, "收件人中包含" & Recipients(i).Count & "个错误号码", Recipients(i))
            End If
        Next

        If _TotalCount = 0 Then
            RaiseEvent SendCompeleted(UserMessageID, SessionID, 0, 0, 0, 0, enumKLErrors.NO_RECIPIENTS_ERROR)
            Throw New Exception("没有读取到收件人,请确认输入的收件人都正确") : Return enumKLErrors.NO_RECIPIENTS_ERROR
            Return enumKLErrors.NO_RECIPIENTS_ERROR
        End If

        '关键字处理
        Keywords = hasKeywords(Usercode, Password, Content)
        'If Keywords <> "" Then
        '    RaiseEvent SendCompeleted(UserMessageID, SessionID, 0, 0, 0, 0, enumKLErrors.KEYWORDS_ERROR)
        '    Throw New Exception("短信内容中包含关键字[" & Keywords & "]请修改后再发送")
        '    Return enumKLErrors.KEYWORDS_ERROR
        'End If
        'Dim t As New Thread(New ParameterizedThreadStart(AddressOf StartSendMessage))
        't.Start(New SendMessageParameter(Usercode, Password, UserMessageID, SessionID, Recipients, _
        '                                 Content, Nettype, CallbackURL, ThreadMode, InvockPersecond, MaxBatchNumber, QueueSize, _
        '                                 Simulation, RecordLog, AddTag, True, IP, MAC, CPUID, DISKID, ComputerName, ComputerUserName))

        StartSendMessage(New SendMessageParameter(Usercode, Password, UserMessageID, SessionID, Recipients, _
                                         Content, Nettype, CallbackURL, ThreadMode, InvockPersecond, MaxBatchNumber, QueueSize, _
                                         Simulation, RecordLog, AddTag, True, IP, MAC, CPUID, DISKID, ComputerName, ComputerUserName))
        Return 0
    End Function
    Private Function StartSendMessage(param As SendMessageParameter) As Long
        Dim Start As Long = 0, SendCount As Long = 0, ret As Long
        '开始按运营商循环
        For i As Integer = 0 To 2
            '初始化起始值
            Start = 0 : SendCount = 0
            '当此运营商有号码时才处理
            If Not (param.Recipients(i) Is Nothing) AndAlso param.Recipients(i).Count > 0 Then

                For j As Long = 0 To param.Recipients(i).Count Step param.QueueSize
                    If Start >= param.Recipients(i).Count Then Exit For
                    If Start + param.QueueSize >= param.Recipients(i).Count Then
                        SendCount = param.Recipients(i).Count - Start
                    Else
                        SendCount = param.QueueSize
                    End If
                    Dim Recipients_Copy(SendCount - 1) As String
                    'System.Array.Resize(Recipients_Copy, SendCount)
                    param.Recipients(i).CopyTo(Start, Recipients_Copy, 0, SendCount)
                    _SessionMessageCount = SendCount : _SessionSendCount = 0
                    ret = SplitSendMessage(param.UserMessageID, param.SessionID, param.Usercode, param.Password, Recipients_Copy, param.Message, i, param.MessageType, _
                                     param.ThreadMode, param.MaxBatchNumber, param.InvockPerSecond, param.CallbackURL, param.Simulation, param.RecordLog, param.AddTag, _
                                     param.IP, param.MAC, param.CPUID, param.DiskID, param.ComputerName, param.ComputerUserName)
                    Start = Start + SendCount

                    _Wait.WaitOne()
                Next

            End If
        Next
        Return 0
    End Function
    Private Function SplitSendMessage(UserMessageID As String, SessionID As String, Usercode As String, Password As String, Recipients() As String, _
                                 Message As String, Nettype As Integer, MessageType As Integer, ThreadMode As Integer, _
                                 MaxBatchNumber As Long, InvockPerSecond As Long, CallbackURL As String, _
                                 Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, _
                                 IP As String, MAC As String, CPUID As String, DISKID As String, ComputerName As String, ComputerUserName As String) As Integer
        Dim i As Long = Nettype, RetryTimes As Long = 0
        Dim SendCount As Long, Start As Long

        Dim ws As New SendMessage.myWebService
        Dim dt As DataTable

        '注册消息,获得需要的用户
StartRetry:
        Try

            dt = ws.AddNewMessage(Usercode, Password, SessionID, Recipients.Length, Nettype, Message, MessageType, IP, MAC, ComputerName, ComputerUserName, CPUID, DISKID)
        Catch ex As Exception
            RaiseEvent ReportInformation(enumKLErrors.ADD_NEW_MESSAGE_ERROR, "申请消息消息资源失败" & ex.Message, Recipients(i))
            If RetryTimes <= 5 Then RetryTimes = RetryTimes + 1 : GoTo StartRetry

            System.Threading.Interlocked.Add(_SendCount, Recipients(i).Length)
            RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, "申请消息消息资源超过5次,将跳过此批短信发送")
            RaiseEvent ReportInformation(enumKLErrors.ADD_NEW_MESSAGE_SKIPED, "申请消息消息资源超过5次,将跳过此批短信发送" & ex.Message, Recipients(i))
            _Wait.Set()
            If _SendCount >= _TotalCount Then
                RaiseEvent SendCompeleted(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, 0)
                Return 0
            End If

            Return -1
        End Try
        '再次确认资源是否足够,免得被服务端乌龙
        If dt.Rows.Count <= 0 OrElse dt.Compute("Sum(SendCount)", "") < Recipients.Length Then
            System.Threading.Interlocked.Add(_SendCount, Recipients(i).Length)
            RaiseEvent ReportInformation(enumKLErrors.LACK_OF_ACCOUNTS, "分配的资源不足以发送这么多短信,请联系管理员", Recipients(i))
            RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, "申请消息消息资源超过5次,将跳过此批短信发送")
            If _SendCount >= _TotalCount Then
                RaiseEvent SendCompeleted(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, 0)
                Return 0
            End If
            Return -1
        End If
        Dim SendSMS As New BatchSendMessage_Delegate(AddressOf BatchSendMessage)
        '下面循环开始发送短信,原则是先将每个账户的可发数量耗尽,下面每一次循环耗尽一个帐户
        For Each row As System.Data.DataRow In dt.Rows
            '每次循环都是新的数组对象

            '若起始值已经大于当前的长度,则直接退出
            If Start >= Recipients.Length Then Exit For
            If Start + row("SendCount") > Recipients.Length Then
                SendCount = Recipients.Length - Start
            Else
                SendCount = row("SendCount")
            End If

            Dim Recipients_Copy(SendCount - 1) As String
            'System.Array.Resize(Recipients_Copy, SendCount)
            'Recipients(i).CopyTo(Start, Recipients_Copy, 0, SendCount)
            System.Array.Copy(Recipients, Start, Recipients_Copy, 0, SendCount)
            Start = Start + SendCount
            MaxBatchNumber = IIf(MaxBatchNumber > 0, MaxBatchNumber, row("BatchSendNumbers"))
            InvockPerSecond = IIf(InvockPerSecond > 0, InvockPerSecond, row("InvockPerSecond"))
            Select Case ThreadMode
                Case 0
                    SendSMS.BeginInvoke(UserMessageID, SessionID, Recipients_Copy.Clone, row("RegisterUsercode"), row("RegisterPassword"), _
                                row("AccessUsercode"), row("AccessPassword"), Usercode, Password, _
                                i, Message, CallbackURL, 1000 / InvockPerSecond, MaxBatchNumber, SendCount, Simulation, RecordLog, _
                                AddTag, Nothing, _ThreadCount)
                Case 1
                    SendSMS.Invoke(UserMessageID, SessionID, Recipients_Copy.Clone, row("RegisterUsercode"), row("RegisterPassword"), _
                                row("AccessUsercode"), row("AccessPassword"), Usercode, Password, _
                                i, Message, CallbackURL, 1000 / InvockPerSecond, MaxBatchNumber, SendCount, Simulation, RecordLog, AddTag)
                Case Is > 1
                    _ThreadCount = _ThreadCount + 1
                    While _ThreadCount >= 20
                        System.Threading.Thread.Sleep(10)
                    End While
                Case Is > 50
                    SendSMS.BeginInvoke(UserMessageID, SessionID, Recipients_Copy.Clone, row("RegisterUsercode"), row("RegisterPassword"), _
                                row("AccessUsercode"), row("AccessPassword"), Usercode, Password, _
                                i, Message, CallbackURL, 1000 / InvockPerSecond, MaxBatchNumber, SendCount, Simulation, RecordLog, _
                                AddTag, Nothing, _ThreadCount)

            End Select

        Next
        Return 0
    End Function
    '调用发送短信方法投递短信
    '关于休眠时间,最佳时机是异步调用SendSMS.BeginInvoke方法后,这样不会阻碍其他
    Private Function BatchSendMessage(UserMessageID As String, SessionID As String, RegisterUsercode As String, RegisterPassword As String, _
                                AccessUsercode As String, AccessPassword As String, _
                                Usercode As String, Password As String, _
                                Recipients() As String, Nettype As Integer, Message As String, CallbackURL As String, Sleep As Long, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean) As Integer
        Dim ret As Long
        Dim ws1 As New SendServer.SendSMSService
        Dim connID As Long, rand As String, MessageID As Long
        Dim ws2 As New SendMessage.myWebService
        Dim MessageInfo As MessageInfo = New MessageInfo(UserMessageID, Usercode, SessionID, Join(Recipients, ";"), Recipients.Length, 0, "")
        Dim ReTryTimes As Integer, RefreshConnectionID As Boolean = False
        RaiseEvent ReportMessageStatus(enumSendEvent.StartSendEvent, MessageInfo)
        'Me.Invoke(New Report_Delegate(AddressOf AddListView), MessageInfo)
        System.Threading.Thread.Sleep(Sleep)
        System.Threading.Interlocked.Add(_SendCount, Recipients.Length)
        '登记消息,并获取MessageID
        ReTryTimes = 0
BeginGetMessageID:
        Try
            RaiseEvent ReportMessageStatus(enumSendEvent.BeginGetMessageIDEvent, MessageInfo)
            MessageID = ws2.SendMessage(Usercode, Password, "" & Join(Recipients, ";"), Recipients.Length, SessionID, RegisterUsercode, _
                            AccessUsercode, connID, Nettype)
            MessageInfo.MessageID = MessageID

        Catch ex As Exception
            RaiseEvent ReportInformation(enumKLErrors.GET_MESSAGEID_ERROR, "获取消息ID失败:" & ex.Message, MessageInfo)
            If ReTryTimes < 5 Then GoTo BeginGetMessageID
            MessageInfo.ErrorText = ex.Message
            MessageInfo.Status = enumKLErrors.GET_MESSAGEID_ERROR
            RaiseEvent ReportInformation(enumKLErrors.GET_MESSAGEID_ERROR, "获取消息ID重试5次失败:" & ex.Message, MessageInfo)
            RaiseEvent ReportMessageStatus(enumSendEvent.FinishedSendMEssageEvent, MessageInfo)
            RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, ex.Message)
            Return enumKLErrors.GET_MESSAGEID_ERROR
        Finally
            RaiseEvent ReportMessageStatus(enumSendEvent.EndGetMessageIDEvent, MessageInfo)
            ReTryTimes = 0
        End Try
        If AddTag = True Then Message = Message & ChrW((MessageID Mod 40869) + 19968)
BeginSend:
        Try
            RaiseEvent ReportMessageStatus(enumSendEvent.BeginGetConnectionIDEvent, MessageInfo)
            connID = MessageRegister.getConnectionID(connID, RegisterUsercode, RegisterPassword, CallbackURL, RefreshConnectionID)

        Catch ex As Exception
            MessageInfo.Status = connID
            MessageInfo.ErrorText = "获取连接失败." & ex.Message
            RaiseEvent ReportInformation(enumKLErrors.GET_CONNECTION_ERROR, "获取连接失败:" & ex.Message, MessageInfo)
            RaiseEvent ReportMessageStatus(enumSendEvent.FinishedSendMEssageEvent, MessageInfo)
            RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, ex.Message)
            Return enumKLErrors.GET_CONNECTION_ERROR
        Finally
            RaiseEvent ReportMessageStatus(enumSendEvent.EndGetConnectionIDEvent, MessageInfo)
        End Try
        '只在非模拟发送时才调用调用这个接口
        If Simulation = False Then
            Try
                RaiseEvent ReportMessageStatus(enumSendEvent.BeginSendMessageEvent, MessageInfo)
                rand = MessageRegister.getRandom()
                ret = ws1.sendSMS(AccessUsercode, SOP.Security.Security.HashAlgorithm(rand & AccessPassword & AccessPassword, "md5", "UTF-8"), rand, Recipients, "1", SOP.Security.Security.Base64Encode(Message, ""), MessageID, connID)
                MessageInfo.Status = ret
                If ret < 0 And ReTryTimes <= 3 Then
                    ReTryTimes = ReTryTimes + 1
                    RaiseEvent ReportInformation(enumKLErrors.SEND_MESSAGE_ERROR, "发送短信失败,重试" & ReTryTimes & "次", MessageInfo)
                    Select Case ret
                        Case -7
                            RefreshConnectionID = True
                            GoTo BeginSend
                        Case Else
                            GoTo BeginSend
                    End Select

                End If
                If ReTryTimes > 3 Then
                    RaiseEvent ReportInformation(enumKLErrors.SEND_MESSAGE_ERROR, "发送短信失败", MessageInfo)
                    RaiseEvent ReportMessageStatus(enumSendEvent.FinishedSendMEssageEvent, MessageInfo)
                    RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, ret)
                    Return enumKLErrors.SEND_MESSAGE_ERROR
                End If
            Catch ex As Exception
                MessageInfo.Status = enumKLErrors.SEND_MESSAGE_ERROR
                MessageInfo.ErrorText = ex.Message
                RaiseEvent ReportInformation(enumKLErrors.SEND_MESSAGE_ERROR, "发送短信失败", MessageInfo)
                RaiseEvent ReportMessageStatus(enumSendEvent.FinishedSendMEssageEvent, MessageInfo)
                RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, ex.Message)
                Return enumKLErrors.SEND_MESSAGE_ERROR
            Finally
                RaiseEvent ReportMessageStatus(enumSendEvent.EndSendMessageEvent, MessageInfo)
            End Try
        End If
 
        Try
            RaiseEvent ReportMessageStatus(enumSendEvent.BeginReportMessageEvent, MessageInfo)
            If Users(Usercode.ToUpper).UserData.Rows(0)("ReportStatus") = 1 Or ret < 0 Then ws2.FinishedSendMessage(Usercode, Password, RegisterUsercode, AccessUsercode, SessionID, MessageID, Recipients.Length, Nettype, ret, "")
            'If RecordLog = True Then WriteLog(AppDomain.CurrentDomain.ApplyPolicy .StartupPath & "\data\" & Format(Now, "yyyy-m-dd HH") & "_" & SessionID & ".txt", String.Join(vbCrLf, Recipients) & vbTab & MessageID & vbTab & Now)
        Catch ex As Exception
            RaiseEvent ReportInformation(enumKLErrors.OTHER_ERROR, "发送短信发生了点小意外,可能导致统计信息不正确,不过放心,短信已经给您发出去了!" & ex.Message, MessageInfo)
        Finally
            RaiseEvent ReportMessageStatus(enumSendEvent.EndReportMessageEvent, MessageInfo)
        End Try


        RaiseEvent ReportInformation(enumKLErrors.SEND_MESSAGE_SUCCESSED, "发送短信成功", MessageInfo)
        RaiseEvent ReportMessageStatus(enumSendEvent.FinishedSendMEssageEvent, MessageInfo)
        System.Threading.Interlocked.Add(_SuccessedCount, _SendCount)
        RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, "发送成功")

        System.Threading.Interlocked.Add(_SessionSendCount, _SendCount)
        If _SessionSendCount >= _SessionMessageCount Then
            _Wait.Set()
        End If

        If _SendCount >= _TotalCount And _TotalCount <> 0 Then
            Try
                '向服务器发送一个消息发送完毕的消息
                Dim ws As New SendMessage.myWebService
                ws.FinishedSendMessage(Usercode, Password, "", "", SessionID, "0", 0, 0, 1, "")
            Catch ex As Exception

                RaiseEvent ReportInformation(-1, "结束信息发送失败:" & ex.Message, MessageInfo)
            End Try
            '报告消息发送完毕,取消进度显示
            'Me.BeginInvoke(New Report_Delegate(AddressOf Callback_Compelted), MessageInfo.SharedObject)
            RaiseEvent SendCompeleted(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, 0)
        End If

        System.Threading.Interlocked.Decrement(_ThreadCount)
        Return enumKLErrors.SEND_MESSAGE_SUCCESSED
    End Function
    Private Delegate Function BatchSendMessage_Delegate(UserMessageID As String, SessionID As String, Recipients As String(), RegisterUsercode As String, RegisterPassword As String, _
                                AccessUsercode As String, AccessPassword As String, _
                                Usercode As String, Password As String, Nettype As Integer, Message As String, CallbackURL As String, _
                                Sleep As Long, MaxBatchNumber As Long, SendCount As Integer, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean) As Integer
    '调用发送短信方法投递短信
    '关于休眠时间,最佳时机是异步调用SendSMS.BeginInvoke方法后,这样不会阻碍其他
    Private Function BatchSendMessage(UserMessageID As String, SessionID As String, Recipients As String(), RegisterUsercode As String, RegisterPassword As String, _
                                AccessUsercode As String, AccessPassword As String, _
                                Usercode As String, Password As String, Nettype As Integer, Message As String, CallbackURL As String, _
                                Sleep As Long, MaxBatchNumber As Long, SendCount As Integer, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean) As Integer
        Dim ret As Integer
        '若账户可发送的号码数量小于可批量发送的数量,则将帐户可发送的号码一次发完
        If SendCount <= MaxBatchNumber Then
            '若帐户的可发送数量比当前待发的收件人数量还少,那就将所有的收件人一次发完
            ret = BatchSendMessage(UserMessageID, SessionID, RegisterUsercode, RegisterPassword, AccessUsercode, AccessPassword, _
                                Usercode, Password, Recipients, Nettype, Message, CallbackURL, Sleep, Simulation, RecordLog, AddTag)

        Else
            Dim Start As Long = 0
            '若帐户可发送的号码数量大于可批量发送的数量,则循环发送多批,直到此号码完全用完,要注意最后一段的处理
            For j As Long = 1 To SendCount \ MaxBatchNumber + 1
                Dim _tempMaxNumber As Long
                If Start >= SendCount Then Exit For
                If j * MaxBatchNumber > SendCount Then
                    _tempMaxNumber = SendCount - (j - 1) * MaxBatchNumber
                    '如果刚好相等了,则退出本次循环
                    If _tempMaxNumber = 0 Then Exit For
                Else
                    _tempMaxNumber = MaxBatchNumber
                End If
                'Start = Start + _tempMaxNumber
                Dim Recipients_Copy(_tempMaxNumber - 1) As String
                '重置联系人数组大小,否则会直接挂掉退出,并且不报任何错误
                'System.Array.Resize(Recipients_Copy, _tempMaxNumber)
                '将联系人复制到待发送列表
                System.Array.Copy(Recipients, Start, Recipients_Copy, 0, _tempMaxNumber)
                'Recipients.Copy(Recipients_Copy, 0, SendCount)
                Start = Start + _tempMaxNumber
                'System.Array.Copy(Recipients(i), Start, Recipients_Copy, 0, SendCount)
                ret = BatchSendMessage(UserMessageID, SessionID, RegisterUsercode, RegisterPassword, AccessUsercode, AccessPassword, _
                                Usercode, Password, Recipients_Copy, Nettype, Message, CallbackURL, Sleep, Simulation, RecordLog, AddTag)

            Next
        End If
        Return 0
    End Function
    Private Shared Function hasKeywords(Usercode As String, Password As String, Message As String) As String
        If dt_Keywords Is Nothing OrElse dt_Keywords.Tables.Count = 0 OrElse dt_Keywords.Tables(0).Rows.Count = 0 Then
            dt_Keywords = Query(Usercode, Password, "Select Badword,Method,ReplaceString From T_Badwords with(nolock)")

        End If
        If dt_Keywords Is Nothing OrElse dt_Keywords.Tables.Count = 0 OrElse dt_Keywords.Tables(0).Rows.Count = 0 Then Return ""
        Try
            For Each row As System.Data.DataRow In dt_Keywords.Tables(0).Rows
                If System.Text.RegularExpressions.Regex.IsMatch(Message, row("badword").ToString, System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Multiline) Then
                    Return row("badword").ToString
                End If
            Next
        Catch ex As Exception
            Return ""
        End Try
        Return ""
    End Function
    '分解联系人
    Private Function ReadRecipients(RecipientList() As String) As ArrayList()
        Dim Recipients(0 To 3) As ArrayList, Value As String, Nettype As Integer
        Dim Length As Long = RecipientList.Length
        For i = 0 To Length - 1
            Value = RecipientList(i)
            If Trim(Value) <> "" Then
                Nettype = getNetType(Value)
                If Recipients(Nettype) Is Nothing Then Recipients(Nettype) = New ArrayList
                Recipients(Nettype).Add(Microsoft.VisualBasic.Left(Trim(Value), 11))
            End If
        Next
        Return Recipients
    End Function

    Public Shared Sub NotifyStatus(eventID As Integer, sessionID As String, res As Int32, para1 As String)
        'WriteLog("收到回执>eventID:" & eventID & ",sessionID:" & sessionID & ",res:" & res & ",para1:" & para1)
        Dim ws As New SendMessage.myWebService
        ws.NotifyStatus(eventID, sessionID, res, para1)

    End Sub

    Public Shared Sub EchoOfSendSMS(ucNum As String, cee As String, msgid As Integer, res As Integer, recvt As String)
        Dim ws As New SendMessage.myWebService
        ws.EchoOfSendSMS(ucNum, cee, msgid, res, recvt)

    End Sub

    Public Shared Function RecvSMS(caller As String, time As String, cont As String, ucNum As String) As String
        Dim ws As New SendMessage.myWebService
        ws.RecvSMS(caller, time, cont, ucNum)

        Return cont
    End Function

End Class
