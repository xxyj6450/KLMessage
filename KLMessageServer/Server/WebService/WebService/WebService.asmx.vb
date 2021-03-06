﻿Imports System.Web
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
    '<WebMethod()> _
    'Public Function FinishedSendMessage(Usercode As String, Password As String, Registerusercode As String, AccessUsercode As String, SessionID As String, MessageId As String, RecipientsCount As Long, _
    '                                    NetType As Integer, Status As Integer) As Integer
    '    FinishedSendMessage(Usercode, Password, Registerusercode, AccessUsercode, SessionID, MessageId, NetType, Status, "")
    'End Function

    <WebMethod()> _
    Public Function FinishedSendMessage(Usercode As String, Password As String, Registerusercode As String, AccessUsercode As String, SessionID As String, MessageId As String, RecipientsCount As Long, _
                                        NetType As Integer, Status As Integer, ErrorText As String) As Integer
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
                .Parameters.Add("@ErrorText", SqlDbType.VarChar, 200).Value = ErrorText
                .ExecuteNonQuery()
                Return 0
            End With

        End Using
    End Function
    <WebMethod()> _
    Public Function FinishedSendMessageQueue(Usercode As String, Password As String, Registerusercode As String, AccessUsercode As String, _
                                             SessionID As String, MessageId As String, QueueID As String, RecipientsCount As Long, _
                                        NetType As Integer, Status As Integer, ErrorText As String) As Integer
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
                .Parameters.Add("@QueueID", SqlDbType.VarChar, 50).Value = QueueID
                .Parameters.Add("@Status", SqlDbType.VarChar).Value = Status
                .Parameters.Add("@RecipientsCount", SqlDbType.Int).Value = RecipientsCount
                .Parameters.Add("@RegisterUsercode", SqlDbType.VarChar, 50).Value = Registerusercode
                .Parameters.Add("@AccessUsercode", SqlDbType.VarChar, 50).Value = AccessUsercode
                .Parameters.Add("@ErrorText", SqlDbType.VarChar, 200).Value = ErrorText
                .ExecuteNonQuery()
                Return 0
            End With

        End Using
    End Function
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
    Public Function AddNewMessageQueue(Usercode As String, Password As String, SessionID As String, RecipientCount As Long, _
                                       Nettype As Integer, Content As String, MessageType As Integer, QueueID As String, _
                                  IP As String, MAC As String, ComputerName As String, ComputerUserName As String, _
                                  CPUID As String, DisckID As String) As System.Data.DataTable
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
                .Parameters.Add("@QueueID", SqlDbType.VarChar, 50).Value = QueueID
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
    Public Function getData(Usercode As String, Password As String, QueryString As CommonLib.Command) As System.Data.DataSet

        If QueryString Is Nothing Then Throw New Exception("查询参数不能为空") : Return Nothing
        Using conn As System.Data.SqlClient.SqlConnection = getConnection()
            conn.Open()
            Dim ds As New System.Data.DataSet, da As New System.Data.SqlClient.SqlDataAdapter(QueryString.getCommand())
            da.SelectCommand.Connection = conn
            da.Fill(ds)
            conn.Close()
            Return ds
        End Using

    End Function
    <WebMethod()> _
    Public Function Execute(Usercode As String, Password As String, Command As CommonLib.Command) As System.Data.DataSet

        If Command Is Nothing Then Throw New Exception("查询参数不能为空") : Return Nothing
        Using conn As System.Data.SqlClient.SqlConnection = getConnection()
            conn.Open()
            Dim ds As New System.Data.DataSet, da As New System.Data.SqlClient.SqlDataAdapter(Command.getCommand())
            da.SelectCommand.Connection = conn
            da.Fill(ds)
            conn.Close()
            Return ds
        End Using

    End Function
    '<WebMethod(Me)> _
    'Public Function getData(Usercode As String, Password As String, QueryString As String) As System.Data.DataSet

    '    If QueryString = "" Then Throw New Exception("查询参数不能为空") : Return Nothing
    '    Using conn As System.Data.SqlClient.SqlConnection = getConnection()
    '        conn.Open()
    '        Dim ds As New System.Data.DataSet, da As New System.Data.SqlClient.SqlDataAdapter(QueryString, conn)
    '        da.Fill(ds)
    '        conn.Close()
    '        Return ds
    '    End Using

    'End Function
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
    ''' <summary>
    ''' 根据客户端版本检测获取系统最新版本
    ''' </summary>
    ''' <param name="OperationSystem">客户端操作系统</param>
    ''' <param name="VersionID">客户端版本</param>
    ''' <param name="CoreVersion">客户端内核版本</param>
    ''' <returns>返回Datatable,包含最新版本信息</returns>
    ''' <remarks>只返回与客户端操作系统,版本相对应的更新信息</remarks>
    <WebMethod()> _
    Public Function GetNewVersion(OperationSystem As Integer, VersionID As String, CoreVersion As String) As System.Data.DataTable
        Dim dt As System.Data.DataTable
        Using conn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)
            conn.Open()
            Dim cmd As System.Data.SqlClient.SqlCommand = New SqlClient.SqlCommand("sp_GetNewVersion", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@OperationSystem", SqlDbType.Int).Value = OperationSystem
                .Parameters.Add("@Version", SqlDbType.VarChar, 50).Value = VersionID
            End With
            Try
                Using dr As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)
                    If dr.HasRows Then
                        dt = New System.Data.DataTable("T_Version")
                        dt.Load(dr)
                        Return dt
                    Else
                        Return Nothing
                    End If
                End Using
            Catch ex As Exception
                Throw (New SoapException(ex.Message, SoapException.ServerFaultCode))
                Return Nothing
            End Try

        End Using
    End Function
    ''' <summary>
    ''' 获取更新日志
    ''' </summary>
    ''' <param name="OperationSystem">客户端操作系统</param>
    ''' <param name="VersionID">客户端版本</param>
    ''' <param name="CoreVersion">客户端内核版本</param>
    ''' <returns>返回更新日志</returns>
    ''' <remarks>只返回与客户端版本相对应的更新日志</remarks>
    <WebMethod()> _
    Public Function GetUpgrageLog(OperationSystem As Integer, VersionID As String, CoreVersion As String) As System.Data.DataTable
        Dim dt As System.Data.DataTable
        Using conn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)
            conn.Open()
            Dim cmd As System.Data.SqlClient.SqlCommand = New SqlClient.SqlCommand("GetUpgrageLog", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@OperationSystem", SqlDbType.Int).Value = OperationSystem
                .Parameters.Add("@Version", SqlDbType.VarChar, 50).Value = VersionID
            End With
            Try
                Using dr As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)
                    If dr.HasRows Then
                        dt = New System.Data.DataTable("T_Version")
                        dt.Load(dr)
                        Return dt
                    Else
                        Return Nothing
                    End If
                End Using
            Catch ex As Exception
                Throw (New SoapException(ex.Message, SoapException.ServerFaultCode))
                Return Nothing
            End Try

        End Using
    End Function
End Class