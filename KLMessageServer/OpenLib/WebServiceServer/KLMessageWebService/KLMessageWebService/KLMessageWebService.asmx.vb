Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Services.Description
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Xml.Serialization
Imports System.Xml
Imports System.Web.Configuration

<System.Web.Services.WebService(Namespace:="http://KLMessage.org/")> _
<SoapDocumentService(RoutingStyle:=SoapServiceRoutingStyle.RequestElement, Use:=SoapBindingUse.Literal)> _
<WebServiceBinding(ConformsTo:=WsiProfiles.None)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class KLMessageWebService
    Inherits System.Web.Services.WebService
    Private Shared IP As String
    Private Shared MAC As String
    Private Shared CPUID As String
    Private Shared DISCKID As String
    Private WithEvents KLMessage As KLMessage.SendMessageCore
    Private Sub InitializeParameter(ByRef Usercode As String, ByRef Password As String, _
                               Optional ByRef CallbackURL As String = "http://218.16.64.234:802/webservice.asmx", _
                               Optional ByRef ThreadMode As Integer = 0, Optional ByRef MaxBatchSize As Integer = 10, Optional ByRef InvockPersecond As Double = 2)
        Usercode = IIf(Usercode = "", My.Settings.Usercode, Usercode)
        Password = IIf(Password = "", My.Settings.Password, Password)
        CallbackURL = IIf(CallbackURL = "", My.Settings.CallbackURL, CallbackURL)
        If IsNumeric(My.Settings.ThreadMode) = False OrElse CInt(IsNumeric(My.Settings.ThreadMode)) < 0 OrElse CInt(IsNumeric(My.Settings.ThreadMode)) > 50 Then
            ThreadMode = 0
        Else
            ThreadMode = IIf(ThreadMode > 0, ThreadMode, My.Settings.ThreadMode)
        End If
        If IsNumeric(My.Settings.MaxBatchSize) = False OrElse CInt(IsNumeric(My.Settings.MaxBatchSize)) < 0 OrElse CInt(IsNumeric(My.Settings.MaxBatchSize)) > 10 Then
            MaxBatchSize = 10
        Else
            MaxBatchSize = IIf(MaxBatchSize < 0, My.Settings.MaxBatchSize, MaxBatchSize)
        End If
        If IsNumeric(My.Settings.InvockPersecond) = False OrElse CInt(IsNumeric(My.Settings.InvockPersecond)) < 0 OrElse CInt(IsNumeric(My.Settings.InvockPersecond)) > 10 Then
            InvockPersecond = 10
        Else
            InvockPersecond = IIf(InvockPersecond < 0, My.Settings.InvockPersecond, InvockPersecond)
        End If
        If Usercode = "" Or Password = "" Then
            Throw New SoapException("用户名或密码为空。", SoapException.ServerFaultCode)
        End If
        If IP = "" Then IP = GetIP()
        If MAC = "" Then MAC = GetMacAddress()
        If DISCKID = "" Then DISCKID = GetDiskID()
        If CPUID = "" Then CPUID = GetCpuID()
    End Sub
    <WebMethod()> _
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessageByRecipientsString(RecipientsSource As String, Content As String) As Integer
        Dim Usercode As String, Password As String, _
                                CallbackURL As String, ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean

        InitializeParameter(Usercode, Password, CallbackURL, ThreadMode, MaxBatchSize, InvockPersecond)
        KLMessage = New KLMessage.SendMessageCore
        KLMessage.SendMessage(Guid.NewGuid().ToString, "", 0, Usercode, Password, _
                              RecipientsSource.Split(";"), Content, CallbackURL, ThreadMode, _
                              MaxBatchSize, InvockPersecond, False, False, False, IP, MAC, CPUID, DISCKID, My.Computer.Name, My.User.Name)

    End Function
    '全部使用默认设置
    <WebMethod()> _
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(RecipientsSource() As String, Content As String) As Integer
        Dim Usercode As String, Password As String, _
                                CallbackURL As String, ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean

        InitializeParameter(Usercode, Password, CallbackURL, ThreadMode, MaxBatchSize, InvockPersecond)
        KLMessage = New KLMessage.SendMessageCore
        KLMessage.SendMessage(Guid.NewGuid().ToString, "", 0, Usercode, Password, _
                              RecipientsSource, Content, CallbackURL, ThreadMode, _
                              MaxBatchSize, InvockPersecond, False, False, False, IP, MAC, CPUID, DISCKID, My.Computer.Name, My.User.Name)

    End Function
    '全部使用默认设置，但附带上用户自定义的消息ID
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(UserMessageID As String, RecipientsSource() As String, Content As String) As Integer
        Dim Usercode As String, Password As String, _
                                CallbackURL As String, ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean

        InitializeParameter(Usercode, Password, CallbackURL, ThreadMode, MaxBatchSize, InvockPersecond)
        KLMessage = New KLMessage.SendMessageCore
        KLMessage.SendMessage(UserMessageID, "", 0, Usercode, Password, _
                              RecipientsSource, Content, CallbackURL, ThreadMode, _
                              MaxBatchSize, InvockPersecond, False, False, False, IP, MAC, CPUID, DISCKID, My.Computer.Name, My.User.Name)
    End Function
    '当客户有多个用户名时，可以指定用户名发送，其他配置使用默认设置
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(Usercode As String, Password As String, RecipientsSource() As String, Content As String) As Integer
        Dim CallbackURL As String, ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean

        InitializeParameter(Usercode, Password, CallbackURL, ThreadMode, MaxBatchSize, InvockPersecond)
        KLMessage = New KLMessage.SendMessageCore
        KLMessage.SendMessage(Guid.NewGuid().ToString, "", 0, Usercode, Password, _
                              RecipientsSource, Content, CallbackURL, ThreadMode, _
                              MaxBatchSize, InvockPersecond, False, False, False, IP, MAC, CPUID, DISCKID, My.Computer.Name, My.User.Name)
    End Function
    '当客户有多个用户名时，可以指定用户名发送，并且携带自定义的消息ID，其他配置使用默认设置
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(Usercode As String, Password As String, UserMessageID As String, RecipientsSource() As String, Content As String) As Integer
        Dim CallbackURL As String, ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean

        InitializeParameter(Usercode, Password, CallbackURL, ThreadMode, MaxBatchSize, InvockPersecond)
        KLMessage = New KLMessage.SendMessageCore
        KLMessage.SendMessage(UserMessageID, "", 0, Usercode, Password, _
                              RecipientsSource, Content, CallbackURL, ThreadMode, _
                              MaxBatchSize, InvockPersecond, False, False, False, IP, MAC, CPUID, DISCKID, My.Computer.Name, My.User.Name)
    End Function

    'ThreadMode：0 自动线程，使用线程池 1：单线程 其他值：指定线程数
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(UserMessageID As String, Usercode As String, Password As String, RecipientsSource() As String, Content As String, _
                                CallbackURL As String, ThreadMode As Integer, MaxBatchSize As Integer, InvockPersecond As Double, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean) As Integer

        InitializeParameter(Usercode, Password, CallbackURL, ThreadMode, MaxBatchSize, InvockPersecond)
        KLMessage = New KLMessage.SendMessageCore
        KLMessage.SendMessage(UserMessageID, "", 0, Usercode, Password, _
                              RecipientsSource, Content, CallbackURL, ThreadMode, _
                              MaxBatchSize, InvockPersecond, Simulation, Simulation, RecordLog, IP, MAC, CPUID, DISCKID, My.Computer.Name, My.User.Name)
    End Function

    Private Sub KLMessage_BeginSendMessage(UserMessageID As String, SessionID As String, TotalCount As Long, StartTime As Long) Handles KLMessage.BeginSendMessage

    End Sub

    Private Sub KLMessage_ReportInformation(Status As Long, Information As String, Param As Object) Handles KLMessage.ReportInformation

    End Sub

    Private Sub KLMessage_ReportMessageStatus(SendEvent As KLMessage.SendMessageCore.enumSendEvent, MessageInfo As KLMessage.MessageInfo) Handles KLMessage.ReportMessageStatus

    End Sub

    Private Sub KLMessage_ReportProgress(UserMessageID As String, SessionID As String, TotalCount As ULong, SendCount As ULong, SuccessedCount As Long, SpentTime As ULong, Information As String) Handles KLMessage.ReportProgress

    End Sub

    Private Sub KLMessage_SendCompeleted(UserMessageID As String, SessionID As String, TotalCount As ULong, SendCount As ULong, SuccessedCount As Long, SpentTime As ULong, Status As Long) Handles KLMessage.SendCompeleted

    End Sub
End Class