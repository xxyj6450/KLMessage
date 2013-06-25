Public Class frmCheckAccount_Step1
    Private _NextForm As Form
    Private _ParentForm As frmWelcom_CheckAccount
    Public Property ParentForm As frmWelcom_CheckAccount
        Get
            Return _ParentForm
        End Get
        Set(value As frmWelcom_CheckAccount)
            _ParentForm = value
        End Set
    End Property
    Private Sub frmCheckAccount_Step1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.Hide()
        ParentForm.Show()
    End Sub
End Class