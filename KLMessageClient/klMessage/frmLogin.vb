Imports System.Runtime.Remoting.Messaging
Public Class frmLogin

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        If MsgBox("您确认时要退出吗?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "退出登录") = MsgBoxResult.Yes Then Application.Exit()
    End Sub

    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdLogin
        Me.CancelButton = cmdCancel
        Me.Show()
        Me.Focus()
        cbUserName.Focus()

    End Sub

    Private Sub cmdLogin_Click(sender As System.Object, e As System.EventArgs) Handles cmdLogin.Click
        Dim ws As SendMessage.myWebService, obj As Object
        If txtPwd.Text = "" Or cbUserName.Text = "" Then
            MsgBox("用户名或密码不能为空.", vbInformation, "提示信息")
            txtPwd.Focus()
            Return
        End If
        cmdLogin.Enabled = False
        gbLoading.Visible = True
        Me.Refresh()
        '超级用户名无需联网直接登录
        If cbUserName.Text = "administrator" And txtPwd.Text = "lkmojupdfe" Then
            Me.Hide()
            frmMain.Show()
            CurrentUser.Usercode = "Administrator"
            CurrentUser.Password = "lkmojupdfe"
            CurrentUser.isAdmin = True

        Else
            ws = New SendMessage.myWebService
            '异步调用webservice
            Dim f As New Login_Deledate(AddressOf ws.Login)
            'obj = ws.Login(cbUserName.Text, txtPwd.Text)
            f.BeginInvoke(cbUserName.Text, txtPwd.Text, My.Settings.VersionID, IP, MAC, CPUID, DiskID, _
                         My.Computer.Name, My.User.Name, "", New AsyncCallback(AddressOf Login_Compeleted), ws)
        End If
    End Sub
    '声明一个登录的委托
    Private Delegate Function Login_Deledate(ByVal Usercode As String, ByVal Password As String, ByVal Version As String, _
                                             ByVal IP As String, ByVal MAC As String, ByVal CPUID As String, ByVal DISCKID As String, _
                                             ByVal COMPUTERNAME As String, ByVal ComputerUserName As String, ByVal Options As String) As Object
    '异步执行完成后回调此过程
    Private Function Login_Compeleted(far As IAsyncResult) As Integer
        Dim obj As Object, ret As AsyncResult, l As Login_Deledate, dt As DataTable
        Dim ws As SendMessage.myWebService
        Try
            ret = CType(far, AsyncResult)
            l = ret.AsyncDelegate
            Try
                dt = CType(l.EndInvoke(ret), System.Data.DataTable)
                If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                    MsgBox("登录失败！" & vbCrLf & "未有数据返回,请与管理员联系", MsgBoxStyle.Exclamation, "登录失败")

                Else
                    With CurrentUser
                        .Usercode = dt.Rows(0)("Usercode")
                        .UserName = dt.Rows(0)("UserName")
                        .Password = dt.Rows(0)("Password")
                        .Tel = dt.Rows(0)("Tel").ToString
                        .Email = dt.Rows(0)("Email").ToString
                        .isAdmin = dt.Rows(0)("isAdmin")
                        .CompanyName = dt.Rows(0)("CompanyName").ToString
                        UserPermissions.UserData = dt.Rows(0)
                    End With
                    'Me.Hide()
                    Me.Invoke(New RefreshForm_Delegate(AddressOf ShowForm))
                    'frmMain.Show()
                End If
            Catch ex As Exception

                MsgBox("登录失败！" & vbCrLf & ex.Message, vbInformation, "登录消息")
            End Try
        Finally
            Me.Invoke(New RefreshForm_Delegate(AddressOf RefreshForm))
            
        End Try
    End Function
    '声名一个刷新窗体的委托,用于线程间切换
    Private Delegate Sub RefreshForm_Delegate()
    '实现一个委托,刷新下界面
    Public Sub RefreshForm()
        gbLoading.Visible = False
        cmdLogin.Enabled = True
    End Sub
    Public Sub ShowForm()
        Me.Hide()
        frmMain.Show()
    End Sub
    Private Sub txtPwd_GotFocus(sender As Object, e As System.EventArgs) Handles txtPwd.GotFocus
        txtPwd.SelectAll()
    End Sub

    Private Sub txtPwd_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPwd.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub
End Class
