﻿Public Class MessageInfo
    Private _MessageID As String
    Private _Recipients As String
    Private _Status As String
    Private _ErrorText As String
    Private _SendDate As Date
    Private _RecipientsCount As Long
    Private _SharedObject As MessageInfo
    Private _StartTick As Long
    Private _EndTick As Long
    Public Sub New()
        _MessageID = Guid.NewGuid().ToString
        If Not (_SharedObject Is Nothing) Then _SharedObject = New MessageInfo()
    End Sub
    Public Sub New(m_Recipients As String, m_RecipientsCount As Long, m_Status As String, m_ErrorText As String)
        _MessageID = Guid.NewGuid().ToString
        _Recipients = m_Recipients
        _Status = m_Status
        _ErrorText = m_ErrorText
        _SendDate = Now
        _StartTick = System.Environment.TickCount
        _RecipientsCount = m_RecipientsCount
        If Not (_SharedObject Is Nothing) Then _SharedObject = New MessageInfo()
    End Sub
    Public ReadOnly Property StartTick As Long
        Get
            Return _StartTick
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
    Public Property MessageID As String
        Get
            Return _MessageID
        End Get
        Set(value As String)
            _MessageID = value
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
    Public Property Status As String
        Get
            Return _Status
        End Get
        Set(value As String)
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
    Public Shared ReadOnly Property SharedObject() As MessageInfo
        Get

        End Get
 
    End Property
End Class
