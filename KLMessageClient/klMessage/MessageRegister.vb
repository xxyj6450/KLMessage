Imports System.Runtime.Remoting.Messaging
Public Class MessageRegister
    Private Shared _Connections As New System.Collections.Generic.Dictionary(Of String, Long)

    Private Shared _objRegServer As RegServer.RegisterService
    Public Delegate Function getConnectionID_Delegate(ConnectionID As String, RegisterUsercode As String, RegisterPassword As String, Refresh As Boolean, MaxRetryTimes As Integer) As Long
    
    Public Shared Property objRegServer As RegServer.RegisterService
        Get
            If _objRegServer Is Nothing Then _objRegServer = New RegServer.RegisterService
            Return _objRegServer
        End Get
        Set(value As RegServer.RegisterService)

        End Set
    End Property
    Public Shared Function BeginGetConnectionID(ConnectionID As String, RegisterUsercode As String, RegisterPassword As String, Refresh As Boolean, MaxRetryTimes As Integer, _
                                         asynCallback As System.AsyncCallback, Param As Object) As Long
        Dim f As New getConnectionID_Delegate(AddressOf getConnectionID)
        f.BeginInvoke(ConnectionID, RegisterUsercode, RegisterPassword, Refresh, MaxRetryTimes, asynCallback, Param)
        Return 0
    End Function
    Public Shared Function getConnectionID(ConnectionID As String, RegisterUsercode As String, RegisterPassword As String, Optional Refresh As Boolean = False, Optional MaxRetryTimes As Integer = 3) As Long

        Dim connID As String, rand As String, ret As Int32, ExistsKey As Boolean
        Dim RetryTimes As Long, t As Long, Start As Long
        t = Environment.TickCount
        Start = t

        ExistsKey = _Connections.ContainsKey(RegisterUsercode)
        If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:查找键" & RegisterUsercode & "用时" & Environment.TickCount - t & "结果" & ExistsKey)
        '对于已经存在键值,而且与原来键值不一样的,直接返回最新的键值
        If ExistsKey = True AndAlso ConnectionID <> _Connections(RegisterUsercode) Then
            If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:查找键" & RegisterUsercode & "已存在新值" & _Connections(RegisterUsercode) & "用时" & Environment.TickCount - t & "结果" & ExistsKey)
            Return _Connections(RegisterUsercode)
        End If


        If ExistsKey = False Then Refresh = True
        If Refresh = True Then
            objRegServer.Timeout = 15000
            '加上锁
            SyncLock _Connections
                If _Connections.ContainsKey(RegisterUsercode) AndAlso ConnectionID <> _Connections(RegisterUsercode) Then
                    If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:查找键" & RegisterUsercode & "已存在新值" & _Connections(RegisterUsercode) & "用时" & Environment.TickCount - t & "无需刷新")
                    Return _Connections(RegisterUsercode)
                End If
start:
                t = Environment.TickCount
                rand = objRegServer.getRandom()
                connID = objRegServer.setCallBackAddr(RegisterUsercode, SOP.Security.Security.HashAlgorithm(rand & RegisterPassword & RegisterPassword, "md5", "UTF-8"), rand, "http://218.16.64.234:802/webservice.asmx")
                If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:获取" & RegisterUsercode & "用时" & Environment.TickCount - t & "返回" & connID)
                '若返回的CONNID小于0,则说明获取失败,不再加入_Connections,直接返回异常值
                If connID < 0 Then
                    If RetryTimes < MaxRetryTimes Then
                        RetryTimes = RetryTimes + 1
                        If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:重试" & RegisterUsercode & "用时" & Environment.TickCount - t & "返回" & connID)
                        GoTo start
                    Else
                        If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:重试失败" & RegisterUsercode & "用时" & Environment.TickCount - t & "返回" & connID)
                        Throw New Exception("登录宽乐失败" & ret)
                        Return connID
                    End If

                End If

                '若值已经存在,则更新之,否则加入之
                If ExistsKey = True Then
                    _Connections(RegisterUsercode) = connID
                Else
                    _Connections.Add(RegisterUsercode, connID)
                End If
            End SyncLock
            If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:返回连接" & RegisterUsercode & "用时" & Environment.TickCount - Start & "返回" & connID)
            Return connID
        Else
            If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:返回连接" & RegisterUsercode & "用时" & Environment.TickCount - Start & "返回" & connID)
            Return _Connections(RegisterUsercode)
        End If

    End Function
    'Public Shared Function getConnectionID(RegisterUsercode As String, RegisterPassword As String, Optional Refresh As Boolean = False, Optional RefreshServer As Boolean = False) As Long
    '    Dim ws As SendMessage.myWebService
    '    Dim connID As String, rand As String, ret As Int32, ExistsKey As Boolean
    '    '加上锁
    '    SyncLock _Connections
    '        ExistsKey = _Connections.ContainsKey(RegisterUsercode)
    '        If ExistsKey = False Then Refresh = True
    '        If Refresh = True Then
    '            ws = New SendMessage.myWebService

    '            connID = ws.getConnectionID(RegisterUsercode, RegisterPassword, "", RefreshServer)
    '            '若返回的CONNID小于0,则说明获取失败,不再加入_Connections,直接返回异常值
    '            If connID <= 0 Then Return connID
    '            '若值已经存在,则更新之,否则加入之
    '            If ExistsKey = True Then
    '                _Connections(RegisterUsercode) = connID
    '            Else
    '                _Connections.Add(RegisterUsercode, connID)
    '            End If
    '            Return connID
    '        Else
    '            Return _Connections(RegisterUsercode)
    '        End If
    '    End SyncLock
    'End Function
    Public Shared Function getRandom() As Long

        Return objRegServer.getRandom()
    End Function

 
End Class
