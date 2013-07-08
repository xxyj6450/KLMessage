Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Services.Description
Imports System.Data

<WebService(Namespace:="http://xxyj6450.s181.288idc.com/WebService.asmx")> _
<SoapDocumentService(RoutingStyle:=SoapServiceRoutingStyle.RequestElement, Use:=SoapBindingUse.Literal)> _
<WebServiceBinding(ConformsTo:=WsiProfiles.None)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class RecieveMessageServices
    Inherits System.Web.Services.WebService

    <WebMethod()> _
        <SoapRpcMethod(Action:="NotifyStatus", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Sub NotifyStatus(eventID As Integer, sessionID As String, res As Int32, para1 As String)
        'WriteLog("收到回执>eventID:" & eventID & ",sessionID:" & sessionID & ",res:" & res & ",para1:" & para1)
        KLMessage.SendMessageCore.NotifyStatus(eventID, sessionID, res, para1)
        Dim cmd As System.Data.OleDb.OleDbCommand
        '身份验证
        Using conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)

            conn.Open()
            cmd = New System.Data.OleDb.OleDbCommand("sp_NotifyStatus", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@eventID", OleDb.OleDbType.BigInt).Value = eventID
                .Parameters.Add("@sessionID", OleDb.OleDbType.BigInt).Value = sessionID
                .Parameters.Add("@res", OleDb.OleDbType.BigInt).Value = res
                .Parameters.Add("@para1", OleDb.OleDbType.VarChar).Value = para1
                .ExecuteNonQuery()
            End With
            conn.Close()
        End Using
    End Sub
    <WebMethod()> _
    <SoapRpcMethod(Action:="EchoOfSendSMS", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Sub EchoOfSendSMS(ucNum As String, cee As String, msgid As Integer, res As Integer, recvt As String)
        'WriteLog("收到响应>ucNum:" & ucNum & ",cee:" & cee & ",msgid:" & msgid & ",res:" & res & ",recvt:" & recvt)
        KLMessage.SendMessageCore.EchoOfSendSMS(ucNum, cee, msgid, res, recvt)
        Dim cmd As System.Data.OleDb.OleDbCommand
        '身份验证
        Using conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)

            conn.Open()
            cmd = New System.Data.OleDb.OleDbCommand("sp_EchoOfMessage", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@MessageID", OleDb.OleDbType.BigInt).Value = msgid
                .Parameters.Add("@Recipient", OleDb.OleDbType.VarChar).Value = cee
                .Parameters.Add("@RegisterUsercode", OleDb.OleDbType.VarChar).Value = ucNum
                .Parameters.Add("@Status", OleDb.OleDbType.BigInt).Value = res
                .Parameters.Add("@MessageDate", OleDb.OleDbType.Date).Value = New DateTime(Left(recvt, 4), Mid(recvt, 5, 2), Mid(recvt, 7, 2), Mid(recvt, 9, 2), Mid(recvt, 11, 2), Mid(recvt, 13, 2))
                .ExecuteNonQuery()
            End With
            conn.Close()
        End Using
    End Sub
    <WebMethod()> _
    <SoapRpcMethod(Action:="RecvSMS", RequestNamespace:="", Use:=SoapBindingUse.Literal)> _
    Public Function RecvSMS(caller As String, time As String, cont As String, ucNum As String) As String
        KLMessage.SendMessageCore.RecvSMS(caller, time, cont, ucNum)
        ' WriteLog("收到回复>caller:" & caller & ",time:" & time & ",cont:" & cont & ",ucNum:" & ucNum)
        Dim cmd As System.Data.OleDb.OleDbCommand
        '身份验证
        Using conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Web.Configuration.WebConfigurationManager.ConnectionStrings("dbcon").ConnectionString)

            conn.Open()
            cmd = New OleDb.OleDbCommand("sp_RecieveMessage", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add("@caller", OleDb.OleDbType.VarChar, 50).Value = caller
                .Parameters.Add("@Content", OleDb.OleDbType.VarChar).Value = cont
                .Parameters.Add("@RegisterUsercode", OleDb.OleDbType.VarChar).Value = ""
                .Parameters.Add("@MessageDate", OleDb.OleDbType.DBTime).Value = New DateTime(Left(time, 4), Mid(time, 5, 2), Mid(time, 7, 2), Mid(time, 9, 2), Mid(time, 11, 2), Mid(time, 13, 2))
                .ExecuteNonQuery()
            End With
            conn.Close()
        End Using
        Return "0"
    End Function

End Class