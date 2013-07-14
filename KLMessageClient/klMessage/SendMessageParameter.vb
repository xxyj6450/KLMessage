Public Class SendMessageParameter
    Private _SessionID As String
    'Private _Recipients() As String
    Private _Nettype As Integer
    Private _Simulation As Boolean
    Private _RecordLog As Boolean
    Private _AddTag As Boolean
    Private _ShowDebugInfo As Boolean
    Private _Recipients(0 To 3) As ArrayList
    Private _QueueSize As Long
    Private _MaxBatchNumber As String
    Private _InvockPerSecond As String
    Private _Message As String
    Public Sub New(SessionID As String, Recipients() As ArrayList, Message As String, InvockPerSecond As String, MaxBatchNumber As String, _
                   Nettype As Integer, QueueSize As Long, Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, ShowDebugInfo As Boolean)
        _SessionID = SessionID
        _Recipients = Recipients
        _Nettype = Nettype
        _QueueSize = QueueSize
        _Simulation = Simulation
        _RecordLog = RecordLog
        _AddTag = AddTag
        _ShowDebugInfo = ShowDebugInfo
        _Message = Message
        _MaxBatchNumber = MaxBatchNumber
        _InvockPerSecond = InvockPerSecond
    End Sub
    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(value As String)
            _Message = value
        End Set
    End Property
    Public Property InvockPerSecond() As String
        Get
            Return _InvockPerSecond
        End Get
        Set(value As String)
            _InvockPerSecond = value
        End Set
    End Property
    Public Property MaxBatchNumber() As String
        Get
            Return _MaxBatchNumber
        End Get
        Set(value As String)
            _MaxBatchNumber = value
        End Set
    End Property
    Public Property QueueSize As Long
        Get
            Return _QueueSize
        End Get
        Set(value As Long)
            _QueueSize = value
        End Set
    End Property
    Public Property Simulation As String
        Get
            Return _Simulation
        End Get
        Set(value As String)
            _Simulation = value
        End Set
    End Property
    Public Property ShowDebugInfo As String
        Get
            Return _ShowDebugInfo
        End Get
        Set(value As String)
            _ShowDebugInfo = value
        End Set
    End Property
    Public Property RecordLog As String
        Get
            Return _RecordLog
        End Get
        Set(value As String)
            _RecordLog = value
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
    Public Property Recipients() As ArrayList()
        Get
            Return _Recipients
        End Get
        Set(value() As ArrayList)
            _Recipients = value
        End Set
    End Property
    Public Property NetType As String
        Get
            Return _Nettype
        End Get
        Set(value As String)
            _Nettype = value
        End Set
    End Property
    Public Property AddTag As String
        Get
            Return _AddTag
        End Get
        Set(value As String)
            _AddTag = value
        End Set
    End Property
End Class
