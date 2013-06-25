<Serializable()>
Public Class cUser
    Private _Usercode As String
    Private _UserName As String
    Private _Password As String
    Private _isAdmin As Boolean
    Private _CompanyName As String
    Private _MessagePerDay As Long
    Private _MessageThisday As Long
    Private _MessagePerMonth As Long
    Private _MessageThisMonth As Long
    Private _Remark As String
    Private _Email As String
    Private _Tel As String
    Public Property Usercode As String
        Get
            Usercode = _Usercode
        End Get
        Set(value As String)
            _Usercode = value
        End Set
    End Property
    Public Property UserName As String
        Get
            UserName = _UserName
        End Get
        Set(value As String)
            _UserName = value
        End Set
    End Property

    Public Property Password As String
        Get
            Password = _Password
        End Get
        Set(value As String)
            _Password = value
        End Set
    End Property

    Public Property isAdmin As String
        Get
            isAdmin = _isAdmin
        End Get
        Set(value As String)
            _isAdmin = value
        End Set
    End Property

    Public Property CompanyName As String
        Get
            CompanyName = _CompanyName
        End Get
        Set(value As String)
            _CompanyName = value
        End Set
    End Property

    Public Property Email As String
        Get
            Email = _Email
        End Get
        Set(value As String)
            _Email = value
        End Set
    End Property

    Public Property Tel As String
        Get
            Tel = _Tel
        End Get
        Set(value As String)
            _Tel = value
        End Set
    End Property

    Public Property MessagePerDay As Long
        Get
            MessagePerDay = _MessagePerDay
        End Get
        Set(value As Long)
            _MessagePerDay = value
        End Set
    End Property

    Public Property MessageThisday As Long
        Get
            MessageThisday = _MessageThisday
        End Get
        Set(value As Long)
            _MessageThisday = value
        End Set
    End Property

    Public Property MessagePerMonth As Long
        Get
            MessagePerMonth = _MessagePerMonth
        End Get
        Set(value As Long)
            _MessagePerMonth = value
        End Set
    End Property

    Public Property MessageThisMonth As Long
        Get
            MessageThisMonth = _MessageThisMonth
        End Get
        Set(value As Long)
            _MessageThisMonth = value
        End Set
    End Property

    Public Property Remark As String
        Get
            Remark = _Remark
        End Get
        Set(value As String)
            _Remark = value
        End Set
    End Property

End Class
