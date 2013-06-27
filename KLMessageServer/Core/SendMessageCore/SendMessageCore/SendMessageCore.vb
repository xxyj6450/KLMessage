Imports System
Imports System.Xml
Imports System.Threading
Imports System.Runtime.Remoting.Messaging
Imports System.Collections
Imports System.Data
Public Class SendMessageCore
    '私有字段定义
    Private RecipientsSource As String
    Private _SessionID As String
    Private _TotalCount As Long, _SendCount As Long, _SuccessedCount As Long
    Private _MessageType As Integer = 0
    Private _ThreadMode As Integer
    Private _Usercode As String
    Private _Password As String
    Private _MaxBatchSize As Integer
    Private _InvockPersecond As Integer
    Private _Simulation As Boolean
    Private _RecordLog As Boolean
    Private _AddTag As Boolean
    Private _StartTime As Long
    '存储关键字
    Private Shared dt_Keywords As System.Data.DataSet

    '错误码定义
    Public SEND_MESSAGE_SUCCESSED As Long = 0
    Public NO_CONTENT_ERROR As Long = -10000                            '没有短信内容
    Public NO_RECIPIENTS_ERROR As Long = -10001                         '没有正确的联系人
    Public KEYWORDS_ERROR As Long = -10002                              '敏感字检查失败
    Public ADD_NEW_MESSAGE_ERROR As Long = -10003                       '申请消息资源失败
    Public ERROR_SERIALNUMBER As Long = -10004                          '号码错误
    Public ADD_NEW_MESSAGE_SKIPED As Long = -10005                      '跳过消息资源申请
    Public LACK_OF_ACCOUNTS As Long = -10006                              '账号资源不足
    Public SEND_MESSAGE_ERROR = -10007
    Public GET_MESSAGEID_ERROR = -10008
    Public GET_CONNECTION_ERROR = -10009
    Public OTHER_ERROR = -10099

    Public Enum enumSendEvent As Long
        StartSendEvent = 0
        EndSendEvent = 1
        GetMessageIDEvent = 2
        GetConnectionIDEvent = 3
        SendMessageEvent = 4
        FinishedSendMessageEvent = 5
    End Enum
    '事件定义
    '开始发送短信,在整批短信发送时触发一次,可用于记录线程信息
    Public Event BeginSendMessage(UserMessageID As String, SessionID As String, TotalCount As Long, StartTime As Long)
    '报告每条短信的发送状态,只记录一条短信从发送开始到发送结束的过程,可用于显示每条短信的发送状态
    Public Event ReportMessageStatus(SendEvent As enumSendEvent, MessageInfo As MessageInfo)
    '报告短信发送进度,记录整个短信发送过程的进度,可用于短信的整体发送进度,速度,时长与预计剩余时间
    Public Event ReportProgress(UserMessageID As String, SessionID As String, TotalCount As UInt64, SendCount As UInt64, SuccessedCount As Long, SpentTime As UInt64, Information As String)
    '报告杂项信息,报告各种各样的信息,包括异常,警告,成功,状态等信息,可用于输出调试或日志信息
    Public Event ReportInformation(Status As Long, Information As String, Param As Object)
    '发送短信结束,在整批短信发送结束时报告此消息,触发一次,可用于处理线程信息
    Public Event SendCompeleted(UserMessageID As String, SessionID As String, TotalCount As UInt64, SendCount As UInt64, SuccessedCount As Long, SpentTime As UInt64, Status As Long)
    Public Sub SetSessionID(value As String)
        _SessionID = value
        _MessageType = 2
    End Sub
    '全部使用默认设置
    Public Function SendMessage(RecipientsSource() As String, Content As String) As Integer

    End Function

    '全部使用默认设置,增加模拟发送选项
    Public Function SendMessage(RecipientsSource() As String, Content As String, Simulation As Boolean) As Integer

    End Function
    '全部使用默认设置，但附带上用户自定义的消息ID
    Public Function SendMessage(UserMessageID As String, RecipientsSource() As String, Content As String) As Integer

    End Function
    '当客户有多个用户名时，可以指定用户名发送，其他配置使用默认设置
    Public Function SendMessage(Usercode As String, Password As String, RecipientsSource() As String, Content As String) As Integer

    End Function
    '当客户有多个用户名时，可以指定用户名发送，并且携带自定义的消息ID，其他配置使用默认设置
    Public Function SendMessage(Usercode As String, Password As String, UserMessageID As String, RecipientsSource() As String, Content As String) As Integer

    End Function

    '指定全部内容的
    Public Function SendMessage(UserMessageID As String, SessionID As String, MessageID As String, MessageType As Integer, _
                                Usercode As String, Password As String, RecipientList() As String, Content As String, _
                                CallbackURL As String, _ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean,
                                IP As String, MAC As String, CPUID As String, DISCKID As String, ComputerName As String, ComputerUserName As String) As Integer
        Dim Recipients(0 To 3) As ArrayList, RecipientString() As String, Start As Long, Recipient As String, Value As String
        Dim Nettype As Integer, MaxBatchNumber As Integer, SendCount As Long, Keywords As String

        Dim RetryTimes As Integer = 0

        If Content = "" Then
            RaiseEvent SendCompeleted(UserMessageID, SessionID, 0, 0, 0, 0, NO_CONTENT_ERROR)
            Throw New Exception("请先输入消息内容后再发送.")
            Return NO_CONTENT_ERROR
        End If

        If RecipientList.Length = 0 Then
            RaiseEvent SendCompeleted(UserMessageID, SessionID, 0, 0, 0, 0, NO_RECIPIENTS_ERROR)
            Throw New Exception("没有联系人,请指定联系人")
            Return NO_RECIPIENTS_ERROR
        End If

        '获取联系人列表
        _TotalCount = 0 : _SendCount = 0
        Recipients = ReadRecipients(RecipientList)
        For i As Long = 0 To 3
            If Not (Recipients(i) Is Nothing) And i < 3 Then _TotalCount = _TotalCount + Recipients(i).Count
            If i = 3 And Not (Recipients(i) Is Nothing) Then
                RaiseEvent ReportInformation(ERROR_SERIALNUMBER, "收件人中包含" & Recipients(i).Count & "个错误号码", Recipients(i))
            End If
        Next

        If _TotalCount = 0 Then
            RaiseEvent SendCompeleted(UserMessageID, SessionID, 0, 0, 0, 0, NO_RECIPIENTS_ERROR)
            Throw New Exception("没有读取到收件人,请确认输入的收件人都正确") : Return NO_RECIPIENTS_ERROR
            Return NO_RECIPIENTS_ERROR
        End If

        '关键字处理
        Keywords = hasKeywords(Usercode, Password, Content)
        If Keywords <> "" Then
            RaiseEvent SendCompeleted(UserMessageID, SessionID, 0, 0, 0, 0, KEYWORDS_ERROR)
            Throw New Exception("短信内容中包含关键字[" & Keywords & "]请修改后再发送")
            Return KEYWORDS_ERROR
        End If

        '开始发送短信
        _StartTime = System.Environment.TickCount
        RaiseEvent BeginSendMessage(UserMessageID, SessionID, _TotalCount, _StartTime)
        If SessionID = "" Then SessionID = Guid.NewGuid().ToString
        '开始按运营商循环
        For i As Integer = 0 To 2
            '初始化起始值
            Start = 0 : SendCount = 0
            '当此运营商有号码时才处理
            If Not (Recipients(i) Is Nothing) AndAlso Recipients(i).Count > 0 Then
                Dim ws As New SendMessage.myWebService
                Dim dt As DataTable
                '注册消息,获得需要的用户
                RetryTimes = 0
