Imports System
Imports System.Collections
Imports System.Collections.Generic
Friend Class SendMessageParameter
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
    Private _UserMessageID As String
    Private _Usercode As String
    Private _Password As String
    Private _MessageType As Integer
    Private _CallbackURL As String
    Private _ThreadMode As Integer
    Private _IP As String
    Private _MAC As String
    Private _CPUID As String
    Private _DiskID As String
    Private _ComputerName As String
    Private _ComputerUserName As String

    Public Sub New(Usercode As String, Password As String, UserMessageID As String, SessionID As String, Recipients() As ArrayList, Message As String, _
                   Nettype As Integer, CallbackURL As String, ThreadMode As Integer, InvockPerSecond As String, MaxBatchNumber As String, QueueSize As Long, _
                   Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, ShowDebugInfo As Boolean, _
                   IP As String, MAC As String, CPUID As String, DISKID As String, ComputerName As String, ComputerUserName As String)
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
        _CallbackURL = IIf(Trim(CallbackURL) = "", SERVER_URL, CallbackURL)
        _ThreadMode = ThreadMode
        _IP = IP
        _MAC = MAC
        _CPUID = CPUID
        _DiskID = DISKID
        _ComputerName = ComputerName
        _ComputerUserName = ComputerUserName
        _Usercode = Usercode
        _Password = Password
        _UserMessageID = UserMessageID
    End Sub
    Public Property IP As String
        Get
            Return _IP
        End Get
        Set(value As String)
            _IP = value
        End Set
    End Property
    Public Property MAC As String
        Get
            Return _MAC
        End Get
        Set(value As String)
            _MAC = value
        End Set
    End Property
    Public Property CPUID As String
        Get
            Return _CPUID
        End Get
        Set(value As String)
            _CPUID = value
        End Set
    End Property
    Public Property DiskID As String
        Get
            Return _DiskID
        End Get
        Set(value As String)
            _DiskID = value
        End Set
    End Property
    Public Property ComputerName As String
        Get
            Return _ComputerName
        End Get
        Set(value As String)
            _ComputerName = value
        End Set
    End Property
    Public Property ComputerUserName As String
        Get
            Return _ComputerUserName
        End Get
        Set(value As String)
            _ComputerUserName = value
        End Set
    End Property
    Public Property ThreadMode As Integer
        Get
            Return _ThreadMode
        End Get
        Set(value As Integer)
            _ThreadMode = value
        End Set
    End Property
    Public Property CallbackURL As String
        Get
            Return _CallbackURL
        End Get
        Set(value As String)
            _CallbackURL = value
        End Set
    End Property
    Public Property MessageType As Integer
        Get
            Return _MessageType
        End Get
        Set(value As Integer)
            _MessageType = value
        End Set
    End Property
    Public Property Password As String
        Get
            Return _Password
        End Get
        Set(value As String)
            _Password = value
        End Set
    End Property
    Public Property Usercode As String
        Get
            Return _Usercode
        End Get
        Set(value As String)
            _Usercode = value
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
