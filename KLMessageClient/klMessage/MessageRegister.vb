Imports System.Runtime.Remoting.Messaging
Public Class MessageRegister
    Private Shared _Connections As New System.Collections.Generic.Dictionary(Of String, Long)
    Private rwLock As New System.Threading.ReaderWriterLock
    Public Delegate Function getConnectionID_Delegate(RegisterUsercode As String, RegisterPassword As String, Refresh As Boolean) As Long
    Public Shared Function BeginGetConnectionID(RegisterUsercode As String, RegisterPassword As String, Refresh As Boolean, _
                                         asynCallback As System.AsyncCallback, Param As Object) As Long
        Dim f As New getConnectionID_Delegate(AddressOf getConnectionID)
        f.BeginInvoke(RegisterUsercode, RegisterPassword, Refresh, asynCallback, Param)
        Return 0
    End Function
    Public Shared Function getConnectionID(RegisterUsercode As String, RegisterPassword As String, Optional Refresh As Boolean = False) As Long
        Dim ws As RegServer.RegisterService
        Dim connID As String, rand As String, ret As Int32, ExistsKey As Boolean
        '加上锁
        SyncLock _Connections
            ExistsKey = _Connections.ContainsKey(RegisterUsercode)
            If ExistsKey = False Then Refresh = True
            If Refresh = True Then
                ws = New RegServer.RegisterService
                rand = ws.getRandom()
                connID = ws.setCallBackAddr(RegisterUsercode, SOP.Security.Security.HashAlgorithm(rand & RegisterPassword & RegisterPassword, "md5", "UTF-8"), rand, "http://218.16.64.234:802/webservice.asmx")
                '若返回的CONNID小于0,则说明获取失败,不再加入_Connections,直接返回异常值
                If connID < 0 Then Return connID
                '若值已经存在,则更新之,否则加入之
                If ExistsKey = True Then
                    _Connections(RegisterUsercode) = connID
                Else
                    _Connections.Add(RegisterUsercode, connID)
                End If
                Return connID
            Else
                Return _Connections(RegisterUsercode)
            End If
        End SyncLock
    End Function
 
    Public Shared Function getRandom() As Long

        Return (New RegServer.RegisterService).getRandom()
    End Function


End Class