StartRetry:
                Try

                    dt = ws.AddNewMessage(Usercode, Password, SessionID, Recipients(i).Count, i, Content, _MessageType, IP, MAC, ComputerName, ComputerUserName, CPUID, DiskID)
                Catch ex As Exception
                    RaiseEvent ReportInformation(ADD_NEW_MESSAGE_ERROR, "申请消息消息资源失败" & ex.Message, Recipients(i))
                    If RetryTimes <= 5 Then RetryTimes = RetryTimes + 1 : GoTo StartRetry

                    System.Threading.Interlocked.Add(_SendCount, Recipients(i).Count)
                    RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, "申请消息消息资源超过5次,将跳过此批短信发送")
                    RaiseEvent ReportInformation(ADD_NEW_MESSAGE_SKIPED, "申请消息消息资源超过5次,将跳过此批短信发送" & ex.Message, Recipients(i))
                    If _SendCount >= _TotalCount Then
                        RaiseEvent SendCompeleted(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, 0)
                        Return 0
                    End If

                    Continue For
                End Try
                '再次确认资源是否足够,免得被服务端乌龙
                If dt.Rows.Count <= 0 OrElse dt.Compute("Sum(SendCount)", "") < Recipients(i).Count Then
                    System.Threading.Interlocked.Add(_SendCount, Recipients(i).Count)
                    RaiseEvent ReportInformation(LACK_OF_ACCOUNTS, "分配的资源不足以发送这么多短信,请联系管理员", Recipients(i))
                    RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, "申请消息消息资源超过5次,将跳过此批短信发送")
                    If _SendCount >= _TotalCount Then
                        RaiseEvent SendCompeleted(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, 0)
                        Return 0
                    End If
                    Continue For
                End If
                Dim SendSMS As New BatchSendMessage_Delegate(AddressOf BatchSendMessage)
                '下面循环开始发送短信,原则是先将每个账户的可发数量耗尽,下面每一次循环耗尽一个帐户
                For Each row As System.Data.DataRow In dt.Rows
                    '每次循环都是新的数组对象

                    '若起始值已经大于当前的长度,则直接退出
                    If Start >= Recipients(i).Count Then Exit For
                    MaxBatchNumber = IIf(MaxBatchNumber > 0, row("BatchSendNumbers"), MaxBatchNumber)
                    InvockPersecond = IIf(InvockPersecond > 0, row("InvockPerSecond"), InvockPersecond)
                    If Start + row("SendCount") > Recipients(i).Count Then
                        SendCount = Recipients(i).Count - Start
                    Else
                        SendCount = row("SendCount")
                    End If

                    Dim Recipients_Copy() As String
                    System.Array.Resize(Recipients_Copy, SendCount)
                    Recipients(i).CopyTo(Start, Recipients_Copy, 0, SendCount)
                    Start = Start + SendCount
                    SendSMS.BeginInvoke(UserMessageID, SessionID, Recipients_Copy.Clone, row("RegisterUsercode"), row("RegisterPassword"), _
                                        row("AccessUsercode"), row("AccessPassword"), Usercode, Password, _
                                        i, Content, CallbackURL, 1000 / InvockPersecond, MaxBatchNumber, SendCount, Simulation, RecordLog, AddTag, Nothing, Nothing)
                Next
            End If
        Next
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
        Dim MessageInfo As MessageInfo = New MessageInfo(UserMessageID, SessionID, Join(Recipients, ";"), Recipients.Length, "等待发送", "")
        Dim ReTryTimes As Integer, RefreshConnectionID As Boolean = False
        RaiseEvent ReportMessageStatus(enumSendEvent.StartSendEvent, MessageInfo)
        'Me.Invoke(New Report_Delegate(AddressOf AddListView), MessageInfo)
        System.Threading.Thread.Sleep(Sleep)
        System.Threading.Interlocked.Add(_SendCount, Recipients.Length)
        '登记消息,并获取MessageID
        ReTryTimes = 0
