
Public Class frmUserInfo

    Private Sub frmUserInfo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        With CurrentUser
            Me.txtCompanyName.Text = .CompanyName
            Me.txtEmail.Text = .Email
            Me.txtRemark.Text = .Remark
            Me.txtTel.Text = .Tel
            Me.txtUserCode.Text = .Usercode
            Me.txtUserName.Text = .UserName


        End With
    End Sub
End Class