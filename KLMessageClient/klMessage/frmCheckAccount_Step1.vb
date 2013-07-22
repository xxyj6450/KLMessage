Public Class frmCheckAccount_Step1
    Private _NextForm As Form
    Private _ParentForm As frmWelcom_CheckAccount
 
    Private Sub frmCheckAccount_Step1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.Hide()
        ParentForm.Show()
    End Sub
End Class