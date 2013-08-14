Imports System.Threading
Public Class SessionQueue
    Private _SessionID As String
    Private _QueueID As String
    Private _MessageCount As Long
    Private _SendCount As Long
    Private _Locked As Boolean = True
    Private _Finished As Boolean = False
    Public Property Locked As Boolean
        Get
            Return _Locked
        End Get
        Set(value As Boolean)
            _Locked = value
        End Set

    End Property
    Public ReadOnly Property Finished As Boolean
        Get
            Return _Finished
        End Get
    End Property
    Public Property SessionID As String
        Get
            Return _SessionID
        End Get
        Set(value As String)
            _SessionID = value
        End Set
    End Property
    Public Property QueueID As String
        Get
            Return _QueueID
        End Get
        Set(value As String)
            _QueueID = value
        End Set
    End Property
    Public Property MessageCount As Long
        Get
            Return _MessageCount
        End Get
        Set(value As Long)
            _MessageCount = value
        End Set
    End Property
    Public Property SendCount As Long
        Get
            Return _SendCount
        End Get
        Set(value As Long)
            _SendCount = value
        End Set
    End Property
    Public Sub New(SessionID As String, QueueID As String, MessageCount As Long)
        _SessionID = SessionID
        _QueueID = QueueID
        _MessageCount = MessageCount
        _Finished = False
        _Locked = True
    End Sub
    Public Sub AddMessageCount(RecipientsCount As Long)

        System.Threading.Interlocked.Add(_SendCount, RecipientsCount)
        If _SendCount >= _MessageCount Then _Finished = True
        'If _SendCount + My.Settings.MinThreadCount >= _MessageCount Then _Locked = False

    End Sub
End Class
