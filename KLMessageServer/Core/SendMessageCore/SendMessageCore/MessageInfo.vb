Public Class MessageInfo
    Private _MessageID As String
    Private _Recipients As String
    Private _Status As Long
    Private _ErrorText As String
    Private _SendDate As Date
    Private _RecipientsCount As Long
    Private _SharedObject As MessageInfo
    Private _StartTick As Long
    Private _EndTick As Long
    Private _SessionID As String
    Private _UserMessageID As String
    Private _MessageType As Integer
    Private _Tag As String
    Public Sub New(m_UserMessageID As String, m_SessionID As String, m_Recipients As String, m_RecipientsCount As Long, m_Status As String, m_ErrorText As String)
        _UserMessageID = m_UserMessageID
        _SessionID = m_SessionID
        _Recipients = m_Recipients
        _Status = m_Status
        _ErrorText = m_ErrorText
        _SendDate = Now
        _StartTick = System.Environment.TickCount
        _RecipientsCount = m_RecipientsCount
        _Tag = Guid.NewGuid().ToString

    End Sub
    Public ReadOnly Property StartTick As Long
        Get
            Return _StartTick
        End Get
    End Property
    Public ReadOnly Property Key As String
        Get
            Return _Tag
        End Get
    End Property
    Public Property EndTick As Long
        Get
            Return _EndTick
        End Get
        Set(value As Long)
            _EndTick = value
        End Set
    End Property
    Public Property UserMessageID As String
        Get
            Return _UserMessageID
        End Get
        Set(value As String)
            _UserMessageID = value
        End Set
    End Property
    Public Property MessageID As String
        Get
            Return _MessageID
        End Get
        Set(value As String)
            _MessageID = value
        End Set
    End Property
    Public Property SessionID As String
        Get
            Return _SessionID
        End Get
        Set(value As String)
            _SessionID = value
        End Set
    End Property
    Public Property Recipients As String
        Get
            Return _Recipients
        End Get
        Set(value As String)
            _Recipients = value
        End Set
    End Property
    Public Property Status As Long
        Get
            Return _Status
        End Get
        Set(value As Long)
            _Status = value
        End Set
    End Property
    Public Property RecipientsCount As Long
        Get
            Return _RecipientsCount
        End Get
        Set(value As Long)
            _RecipientsCount = value
        End Set
    End Property
    Public Property ErrorText As String
        Get
            Return _ErrorText
        End Get
        Set(value As String)
            _ErrorText = value
        End Set
    End Property
    Public Property SendDate As Date
        Get
            Return _SendDate
        End Get
        Set(value As Date)
            _SendDate = value
        End Set
    End Property
 
End Class
