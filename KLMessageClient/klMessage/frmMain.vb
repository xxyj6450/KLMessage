Imports System.Windows.Forms

Public Class frmMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles mnuUserManagement.Click
        Dim f As New frmUserManagement
        f.MdiParent = Me
        f.Visible = True
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles mnuChangePwd.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: 在此处添加打开文件的代码。
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: 在此处添加代码，将窗体的当前内容保存到一个文件中。
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
  
            Me.Close()

    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' 使用 My.Computer.Clipboard 将选择的文本或图像插入剪贴板
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' 使用 My.Computer.Clipboard 将选择的文本或图像插入剪贴板
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        '使用 My.Computer.Clipboard.GetText() 或 My.Computer.Clipboard.GetData 从剪贴板检索信息。
    End Sub

    

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' 关闭此父窗体的所有子窗体。
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub OptionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OptionsToolStripMenuItem.Click

    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.ExitThread()
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("您确认要退出本系统吗?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Application.ProductName) = MsgBoxResult.No Then e.Cancel = True
    End Sub

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If CurrentUser.isAdmin = False Then
            Me.mnuAccountManagement.Visible = False
            'Me.mnuUserManagement.Visible = False
            '帐户管理AToolStripMenuItem.Visible = False
            mnuChangePwd.Visible = False
            打开OToolStripButton.Visible = False
            保存SToolStripButton.Visible = False
        End If
        If UserPermissions.UserData("AccountManagement") = 0 Then
            Me.mnuAccountManagement.Visible = False
        End If
        If UserPermissions.UserData("RecieveMessage") = 0 Then
            Me.接收短信RToolStripMenuItem.Visible = True
        End If
        Me.ToolStripStatusLabel1.Text = "用户编码:" & CurrentUser.Usercode
        Me.ToolStripStatusLabel2.Text = "用户名称:" & CurrentUser.UserName
        Me.ToolStripStatusLabel3.Text = "IP地址:" & IP
    End Sub

    Private Sub mnuUserInfo_Click(sender As System.Object, e As System.EventArgs) Handles mnuUserInfo.Click
        Dim f As New frmUserInfo
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuAccountManagement_Click(sender As System.Object, e As System.EventArgs)
       
    End Sub

    Private Sub mnuMessage_Click(sender As System.Object, e As System.EventArgs) Handles mnuMessage.Click
        
    End Sub

    Private Sub 发送短信SToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 发送短信SToolStripMenuItem.Click
        Dim f As New frmSendMessage
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub 新建NToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 新建NToolStripButton.Click
        Dim f As New frmSendMessage
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub 帐户权限ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        
    End Sub

    Private Sub 短信状态查询RToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 短信状态查询RToolStripMenuItem.Click
        Dim f As New rpt_MessageStatus
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub 帐户验证CToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 帐户验证CToolStripMenuItem.Click
        Dim f As New frmWelcom_CheckAccount
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim f As New frmAccountLimit
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuAccountManagement_Click_1(sender As System.Object, e As System.EventArgs) Handles mnuAccountManagement.Click
        Dim f As New frmAccountManagement
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim f As New AboutBox1
        f.Show()
    End Sub

    Private Sub 打开OToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 打开OToolStripButton.Click
        Dim f As New frmUserManagement
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub 保存SToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 保存SToolStripButton.Click
        Dim f As New frmAccountManagement
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub 打印PToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 打印PToolStripButton.Click
        Dim f As New rpt_MessageStatus
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub 帮助LToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 帮助LToolStripButton.Click
        Dim f As New AboutBox1
        f.Show()
    End Sub

    Private Sub 接收短信RToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 接收短信RToolStripMenuItem.Click
        Dim f As New frmRecieveMessagevb
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub 关键字管理ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 关键字管理ToolStripMenuItem.Click
        Dim f As New frmBadwords
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub 下载最新版本ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 下载最新版本ToolStripMenuItem.Click
        System.Diagnostics.Process.Start(My.Settings.UpdateURL)
    End Sub
End Class
