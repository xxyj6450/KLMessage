Imports Microsoft.VisualBasic
Imports System.Data
<Serializable()> _
Public Class Command
    Private _CommandText As String
    Private _CommandType As System.Data.CommandType
    Private _Parameters As System.Collections.Generic.List(Of Parameter)
 
    Public Sub New(cmd As System.Data.Common.DbCommand)
        _CommandText = cmd.CommandText
        _CommandType = cmd.CommandType
        For Each p As System.Data.Common.DbParameter In cmd.Parameters
            _Parameters.Add(New CommonLib.Parameter(p))
        Next
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub

    Public Property CommandText As String
        Get
            Return _CommandText
        End Get
        Set(value As String)
            _CommandText = value
        End Set
    End Property
    Public Property CommandType As System.Data.CommandType
        Get
            Return _CommandType
        End Get
        Set(value As System.Data.CommandType)
            _CommandType = value
        End Set
    End Property
    Public Property Parameters() As System.Collections.Generic.List(Of CommonLib.Parameter)
        Get
            Return _Parameters
        End Get
        Set(value As System.Collections.Generic.List(Of CommonLib.Parameter))
            _Parameters = value
        End Set
    End Property
    Public Function getCommand() As System.Data.Common.DbCommand
        Dim cmd As System.Data.Common.DbCommand
        cmd = New System.Data.SqlClient.SqlCommand
        With cmd
            For Each p As Parameter In _Parameters
                .Parameters.Add(p.getParameter())
                .CommandType = _CommandType
                .CommandText = _CommandText
            Next
        End With
        Return cmd
    End Function
End Class
<Serializable()> _
Public Class Parameter
    Private _Name As String
    Private _Type As Data.SqlDbType
    Private _Length As Integer
    Private _value As Object
    Private _SourceColumn As String
    Private _SourceVersion As System.Data.DataRowVersion
    Private _Direction As System.Data.ParameterDirection
    Public Sub New(param As System.Data.Common.DbParameter)
        _Name = param.ParameterName
        _Type = param.DbType
        _Length = param.Size
        _value = param.Value
        _SourceColumn = param.SourceColumn
        _SourceVersion = param.SourceVersion
        _Direction = param.Direction
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub
    Public Property Direction As System.Data.ParameterDirection
        Get
            Return _Direction
        End Get
        Set(value As System.Data.ParameterDirection)
            _Direction = value
        End Set
    End Property
    Public Property SourceVersion As System.Data.DataRowVersion
        Get
            Return _SourceVersion
        End Get
        Set(value As System.Data.DataRowVersion)
            _SourceVersion = value
        End Set
    End Property
    Public Property SourceColumn As String
        Get
            Return _SourceColumn
        End Get
        Set(value As String)
            _SourceColumn = value
        End Set
    End Property
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property
    Public Property Type As Data.SqlDbType
        Get
            Return _Type
        End Get
        Set(value As Data.SqlDbType)
            _Type = value
        End Set
    End Property
    Public Property Value As Object
        Get
            Return _value
        End Get
        Set(value As Object)
            _value = value
        End Set
    End Property
    Public Function getParameter() As System.Data.Common.DbParameter
        Dim p As System.Data.Common.DbParameter
        p = New System.Data.SqlClient.SqlParameter
        p.Direction = _Direction
        p.ParameterName = _Name
        p.DbType = _Type
        p.Value = _value
        p.Size = _Length
        p.SourceVersion = _SourceVersion
        p.SourceColumn = _SourceColumn
        Return p
    End Function
End Class