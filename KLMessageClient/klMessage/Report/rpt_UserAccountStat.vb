Public Class rpt_UserAccountStat

    Private Sub rpt_UserAccountStat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If UserPermissions.UserData("UserManagement") = False Then
            txtAccountID.ReadOnly = True
            txtAccountID.Text = CurrentUser.Usercode
        End If
    End Sub
End Class