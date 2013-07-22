Friend Class UserInfo
    Private m_Usercode As String
    Private m_Password As String
    Private m_UserData As System.Data.DataTable
    Private m_NextLoginDate As Date
    Private m_QueueSize As Long
    Private Const def_NextLoginDate As Long = 10
    Public Property UserCode As String
        Get
            Return m_Usercode
        End Get
        Set(value As String)
            m_Usercode = value
        End Set
    End Property
    Public Property Password As String
        Get
            Return m_Password
        End Get
        Set(value As String)
            m_Password = value
        End Set
    End Property
    Public ReadOnly Property UserData As System.Data.DataTable
        Get
            Return m_UserData
        End Get
 
    End Property
    Public ReadOnly Property NextLoginDate As Date
        Get
            Return m_NextLoginDate
        End Get
    End Property
    Public ReadOnly Property QueueSize As Long
        Get
            Return m_QueueSize
        End Get
    End Property
    Public Function Login(Usercode As String, Password As String, Version As String, IP As String, MAC As String, ComputerName As String, ComputerUserName As String, CPUID As String, DISCKID As String) As UserInfo
        Dim ws As New SendMessage.myWebService
        If Usercode = "" Then
            Throw New Exception("用户名不能为空")
        End If
        If Password = "" Then
            Throw New Exception("用户密码不能为空")
        End If
        m_UserData = ws.Login(Usercode, Password, Version, IP, MAC, CPUID, DISCKID, ComputerName, ComputerUserName, "")
        If m_UserData Is Nothing Then
            Throw New Exception("用户" & Usercode & "登录发生异常,未返回用户数据.")
        End If
        If m_UserData.Rows.Count = 0 Then
            Throw New Exception("用户" & Usercode & "登录发生异常,返回用户数据为空.")
        End If

        m_Usercode = Usercode
        m_Password = Password
        m_QueueSize = IIf(IsDBNull(m_UserData.Rows(0)("QueueSize")), 0, m_UserData.Rows(0)("QueueSize"))
        m_NextLoginDate = IIf(IsDBNull(m_UserData.Rows(0)("NextLoginDate")), DateAdd(DateInterval.Minute, def_NextLoginDate, Now), m_UserData.Rows(0)("NextLoginDate"))
        Return Me
    End Function
End Class
