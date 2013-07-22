Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Services.Description
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Xml.Serialization
Imports System.Xml
Imports System.Web.Configuration
Imports System.Data.OleDb
Imports log4net
<System.Web.Services.WebService(Namespace:="http://KLMessage.org/")> _
<SoapDocumentService(RoutingStyle:=SoapServiceRoutingStyle.RequestElement, Use:=SoapBindingUse.Literal)> _
<WebServiceBinding(ConformsTo:=WsiProfiles.None)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class KLMessageWebService
    Inherits System.Web.Services.WebService
    Private Shared IP As String
    Private Shared MAC As String
    Private Shared CPUID As String
    Private Shared DISKID As String
    Private QueueSize As Long
    Private Const Version As String = "C126367F-AAF6-49F0-9037-622A9C630FF9"

    Private WithEvents KLMessageClient As KLMessage.SendMessageClient
    Private Log As log4net.ILog
    Private FailedMessageLog As log4net.ILog
 

    Private Function InitializeParameter(ByRef Usercode As String, ByRef Password As String,
                               Optional ByRef CallbackURL As String = "http://218.16.64.234:802/webservice.asmx", _
                               Optional ByRef ThreadMode As Integer = 0, Optional ByRef MaxBatchSize As Integer = 10, _
                               Optional ByRef InvockPersecond As Double = 2, Optional ByRef QueueSize As Long = 500) As Long
        Usercode = IIf(Usercode = "", My.Settings.Usercode, Usercode)
        Password = IIf(Password = "", My.Settings.Password, Password)
        CallbackURL = IIf(CallbackURL = "", My.Settings.CallbackURL, CallbackURL)
        If IsNumeric(My.Settings.ThreadMode) = False OrElse CInt((My.Settings.ThreadMode)) < 0 OrElse CInt((My.Settings.ThreadMode)) > 50 Then
            ThreadMode = 0
        Else
            ThreadMode = IIf(ThreadMode > 0, ThreadMode, My.Settings.ThreadMode)
        End If
        If IsNumeric(My.Settings.MaxBatchSize) = False OrElse CInt((My.Settings.MaxBatchSize)) < 0 OrElse CInt((My.Settings.MaxBatchSize)) > 10 Then
            MaxBatchSize = 10
        Else
            MaxBatchSize = IIf(MaxBatchSize < 0, My.Settings.MaxBatchSize, MaxBatchSize)
        End If
        If IsNumeric(My.Settings.InvockPersecond) = False OrElse CInt((My.Settings.InvockPersecond)) < 0 OrElse CInt((My.Settings.InvockPersecond)) > 10 Then
            InvockPersecond = 10
        Else
            InvockPersecond = IIf(InvockPersecond < 0, My.Settings.InvockPersecond, InvockPersecond)
        End If
        If IsNumeric(My.Settings.QueueSize) = False OrElse CInt(My.Settings.QueueSize) < 0 Then
            QueueSize = 500
        Else
            QueueSize = My.Settings.QueueSize
        End If
        If Usercode = "" Or Password = "" Then
            Throw New SoapException("用户名或密码为空。", SoapException.ServerFaultCode)
        End If
        If IP = "" Then IP = GetIP()
        If MAC = "" Then MAC = GetMacAddress()
        If DISKID = "" Then DISKID = GetDiskID()
        If CPUID = "" Then CPUID = GetCpuID()
        Return 0
    End Function
    <WebMethod(Description:="使用默认配置,传入短信内容和接收人列表(分号分隔)字符串发送短信")> _
    <SoapRpcMethod(Action:="SendMessageByRecipientsString", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessageByRecipientsString(RecipientsSource As String, Content As String) As Integer
        Dim Usercode As String, Password As String, _
                                CallbackURL As String, ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, QueueSize As Long

        InitializeParameter(Usercode, Password, CallbackURL, ThreadMode, MaxBatchSize, InvockPersecond, QueueSize)

        SendMessage(New KLMessage.SendMessageParameter(Version, Usercode, Password, "", Guid.NewGuid().ToString, RecipientsSource.Split(";"), Content, 0, CallbackURL, _
                                                              ThreadMode, InvockPersecond, MaxBatchSize, QueueSize, Simulation, RecordLog, AddTag, False, _
                                                              IP, MAC, CPUID, DISKID, My.Computer.Name, My.User.Name))

    End Function
    '全部使用默认设置
    <WebMethod(Description:="使用默认配置,传入短信内容和接收人数组发送短信 ")> _
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(RecipientsSource As String(), Content As String) As Integer
        Dim Usercode As String, Password As String, _
                                CallbackURL As String, ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, QueueSize As Long

        InitializeParameter(Usercode, Password, CallbackURL, ThreadMode, MaxBatchSize, InvockPersecond, QueueSize)
        SendMessage(New KLMessage.SendMessageParameter(Version, Usercode, Password, "", Guid.NewGuid().ToString, RecipientsSource, Content, 0, CallbackURL, _
                                                       ThreadMode, InvockPersecond, MaxBatchSize, QueueSize, Simulation, RecordLog, AddTag, False, _
                                                       IP, MAC, CPUID, DISKID, My.Computer.Name, My.User.Name))
 

    End Function
    '全部使用默认设置，但附带上用户自定义的消息ID
    <WebMethod(Description:="同上SendMessage,但是可以带入自己的消息ID")> _
    <SoapRpcMethod(Action:="SendMessageWithMessageID", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessageWithMessageID(UserMessageID As String, RecipientsSource() As String, Content As String) As Integer
        Dim Usercode As String, Password As String, _
                                CallbackURL As String, ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, QueueSize As Long

        InitializeParameter(Usercode, Password, CallbackURL, ThreadMode, MaxBatchSize, InvockPersecond, QueueSize)
        SendMessage(New KLMessage.SendMessageParameter(Version, Usercode, Password, UserMessageID, Guid.NewGuid().ToString, RecipientsSource, Content, 0, CallbackURL, _
                                                       ThreadMode, InvockPersecond, MaxBatchSize, QueueSize, Simulation, RecordLog, AddTag, False, _
                                                       IP, MAC, CPUID, DISKID, My.Computer.Name, My.User.Name))
 
    End Function
    '当客户有多个用户名时，可以指定用户名发送，其他配置使用默认设置
    <WebMethod(Description:="如果有多个用户 这个接口可以指定其中一个用户发送短信")> _
    <SoapRpcMethod(Action:="SendMessageWithUserInfo", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessageWithUserInfo(Usercode As String, Password As String, RecipientsSource() As String, Content As String) As Integer
        Dim CallbackURL As String, ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, QueueSize As Long

        InitializeParameter(Usercode, Password, CallbackURL, ThreadMode, MaxBatchSize, InvockPersecond, QueueSize)
        SendMessage(New KLMessage.SendMessageParameter(Version, Usercode, Password, "", Guid.NewGuid().ToString, RecipientsSource, Content, 0, CallbackURL, _
                                                       ThreadMode, InvockPersecond, MaxBatchSize, QueueSize, Simulation, RecordLog, AddTag, False, _
                                                       IP, MAC, CPUID, DISKID, My.Computer.Name, My.User.Name))
 
    End Function
    '当客户有多个用户名时，可以指定用户名发送，并且携带自定义的消息ID，其他配置使用默认设置
    <WebMethod(Description:="可以同时指定一个用户并带入自己的消息ID")> _
    <SoapRpcMethod(Action:="SendMessageWithUserAndMessageID", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessageWithUserAndMessageID(Usercode As String, Password As String, UserMessageID As String, RecipientsSource() As String, _
                                                    Content As String) As Integer
        Dim CallbackURL As String, ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, QueueSize As Long

        InitializeParameter(Usercode, Password, CallbackURL, ThreadMode, MaxBatchSize, InvockPersecond, QueueSize)
        SendMessage(New KLMessage.SendMessageParameter(Version, Usercode, Password, UserMessageID, Guid.NewGuid().ToString, RecipientsSource, Content, 0, CallbackURL, _
                                                       ThreadMode, InvockPersecond, MaxBatchSize, QueueSize, Simulation, RecordLog, AddTag, False, _
                                                       IP, MAC, CPUID, DISKID, My.Computer.Name, My.User.Name))
 
    End Function

    'ThreadMode：0 自动线程，使用线程池 1：单线程 其他值：指定线程数
    <WebMethod(Description:="这个是最完整的调用方式,包含所有的参数")> _
    <SoapRpcMethod(Action:="SendMessageEx", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessageEx(UserMessageID As String, Usercode As String, Password As String, RecipientsSource() As String, Content As String, _
                                CallbackURL As String, ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, QueueSize As Long, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean) As Integer
        InitializeParameter(Usercode, Password, CallbackURL, ThreadMode, MaxBatchSize, InvockPersecond, QueueSize)
        SendMessage(New KLMessage.SendMessageParameter(Version, Usercode, Password, UserMessageID, Guid.NewGuid().ToString, RecipientsSource, Content, 0, CallbackURL, _
                                                       ThreadMode, InvockPersecond, MaxBatchSize, QueueSize, Simulation, RecordLog, AddTag, False, _
                                                       IP, MAC, CPUID, DISKID, My.Computer.Name, My.User.Name))
        Return 0
 
    End Function
    Public Sub SendMessage(MessageParameter As KLMessage.SendMessageParameter)
        If KLMessageClient Is Nothing Then KLMessageClient = New KLMessage.SendMessageClient
        With MessageParameter
            AddNewMessage(.Usercode, .Password, .SessionID, .Recipients.Length, 0, .Message, .MessageType, _
                          .IP, .MAC, .ComputerName, .ComputerUserName, .CPUID, .DiskID)
            SendMessageClient.SendMessage(MessageParameter)
        End With
    End Sub
    Public Function FinishedSendMessage(Usercode As String, Password As String, Registerusercode As String, AccessUsercode As String, SessionID As String, MessageId As String, RecipientsCount As Long, _
                                        NetType As Integer, Status As Integer, ErrorText As String) As Integer
        Dim cmd As System.Data.OleDb.OleDbCommand
        '身份验证
        Using conn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(Web.Configuration.WebConfigurationManager.ConnectionStrings("KLMessageClientDB").ConnectionString)
            conn.Open()
            cmd = New System.Data.OleDb.OleDbCommand("sp_FinishedSendMessage", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@Usercode", OleDb.OleDbType.VarChar, 50).Value = Usercode
                .Parameters.Add("@RegisterUsercode", OleDb.OleDbType.VarChar, 50).Value = Registerusercode
                .Parameters.Add("@AccessUsercode", OleDb.OleDbType.VarChar, 50).Value = AccessUsercode
                .Parameters.Add("@SessionID", OleDb.OleDbType.VarChar, 50).Value = SessionID
                .Parameters.Add("@MessageID", OleDb.OleDbType.BigInt).Value = MessageId
                .Parameters.Add("@RecipientsCount", OleDb.OleDbType.BigInt).Value = RecipientsCount
                .Parameters.Add("@NetType", OleDb.OleDbType.BigInt).Value = NetType
                .Parameters.Add("@Status", OleDb.OleDbType.VarChar).Value = Status
                .Parameters.Add("@ErrorText", OleDb.OleDbType.VarChar, 200).Value = ErrorText
                .ExecuteNonQuery()
                Return 0
            End With

        End Using
    End Function
    Public Function AddNewMessage(Usercode As String, Password As String, SessionID As String, RecipientCount As Long, Nettype As Integer, Content As String, MessageType As Integer, _
                                      IP As String, MAC As String, ComputerName As String, ComputerUserName As String, CPUID As String, DISKID As String) As Long
        Dim NetworkIP As String
 
        Using conn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("KLMessageClientDB").ConnectionString)
            conn.Open()
            Dim cmd As System.Data.OleDb.OleDbCommand = New OleDb.OleDbCommand("sp_AddNewMessage", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@SessionID", OleDb.OleDbType.VarChar, 50).Value = SessionID
                .Parameters.Add("@Content", OleDb.OleDbType.VarChar, 1000).Value = Content
                .Parameters.Add("@Usercode", OleDb.OleDbType.VarChar, 50).Value = Usercode
                .Parameters.Add("@RecipientCount", OleDb.OleDbType.BigInt).Value = RecipientCount
                .Parameters.Add("@Nettype", OleDb.OleDbType.SmallInt).Value = Nettype
                .Parameters.Add("@MessageType", OleDb.OleDbType.BigInt).Value = MessageType
                .Parameters.Add("IP", OleDb.OleDbType.VarChar, 50).Value = IP
                .Parameters.Add("@NetworkIP", OleDb.OleDbType.VarChar, 50).Value = NetworkIP
                .Parameters.Add("@CPUID", OleDb.OleDbType.VarChar, 50).Value = CPUID
                .Parameters.Add("@DISKID", OleDb.OleDbType.VarChar, 50).Value = DISKID
                .Parameters.Add("@ComputerName", OleDb.OleDbType.VarChar, 100).Value = ComputerName
                .Parameters.Add("@MAC", OleDb.OleDbType.VarChar, 100).Value = MAC
                .Parameters.Add("@ComputerUserName", OleDb.OleDbType.VarChar, 100).Value = ComputerUserName
                .ExecuteNonQuery()
                'dt.Load(.ExecuteReader(CommandBehavior.CloseConnection))
                Return 0
            End With
        End Using
    End Function
    Public Function UpdateSessionStatus(SessionID As String, Status As Integer, ErrorText As String) As Long

        Using conn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("KLMessageClientDB").ConnectionString)
            conn.Open()
            Dim cmd As System.Data.OleDb.OleDbCommand = New OleDb.OleDbCommand("sp_UpdateSessionStauts", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@SessionID", OleDb.OleDbType.VarChar, 50).Value = SessionID
                .Parameters.Add("@Status", OleDb.OleDbType.BigInt).Value = Status
                .Parameters.Add("@ErrorText", OleDb.OleDbType.VarChar, 500).Value = ErrorText
 
                .ExecuteNonQuery()
                'dt.Load(.ExecuteReader(CommandBehavior.CloseConnection))
                Return 0
            End With
        End Using
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="UserMessageID"></param>
    ''' <param name="MessageID"></param>
    ''' <param name="SessionID"></param>
    ''' <param name="Usercode"></param>
    ''' <param name="Password"></param>
    ''' <param name="Recipients"></param>
    ''' <param name="RecipientsCount"></param>
    ''' <param name="RegisterUsercode"></param>
    ''' <param name="AccessUsercode"></param>
    ''' <param name="CONNID"></param>
    ''' <param name="Nettype"></param>
    ''' <param name="Status">0:还未发送 1:已入队 2:正在发送 3:发送完毕 小于0 发送异常</param>
    ''' <remarks></remarks>
    Public Sub AddMessageSendLog(UserMessageID As String, MessageID As Long, SessionID As String, _
                                 Usercode As String, Password As String, Recipients As String, RecipientsCount As Integer, _
                                RegisterUsercode As String, AccessUsercode As String, _
                                CONNID As Long, Nettype As Integer, Status As Integer)
        Dim cmd As System.Data.OleDb.OleDbCommand
        '身份验证
        Using conn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("KLMessageClientDB").ConnectionString)

            conn.Open()
            cmd = New System.Data.OleDb.OleDbCommand("sp_AddMessageSendLog", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@Usercode", OleDbType.VarChar, 50).Value = Usercode
                .Parameters.Add("@UserMessageID", OleDbType.VarChar, 50).Value = UserMessageID
                .Parameters.Add("@AccessUsercode", OleDbType.VarChar).Value = AccessUsercode
                .Parameters.Add("@Recipients", OleDbType.VarChar).Value = Recipients
                .Parameters.Add("@RecipientsCount", OleDbType.BigInt).Value = RecipientsCount
                .Parameters.Add("@SessionID", OleDbType.VarChar, 50).Value = SessionID
                .Parameters.Add("@CONNID", OleDbType.BigInt).Value = CONNID
                .Parameters.Add("@Nettype", OleDbType.BigInt).Value = Nettype
                .Parameters.Add("@MessageID", OleDbType.BigInt).Value = MessageID
                .Parameters.Add("@Status", OleDbType.BigInt).Value = Status
                .Parameters.Add("@RegisterUsercode", OleDbType.VarChar).Value = RegisterUsercode
                .ExecuteNonQuery()

            End With

        End Using
    End Sub
    
    Private Sub KLMessageClient_BeginSendMessage(UserMessageID As String, SessionID As String, TotalCount As Long, StartTime As Long, Content As String, Usercode As String) Handles KLMessageClient.BeginSendMessage
        UpdateSessionStatus(SessionID, 1, "")
        Log.Info("准备发送消息:" & SessionID & ",总计" & TotalCount & "条")
    End Sub

    Private Sub KLMessageClient_Dequeue(Message As SendMessageParameter) Handles KLMessageClient.Dequeue
        Log.Info("消息出队:" & Message.SessionID)
    End Sub

    Private Sub KLMessageClient_Enqueue(Message As SendMessageParameter) Handles KLMessageClient.Enqueue
        Log.Info("消息入队:" & Message.SessionID)
    End Sub

    Private Sub KLMessageClient_ReportInformation(Status As Long, Information As String, Param As Object) Handles KLMessageClient.ReportInformation
        Log.Info("报告消息:" & "状态:" & Status & ",消息" & Information)
    End Sub

    Private Sub KLMessageClient_ReportMessageStatus(SendEvent As SendMessageCore.enumSendEvent, MessageInfo As MessageInfo) Handles KLMessageClient.ReportMessageStatus
        Log.Info("报告消息状态:事件" & SendEvent.ToString & "会话:" & MessageInfo.SessionID & "消息" & MessageInfo.MessageID & "状态:" & MessageInfo.Status & ",内容" & MessageInfo.ErrorText)
        If SendEvent = SendMessageCore.enumSendEvent.BeginSendMessageEvent Then
            AddMessageSendLog(MessageInfo.UserMessageID, MessageInfo.MessageID, MessageInfo.SessionID, MessageInfo.Usercode, "", String.Join(";", MessageInfo.Recipients), _
                              MessageInfo.RecipientsCount, "", "", 0, 0, MessageInfo.Status)
        ElseIf SendEvent = SendMessageCore.enumSendEvent.FinishedSendMEssageEvent Then
            FinishedSendMessage(MessageInfo.Usercode, "", "", "", MessageInfo.SessionID, MessageInfo.MessageID, MessageInfo.RecipientsCount, 0, MessageInfo.Status, MessageInfo.ErrorText)
        End If
    End Sub

    Private Sub KLMessageClient_ReportProgress(UserMessageID As String, SessionID As String, TotalCount As ULong, SendCount As ULong, SuccessedCount As Long, SpentTime As ULong, Information As String) Handles KLMessageClient.ReportProgress

    End Sub

    Private Sub KLMessageClient_SendCompeleted(UserMessageID As String, SessionID As String, TotalCount As ULong, SendCount As ULong, SuccessedCount As Long, SpentTime As ULong, Status As Long) Handles KLMessageClient.SendCompeleted
        Log.Info("队列发送完毕" & SessionID)
        FinishedSendMessage("", "", "", "", SessionID, 0, 0, 0, Status, "")
    End Sub

    Public Sub New()
        Log = log4net.LogManager.GetLogger("WebServiceLog")
    End Sub
End Class