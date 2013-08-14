
Public Class frmUpgrade
    Private Shared _dt As System.Data.DataTable
    Private Shared _UpdateURL As String
    Private Shared _NewVersion As String
    Private Shared _Description As String
    Private Shared _UpdateTime As Date
    Private Shared Property UpgradeData As System.Data.DataTable
        Get
            Return _dt
        End Get
        Set(value As System.Data.DataTable)
            _dt = value
            If _dt.Rows.Count > 0 Then
                _UpdateURL = _dt.Rows(0)("UpdateURL")
                _UpdateTime = _dt.Rows(0)("UpdateTime")
                _Description = _dt.Rows(0)("Description")
                _NewVersion = _dt.Rows(0)("VersionCode")


            End If
        End Set
    End Property
    Public Shared Function getNewVersion() As Boolean
        Dim ws As New SendMessage.myWebService
        Dim dt As System.Data.DataTable
        dt = ws.GetNewVersion(0, My.Settings.VersionID, "")
        If Not (dt Is Nothing) AndAlso dt.Rows.Count > 0 Then
            UpgradeData = dt
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub frmUpgrade_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If _Description <> "" Then RichTextBox1.Text = _Description
        If Me.NewVersionCode.Text <> "" Then Me.NewVersionCode.Text = _NewVersion
        Me.oldVersionCode.Text = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If _UpdateURL <> "" Then System.Diagnostics.Process.Start(_UpdateURL)
    End Sub
End Class