BeginGetMessageID:
        Try
            MessageID = ws2.SendMessage(Usercode, Password, "" & Join(Recipients, ";"), Recipients.Length, SessionID, RegisterUsercode, _
                            AccessUsercode, connID, Nettype)
            MessageInfo.MessageID = MessageID
            RaiseEvent ReportMessageStatus(enumSendEvent.GetMessageIDEvent, MessageInfo)
        Catch ex As Exception
            RaiseEvent ReportInformation(GET_MESSAGEID_ERROR, "获取消息ID失败:" & ex.Message, MessageInfo)
            If ReTryTimes < 5 Then GoTo BeginGetMessageID
            MessageInfo.ErrorText = ex.Message
            MessageInfo.Status = GET_MESSAGEID_ERROR
            RaiseEvent ReportInformation(GET_MESSAGEID_ERROR, "获取消息ID重试5次失败:" & ex.Message, MessageInfo)
            RaiseEvent ReportMessageStatus(enumSendEvent.EndSendEvent, MessageInfo)
            RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, ex.Message)
            Return GET_MESSAGEID_ERROR
        Finally
            ReTryTimes = 0
        End Try
        If AddTag = True Then Message = Message & ChrW((MessageID Mod 40869) + 19968)
BeginSend:
        Try
            connID = MessageRegister.getConnectionID(RegisterUsercode, RegisterPassword, CallbackURL, RefreshConnectionID)
            rand = MessageRegister.getRandom()
            RaiseEvent ReportMessageStatus(enumSendEvent.GetConnectionIDEvent, MessageInfo)
        Catch ex As Exception
            MessageInfo.Status = connID
            MessageInfo.ErrorText = "获取连接失败." & ex.Message
            RaiseEvent ReportInformation(GET_CONNECTION_ERROR, "获取连接失败:" & ex.Message, MessageInfo)
            RaiseEvent ReportMessageStatus(enumSendEvent.EndSendEvent, MessageInfo)
            RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, ex.Message)
            Return GET_CONNECTION_ERROR
        End Try
            '只在非模拟发送时才调用调用这个接口
        If Simulation = False Then
            Try
                ret = ws1.sendSMS(AccessUsercode, SOP.Security.Security.HashAlgorithm(rand & AccessPassword & AccessPassword, "md5", "UTF-8"), rand, Recipients, "1", SOP.Security.Security.Base64Encode(Message, ""), MessageID, connID)
                MessageInfo.Status = ret
                If ret < 0 And ReTryTimes <= 5 Then

                    Select Case ret
                        Case -1, -5, -7, -12
                            ReTryTimes = ReTryTimes + 1
                            RefreshConnectionID = True
                            RaiseEvent ReportInformation(SEND_MESSAGE_ERROR, "发送短信失败", MessageInfo)
                            GoTo BeginSend
                        Case Else
                            RaiseEvent ReportInformation(SEND_MESSAGE_ERROR, "发送短信失败", MessageInfo)
                            RaiseEvent ReportMessageStatus(enumSendEvent.EndSendEvent, MessageInfo)
                            RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, ret)
                            Return SEND_MESSAGE_ERROR
                    End Select

                End If
            Catch ex As Exception
                MessageInfo.Status = SEND_MESSAGE_ERROR
                MessageInfo.ErrorText = ex.Message
                RaiseEvent ReportInformation(SEND_MESSAGE_ERROR, "发送短信失败", MessageInfo)
                RaiseEvent ReportMessageStatus(enumSendEvent.EndSendEvent, MessageInfo)
                RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, ex.Message)
                Return SEND_MESSAGE_ERROR
            End Try
        End If

        System.Threading.Interlocked.Add(_SuccessedCount, _SendCount)
        RaiseEvent ReportInformation(SEND_MESSAGE_SUCCESSED, "发送短信成功", MessageInfo)
        RaiseEvent ReportMessageStatus(enumSendEvent.EndSendEvent, MessageInfo)
        RaiseEvent ReportProgress(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, "发送成功")

        Try
            ws2.FinishedSendMessage(Usercode, Password, RegisterUsercode, AccessUsercode, SessionID, MessageID, Recipients.Length, Nettype, ret)
            'If RecordLog = True Then WriteLog(AppDomain.CurrentDomain.ApplyPolicy .StartupPath & "\data\" & Format(Now, "yyyy-m-dd HH") & "_" & SessionID & ".txt", String.Join(vbCrLf, Recipients) & vbTab & MessageID & vbTab & Now)
        Catch ex As Exception
            RaiseEvent ReportInformation(OTHER_ERROR, "发送短信发生了点小意外,可能导致统计信息不正确,不过放心,短信已经给您发出去了!" & ex.Message, MessageInfo)
        End Try

        If _SendCount >= _TotalCount And _TotalCount <> 0 Then
            Try
                '向服务器发送一个消息发送完毕的消息
                Dim ws As New SendMessage.myWebService
                ws.FinishedSendMessage(Usercode, Password, "", "", SessionID, "0", 0, 0, 1)
            Catch ex As Exception

                RaiseEvent ReportInformation(-1, "结束信息发送失败:" & ex.Message, MessageInfo)
            End Try
            '报告消息发送完毕,取消进度显示
            'Me.BeginInvoke(New Report_Delegate(AddressOf Callback_Compelted), MessageInfo.SharedObject)
            RaiseEvent SendCompeleted(UserMessageID, SessionID, _TotalCount, _SendCount, _SuccessedCount, Environment.TickCount - _StartTime, 0)
        End If

        Return SEND_MESSAGE_SUCCESSED
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
                Dim Recipients_Copy() As String
                '重置联系人数组大小,否则会直接挂掉退出,并且不报任何错误
                System.Array.Resize(Recipients_Copy, _tempMaxNumber)
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
    Public Sub New()
        With My.Settings
            _AddTag = .AddTag
            _InvockPersecond = .InvockPersecond
            _MaxBatchSize = .MaxBatchSize
            _Usercode = .Usercode
            _Password = .Password
            _RecordLog = .RecordLog
            _ThreadMode = .ThreadMode
        End With
    End Sub
End Class
