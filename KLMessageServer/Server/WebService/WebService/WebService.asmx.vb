Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Services.Description
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Xml.Serialization
Imports System.Xml
Imports System.Runtime.Remoting.Messaging
'若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
'<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://xxyj6450.s181.288idc.com/WebService.asmx")> _
<SoapDocumentService(RoutingStyle:=SoapServiceRoutingStyle.RequestElement, Use:=SoapBindingUse.Literal)> _
<WebServiceBinding(ConformsTo:=WsiProfiles.None)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class myWebService
    Inherits System.Web.Services.WebService
    Private Shared _Connections As New System.Collections.Generic.Dictionary(Of String, Long)
    Private Const CALLBACK_URL As String = "http://218.16.64.234:802/webservice.asmx"
    '    <WebMethod()> _
    '       <SoapRpcMethod(Action:="getConnectionID", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    '    Public Function getConnectionID(RegisterUsercode As String, RegisterPassword As String, CallbackURL As String, Refresh As Boolean) As Long
    '        Dim ws As RegServer.RegisterService
    '        Dim connID As String, rand As String, ret As Int32, ExistsKey As Boolean
    '        Dim RetryTimes As Long
    '        '加上锁
    '        SyncLock _Connections
    '            ExistsKey = _Connections.ContainsKey(RegisterUsercode)
    '            If ExistsKey = False Then Refresh = True
    '            If Refresh = True Then
    '                ws = New RegServer.RegisterService
    'Start:

    '                rand = ws.getRandom()
    '                If CallbackURL = "" Then CallbackURL = CALLBACK_URL
    '                connID = ws.setCallBackAddr(RegisterUsercode, SOP.Security.Security.HashAlgorithm(rand & RegisterPassword & RegisterPassword, "md5", "UTF-8"), rand, CallbackURL)
    '                '若返回的CONNID小于0,则说明获取失败,不再加入_Connections,直接返回异常值
    '                If connID < 0 Then
    '                    If RetryTimes < 3 Then
    '                        RetryTimes = RetryTimes + 1
    '                        GoTo Start
    '                    Else
    '                        Throw New SoapException("登录宽乐平台失败" & connID, SoapException.ServerFaultCode)
    '                        Return connID
    '                    End If
    '                Else
    '                    '若值已经存在,则更新之,否则加入之
    '                    If ExistsKey = True Then
    '                        _Connections(RegisterUsercode) = connID
    '                    Else
    '                        _Connections.Add(RegisterUsercode, connID)
    '                    End If
    '                    Return connID
    '                End If

    '            Else
    '                Return _Connections(RegisterUsercode)
    '            End If
    '        End SyncLock
    '    End Function

    '    Private Shared Function getRandom() As Long

    '        Return (New RegServer.RegisterService).getRandom()
    '    End Function
    <WebMethod()> _
    <SoapRpcMethod(Action:="NotifyStatus", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Sub NotifyStatus(eventID As Integer, sessionID As String, res As Int32, para1 As String)
        'WriteLog("收到回执>eventID:" & eventID & ",sessionID:" & sessionID & ",res:" & res & ",para1:" & para1)
        Dim cmd As System.Data.SqlClient.SqlCommand
        '身份验证
        Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)

            conn.Open()
            cmd = New SqlCommand("sp_NotifyStatus", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@eventID", SqlDbType.Int).Value = eventID
                .Parameters.Add("@sessionID", SqlDbType.Int).Value = sessionID
                .Parameters.Add("@res", SqlDbType.Int).Value = res
                .Parameters.Add("@para1", SqlDbType.VarChar).Value = para1
                .ExecuteNonQuery()
            End With
            conn.Close()
        End Using
    End Sub
    <WebMethod()> _
    <SoapRpcMethod(Action:="EchoOfSendSMS", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Sub EchoOfSendSMS(ucNum As String, cee As String, msgid As Integer, res As Integer, recvt As String)
        'WriteLog("收到响应>ucNum:" & ucNum & ",cee:" & cee & ",msgid:" & msgid & ",res:" & res & ",recvt:" & recvt)
        Dim cmd As System.Data.SqlClient.SqlCommand
        '身份验证
        Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)

            conn.Open()
            cmd = New SqlCommand("sp_EchoOfMessage", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@MessageID", SqlDbType.Int).Value = msgid
                .Parameters.Add("@Recipient", SqlDbType.VarChar).Value = cee
                .Parameters.Add("@RegisterUsercode", SqlDbType.VarChar).Value = ucNum
                .Parameters.Add("@Status", SqlDbType.Int).Value = res
                .Parameters.Add("@MessageDate", SqlDbType.DateTime).Value = New DateTime(Left(recvt, 4), Mid(recvt, 5, 2), Mid(recvt, 7, 2), Mid(recvt, 9, 2), Mid(recvt, 11, 2), Mid(recvt, 13, 2))
                .ExecuteNonQuery()
            End With
            conn.Close()
        End Using
    End Sub
    <WebMethod()> _
    <SoapRpcMethod(Action:="RecvSMS", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function RecvSMS(caller As String, time As String, cont As String, ucNum As String) As String
        ' WriteLog("收到回复>caller:" & caller & ",time:" & time & ",cont:" & cont & ",ucNum:" & ucNum)
        Dim cmd As System.Data.SqlClient.SqlCommand
        '身份验证
        Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)

            conn.Open()
            cmd = New SqlCommand("sp_RecieveMessage", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@caller", SqlDbType.VarChar).Value = caller
                .Parameters.Add("@Content", SqlDbType.VarChar).Value = cont
                .Parameters.Add("@RegisterUsercode", SqlDbType.VarChar).Value = ucNum
                .Parameters.Add("@MessageDate", SqlDbType.DateTime).Value = New DateTime(Left(time, 4), Mid(time, 5, 2), Mid(time, 7, 2), Mid(time, 9, 2), Mid(time, 11, 2), Mid(time, 13, 2))
                .ExecuteNonQuery()
            End With
            conn.Close()
        End Using
        Return "0"
    End Function
    <WebMethod()> _
    <SoapRpcMethod(Action:="SendMessage", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function SendMessage(Usercode As String, Password As String, Recipients As String, RecipientsCount As Integer, SessionID As String, _
                                RegisterUsercode As String, AccessUsercode As String, _
                                CONNID As Long, Nettype As Integer) As Long
        Dim cmd As System.Data.SqlClient.SqlCommand, MessageID As Long, Param As System.Data.SqlClient.SqlParameter
        '身份验证
        Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)

            conn.Open()
            cmd = New SqlCommand("sp_SendMessage", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Usercode
                .Parameters.Add("@Recipients", SqlDbType.VarChar).Value = Recipients
                .Parameters.Add("@SessionID", SqlDbType.VarChar, 50).Value = SessionID
                .Parameters.Add("@RegisterUsercode", SqlDbType.VarChar).Value = RegisterUsercode
                .Parameters.Add("@AccessUsercode", SqlDbType.VarChar, 50).Value = AccessUsercode
                .Parameters.Add("@CONNID", SqlDbType.BigInt).Value = CONNID
                .Parameters.Add("@Nettype", SqlDbType.Int).Value = Nettype
                .Parameters.Add("@RecipientsCount", SqlDbType.Int).Value = RecipientsCount
                Param = .Parameters.Add("@MessageID", SqlDbType.Int)
                Param.Direction = ParameterDirection.InputOutput
                .ExecuteNonQuery()
                System.Console.Write(Param.Value)
                Return Param.Value
            End With

        End Using

    End Function
    <WebMethod()> _
    Public Function FinishedSendMessage(Usercode As String, Password As String, Registerusercode As String, AccessUsercode As String, SessionID As String, MessageId As String, RecipientsCount As Long, _
                                        NetType As Integer, Status As Integer) As Integer
        Dim cmd As System.Data.SqlClient.SqlCommand
        '身份验证
        Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)
            conn.Open()
            cmd = New SqlCommand("sp_FinishedSendMessage", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = Usercode
                .Parameters.Add("@SessionID", SqlDbType.VarChar, 50).Value = SessionID
                .Parameters.Add("@MessageID", SqlDbType.Int).Value = MessageId
                .Parameters.Add("@NetType", SqlDbType.Int).Value = NetType
                .Parameters.Add("@Status", SqlDbType.VarChar).Value = Status
                .Parameters.Add("@RecipientsCount", SqlDbType.Int).Value = RecipientsCount
                .Parameters.Add("@RegisterUsercode", SqlDbType.VarChar, 50).Value = Registerusercode
                .Parameters.Add("@AccessUsercode", SqlDbType.VarChar, 50).Value = AccessUsercode
                .ExecuteNonQuery()
                Return 0
            End With

        End Using
    End Function
    '    <WebMethod()> _
    '    Public Function MatchAccounts(Usercode As String, Password As String, Recipients As String, Content As String) As Integer
    '        Dim SessionID As String = Guid.NewGuid.ToString, dt As System.Data.DataTable, MessageID As Long, CONNID As Long
    '        Dim ws1 As New SendServer.SendSMSService, rand As Long, ret As Long, Count As Long
    '        Dim RegisterUsercode As String, RegisterPassword As String, AccessUsercode As String, AccessPassword As String
    '        Dim CallbackNumber As String
    '        dt = AddNewMessage(Usercode, Password, SessionID, 1, 0, Content, 1, "", "", "", "", "", "")
    '        For Each row As System.Data.DataRow In dt.Rows
    '            RegisterUsercode = row("RegisterUsercode")
    '            RegisterPassword = row("RegisterPassword")
    '            AccessUsercode = row("AccessUsercode")
    '            AccessPassword = row("AccessPassword")
    '            CallbackNumber = row("TEL")
    '            MessageID = SendMessage(Usercode, Password, Recipients, 1, SessionID, row("RegisterUsercode"), row("AccessUsercode"), CONNID, 0)
    'BeginSend:
    '            CONNID = getConnectionID(RegisterUsercode, RegisterPassword)
    '            rand = getRandom()
    '            ret = ws1.sendSMS(AccessUsercode, SOP.Security.Security.HashAlgorithm(rand & AccessPassword & AccessPassword, "md5", "UTF-8"), rand, Recipients.Split(":"), "1", SOP.Security.Security.Base64Encode(Content, ""), MessageID, CONNID)
    '            If ret = -7 And Count <= 5 Then
    '                Count = Count + 1
    '                getConnectionID(RegisterUsercode, RegisterPassword, True)
    '                GoTo BeginSend
    '            End If
    '            FinishedSendMessage(Usercode, Password, RegisterUsercode, AccessUsercode, SessionID, MessageID, 1, 0, ret)
    '        Next
    '        '若任务发起人有留下电话号码,而且上面的短信发送完毕,则给一个回复
    '        If Len(CallbackNumber) = 11 And CONNID > 0 Then
    '            Try
    '                ws1.sendSMS(RegisterUsercode, SOP.Security.Security.HashAlgorithm(rand & RegisterPassword & RegisterPassword, "md5", "UTF-8"), rand, CallbackNumber.Split(":"), "1", SOP.Security.Security.Base64Encode("您启动的帐户匹配任务已经完成,请进入账户管理中查看结果.", ""), 0, CONNID)
    '                MatchAccountsManual(Usercode, Password)
    '            Catch ex As Exception

    '            End Try
    '        End If
    '        Return ret
    '    End Function
    <WebMethod()> _
    Public Function MatchAccountsManual(Usercode As String, Password As String) As Integer

        Try
            Using conn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)
                conn.Open()
                Dim cmd As System.Data.SqlClient.SqlCommand = New SqlClient.SqlCommand("sp_MatchAccount", conn)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .ExecuteNonQuery()
                End With
            End Using
        Catch ex As Exception

        End Try

    End Function
    <WebMethod()> _
    Public Function AddNewMessage(Usercode As String, Password As String, SessionID As String, RecipientCount As Long, Nettype As Integer, Content As String, MessageType As Integer, _
                                  IP As String, MAC As String, ComputerName As String, ComputerUserName As String, CPUID As String, DisckID As String) As System.Data.DataTable
        Dim dt As New System.Data.DataTable, NetworkIP As String
        dt.TableName = "Account"
        If NetworkIP = "" Then
            If Not (System.Web.HttpContext.Current.Request.ServerVariables("HTTP_VIA") Is Nothing) Then
                NetworkIP = System.Web.HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR").ToString
            Else
                NetworkIP = System.Web.HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString
            End If
        End If
        Using conn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)
            conn.Open()
            Dim cmd As System.Data.SqlClient.SqlCommand = New SqlClient.SqlCommand("sp_AddNewMessage", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@Usercode", Usercode)
                .Parameters.AddWithValue("@SessionID", SessionID)
                .Parameters.AddWithValue("@RecipientCount", RecipientCount)
                .Parameters.AddWithValue("@Nettype", Nettype)
                .Parameters.AddWithValue("IP", IP)
                .Parameters.AddWithValue("@Content", Content)
                .Parameters.AddWithValue("@MAC", MAC)
                .Parameters.AddWithValue("@ComputerName", ComputerName)
                .Parameters.AddWithValue("@ComputerUserName", ComputerUserName)
                .Parameters.AddWithValue("@NetworkIP", NetworkIP)
                .Parameters.AddWithValue("@CPUID", CPUID)
                .Parameters.AddWithValue("@DisckID", DisckID)
                .Parameters.AddWithValue("@MessageType", MessageType)
                .CommandTimeout = 600
                dt.Load(.ExecuteReader(CommandBehavior.CloseConnection))
                Return dt
            End With
        End Using
    End Function
    <WebMethod()> _
    Public Function Login(Usercode As String, Password As String, Version As String, IP As String, MAC As String, CPUID As String, DISCKID As String, COMPUTERNAME As String, ComputerUserName As String, Options As String) As System.Data.DataTable
        Dim sql As String, dt As System.Data.DataTable
        If Usercode = "" Or Password = "" Then
            Throw (New SoapException("用户名或密码不能为空.", SoapException.ServerFaultCode))
            Return Nothing
        End If
        Using conn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)
            conn.Open()
            Dim cmd As System.Data.SqlClient.SqlCommand = New SqlClient.SqlCommand("sp_CheckLogin", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@usercode", Usercode)
                .Parameters.AddWithValue("@password", Password)
                .Parameters.Add("@VersionID", SqlDbType.VarChar, 50).Value = Version
                .Parameters.Add("@IP", SqlDbType.VarChar, 50).Value = IP
                .Parameters.Add("@MAC", SqlDbType.VarChar, 50).Value = MAC
                .Parameters.Add("@CPUID", SqlDbType.VarChar, 50).Value = CPUID
                .Parameters.Add("@DISKID", SqlDbType.VarChar, 50).Value = DISCKID
                .Parameters.Add("@ComputerName", SqlDbType.VarChar, 50).Value = COMPUTERNAME
                .Parameters.Add("@ComputerUserName", SqlDbType.VarChar, 50).Value = ComputerUserName
            End With
            Try
                Using dr As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)
                    If dr.HasRows Then
                        dt = New System.Data.DataTable("T_UserInfo")
                        dt.Load(dr)

                        Return dt
                    Else
                        Throw (New SoapException("用户名或密码错误.", SoapException.ServerFaultCode))
                        Return Nothing
                    End If
                End Using
            Catch ex As Exception
                Throw (New SoapException(ex.Message, SoapException.ServerFaultCode))
                Return Nothing
            End Try

        End Using
    End Function
    <WebMethod()> _
    Public Function getData(Usercode As String, Password As String, QueryString As String) As System.Data.DataSet

        If QueryString = "" Then Throw New Exception("查询参数不能为空") : Return Nothing
        Using conn As System.Data.SqlClient.SqlConnection = getConnection()
            conn.Open()
            Dim ds As New System.Data.DataSet, da As New System.Data.SqlClient.SqlDataAdapter(QueryString, conn)
            da.Fill(ds)
            conn.Close()
            Return ds
        End Using

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="MetaQueryString"></param>
    ''' <param name="UpdateCommand">XML值 格式如下
    ''' <Command Name="UpdateCommand" CommandText="",CommandType="">
    ''' </Command>
    ''' </param>
    ''' <param name="InsertCommand"></param>
    ''' <param name="DeleteCommand"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <WebMethod()> _
    Public Function Update(Usercode As String, Password As String, ds As System.Data.DataSet, MetaQueryString As String, UpdateCommand As CommonLib.Command, InsertCommand As CommonLib.Command, DeleteCommand As CommonLib.Command) As System.Data.DataSet
        Dim da As System.Data.SqlClient.SqlDataAdapter
        Dim cb As System.Data.SqlClient.SqlCommandBuilder
        Dim sqlInsertCommand As System.Data.SqlClient.SqlCommand
        Dim sqlDeleteCommand As System.Data.SqlClient.SqlCommand
        Dim sqlUpdateCommand As System.Data.SqlClient.SqlCommand

        '若MetaQueryString为空 则后面三个command参数不能为nothing
        '若MetaQueryString不为空 则后面三个参数可以为Nothing
        If MetaQueryString = "" And (UpdateCommand Is Nothing Or InsertCommand Is Nothing Or DeleteCommand Is Nothing) Then
            Throw New Exception("MetaQueryString与UpdateCommand，InsertCommand，DeleteCommand不能同时为空")
            Return Nothing
        End If
        '获得数据连接
        Using conn As System.Data.SqlClient.SqlConnection = getConnection()
            conn.Open()
            '生成DataAdapter对象
            da = IIf(MetaQueryString = "", New System.Data.SqlClient.SqlDataAdapter(), New System.Data.SqlClient.SqlDataAdapter(MetaQueryString, conn))
            '若未提供UpdateCommand，InsertCommand，DeleteCommand，则用CommandBuilder建立之
            If (UpdateCommand Is Nothing Or InsertCommand Is Nothing Or DeleteCommand Is Nothing) Then
                cb = New System.Data.SqlClient.SqlCommandBuilder(da)
                If InsertCommand Is Nothing Then
                    da.InsertCommand = cb.GetInsertCommand
                Else
                    da.InsertCommand = InsertCommand.getCommand()
                End If
                If UpdateCommand Is Nothing Then
                    da.UpdateCommand = cb.GetUpdateCommand
                Else
                    da.UpdateCommand = UpdateCommand.getCommand()
                End If
                If DeleteCommand Is Nothing Then
                    da.DeleteCommand = cb.GetDeleteCommand
                Else
                    da.DeleteCommand = DeleteCommand.getCommand()
                End If
                'cb.GetInsertCommand()                                       '正常情况下commandbuilder会在dataAdapter.update时才构造command,调用这句以提前构造出更新的command结构 详见ADO.NET技术内幕398页
            Else
                'Dim xmlDoc As System.Xml.XmlDocument, xml As String, i As Long, j As Long, XMLNodes As System.Xml.XmlNodeList, CommandType As String, cmdParameters As SqlParameterCollection
                ''将三个命令连接到一起，统一处理。
                'xml = "<root>" & InsertCommand & UpdateCommand & DeleteCommand & "</root>"
                'xmlDoc = New System.Xml.XmlDocument
                'xmlDoc.LoadXml(xml)
                'XMLNodes = xmlDoc.SelectNodes("/root/Command")
                'For Each XMLNode As System.Xml.XmlNode In XMLNodes
                '    Dim objCommand As New System.Data.SqlClient.SqlCommand(XMLNode.Attributes("CommandText").Value)
                '    CommandType = XMLNode.Attributes("CommandType").Value
                '    '设置命令类型
                '    objCommand.CommandType = IIf(CommandType = "Text", Data.CommandType.Text, IIf(CommandType = "StoreProcedure", Data.CommandType.StoredProcedure, Data.CommandType.Text))
                '    If XMLNode.Attributes("Name").Value = "InsertCommand" Then sqlInsertCommand = objCommand : cmdParameters = InsertCommandParameters
                '    If XMLNode.Attributes("Name").Value = "UpdateCommand" Then sqlUpdateCommand = objCommand : cmdParameters = UpdateCommandParameters
                '    If XMLNode.Attributes("Name").Value = "DeleteCommand" Then sqlDeleteCommand = objCommand : cmdParameters = DeleteCommandParameters
                '    '为命令添加参数
                '    For Each param As SqlParameter In cmdParameters
                '        objCommand.Parameters.Add(param)
                '    Next
                'Next
                da.UpdateCommand = UpdateCommand.getCommand()
                da.InsertCommand = InsertCommand.getCommand()
                da.DeleteCommand = DeleteCommand.getCommand()
            End If

            '打开一个事务，用于更新数据
            Dim tran As System.Data.SqlClient.SqlTransaction = conn.BeginTransaction
            '设置事务和连接
            da.UpdateCommand.Connection = conn
            da.UpdateCommand.Transaction = tran
            da.InsertCommand.Connection = conn
            da.InsertCommand.Transaction = tran
            da.DeleteCommand.Connection = conn
            da.DeleteCommand.Transaction = tran
            da.Update(ds.Tables(0))
            tran.Commit()
            conn.Close()
        End Using
        'Return ds
    End Function
    Private Function getConnection() As System.Data.SqlClient.SqlConnection
        Return New System.Data.SqlClient.SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)
    End Function

    Private Sub WriteLog(Message As String)
        Dim f As System.IO.StreamWriter
        f = System.IO.File.AppendText(Server.MapPath("") & "\Log.txt")
        f.WriteLine(Message & ">>>" & Now.ToString)

        f.Flush()
        f.Close()
    End Sub
End Class