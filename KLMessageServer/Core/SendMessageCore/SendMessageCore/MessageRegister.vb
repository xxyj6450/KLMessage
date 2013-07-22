Imports System.Runtime.Remoting.Messaging
Friend Class MessageRegister
    Private Shared _Connections As New System.Collections.Generic.Dictionary(Of String, Long)
    Private Shared _objRegServer As RegServer.RegisterService
    Public Delegate Function getConnectionID_Delegate(RegisterUsercode As String, RegisterPassword As String, Refresh As Boolean) As Long
    Public Shared Function BeginGetConnectionID(RegisterUsercode As String, RegisterPassword As String, Refresh As Boolean, _
                                         asynCallback As System.AsyncCallback, Param As Object) As Long
        Dim f As New getConnectionID_Delegate(AddressOf getConnectionID)
        f.BeginInvoke(RegisterUsercode, RegisterPassword, Refresh, asynCallback, Param)
        Return 0
    End Function
    Public Shared Property objRegServer As RegServer.RegisterService
        Get
            If _objRegServer Is Nothing Then _objRegServer = New RegServer.RegisterService
            Return _objRegServer
        End Get
        Set(value As RegServer.RegisterService)

        End Set
    End Property
    Public Shared Function getConnectionID(ConnectionID As String, RegisterUsercode As String, RegisterPassword As String, Optional ServerURL As String = SERVER_URL, Optional Refresh As Boolean = False) As Long

        Dim connID As String, rand As String, ExistsKey As Boolean
        Dim ReTryTimes As Integer = 0, t As Long, Start As Long
        If ServerURL = "" Then ServerURL = SERVER_URL
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
BeginGetConnectionID:
                rand = objRegServer.getRandom()
                connID = objRegServer.setCallBackAddr(RegisterUsercode, SOP.Security.Security.HashAlgorithm(rand & RegisterPassword & RegisterPassword, "md5", "UTF-8"), rand, ServerURL)
                If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:获取" & RegisterUsercode & "用时" & Environment.TickCount - t & "返回" & connID)
                '若返回的CONNID小于0,则说明获取失败,不再加入_Connections,直接返回异常值
                If connID < 0 Then
                    If ReTryTimes < 3 Then
                        ReTryTimes = ReTryTimes + 1
                        If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:重试" & RegisterUsercode & "用时" & Environment.TickCount - t & "返回" & connID)
                        GoTo BeginGetConnectionID
                    Else
                        If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:重试失败" & RegisterUsercode & "用时" & Environment.TickCount - t & "返回" & connID)
                        Throw New Exception("注册宽乐失败" & connID)
                    End If
                Else
                    '若值已经存在,则更新之,否则加入之
                    If ExistsKey = True Then
                        _Connections(RegisterUsercode) = connID
                    Else
                        _Connections.Add(RegisterUsercode, connID)
                    End If
                    If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:更新并返回连接" & RegisterUsercode & "用时" & Environment.TickCount - Start & "返回" & connID)
                    Return connID
                End If

            End SyncLock
        Else
            If SendProgressLog.IsDebugEnabled = True Then SendProgressLog.Debug("getConnectionID:直接返回连接" & RegisterUsercode & "用时" & Environment.TickCount - Start & "返回" & connID)
            Return _Connections(RegisterUsercode)
        End If

    End Function

    Public Shared Function getRandom() As Long

        Return objRegServer.getRandom()
    End Function


End Class
