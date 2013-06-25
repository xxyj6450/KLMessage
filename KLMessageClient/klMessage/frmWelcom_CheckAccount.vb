Public Class frmWelcom_CheckAccount
    Private _NextForm As frmCheckAccount_Step1
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If _NextForm Is Nothing Then _NextForm = New frmCheckAccount_Step1

        _NextForm.MdiParent = frmMain
        _NextForm.ParentForm = Me
        Me.Hide()
        _NextForm.Show()
    End Sub

    Private Sub frmWelcom_CheckAccount_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class