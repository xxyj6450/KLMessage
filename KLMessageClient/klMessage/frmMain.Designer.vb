<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuSystem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUserInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUserManagement = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuChangePwd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.帐户管理AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccountManagement = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.帐户验证CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMessage = New System.Windows.Forms.ToolStripMenuItem()
        Me.发送短信SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.短信状态查询RToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.接收短信RToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关键字管理ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.账户短信汇总报表ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.下载最新版本ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.新建NToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.打开OToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.保存SToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.打印PToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.帮助LToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSystem, Me.帐户管理AToolStripMenuItem, Me.mnuMessage, Me.mnuReport, Me.WindowsMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(784, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'mnuSystem
        '
        Me.mnuSystem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUserInfo, Me.mnuUserManagement, Me.mnuChangePwd, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.mnuSystem.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.mnuSystem.Name = "mnuSystem"
        Me.mnuSystem.Size = New System.Drawing.Size(58, 20)
        Me.mnuSystem.Text = "系统(&S)"
        '
        'mnuUserInfo
        '
        Me.mnuUserInfo.Image = Global.klMessage.My.Resources.Resources.users
        Me.mnuUserInfo.Name = "mnuUserInfo"
        Me.mnuUserInfo.Size = New System.Drawing.Size(139, 22)
        Me.mnuUserInfo.Text = "个人信息(&I)"
        '
        'mnuUserManagement
        '
        Me.mnuUserManagement.Image = Global.klMessage.My.Resources.Resources.User_Options
        Me.mnuUserManagement.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuUserManagement.Name = "mnuUserManagement"
        Me.mnuUserManagement.Size = New System.Drawing.Size(139, 22)
        Me.mnuUserManagement.Text = "用户管理(&U)"
        '
        'mnuChangePwd
        '
        Me.mnuChangePwd.Image = CType(resources.GetObject("mnuChangePwd.Image"), System.Drawing.Image)
        Me.mnuChangePwd.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuChangePwd.Name = "mnuChangePwd"
        Me.mnuChangePwd.Size = New System.Drawing.Size(152, 22)
        Me.mnuChangePwd.Text = "修改密码(&C)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(136, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.jumplist_exit
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.ExitToolStripMenuItem.Text = "退出(&X)"
        '
        '帐户管理AToolStripMenuItem
        '
        Me.帐户管理AToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAccountManagement, Me.ToolStripMenuItem2, Me.帐户验证CToolStripMenuItem})
        Me.帐户管理AToolStripMenuItem.Name = "帐户管理AToolStripMenuItem"
        Me.帐户管理AToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.帐户管理AToolStripMenuItem.Text = "帐户(&A)"
        '
        'mnuAccountManagement
        '
        Me.mnuAccountManagement.Image = Global.klMessage.My.Resources.Resources.accounts
        Me.mnuAccountManagement.Name = "mnuAccountManagement"
        Me.mnuAccountManagement.Size = New System.Drawing.Size(152, 22)
        Me.mnuAccountManagement.Text = "帐户管理(&A)"
        Me.mnuAccountManagement.Visible = False
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.klMessage.My.Resources.Resources.PrivateQueue
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItem2.Text = "帐户权限(&P)"
        '
        '帐户验证CToolStripMenuItem
        '
        Me.帐户验证CToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.Foxmail_exe_146_
        Me.帐户验证CToolStripMenuItem.Name = "帐户验证CToolStripMenuItem"
        Me.帐户验证CToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.帐户验证CToolStripMenuItem.Text = "帐户验证(&C)"
        Me.帐户验证CToolStripMenuItem.Visible = False
        '
        'mnuMessage
        '
        Me.mnuMessage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.发送短信SToolStripMenuItem, Me.短信状态查询RToolStripMenuItem, Me.接收短信RToolStripMenuItem, Me.关键字管理ToolStripMenuItem})
        Me.mnuMessage.Name = "mnuMessage"
        Me.mnuMessage.Size = New System.Drawing.Size(63, 20)
        Me.mnuMessage.Text = "短信(&M)"
        '
        '发送短信SToolStripMenuItem
        '
        Me.发送短信SToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.mail
        Me.发送短信SToolStripMenuItem.Name = "发送短信SToolStripMenuItem"
        Me.发送短信SToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.发送短信SToolStripMenuItem.Text = "发送短信(&S)"
        '
        '短信状态查询RToolStripMenuItem
        '
        Me.短信状态查询RToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.Report
        Me.短信状态查询RToolStripMenuItem.Name = "短信状态查询RToolStripMenuItem"
        Me.短信状态查询RToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.短信状态查询RToolStripMenuItem.Text = "短信状态查询(&R)"
        '
        '接收短信RToolStripMenuItem
        '
        Me.接收短信RToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.Foxmail_exe_IC_NEWRECV_
        Me.接收短信RToolStripMenuItem.Name = "接收短信RToolStripMenuItem"
        Me.接收短信RToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.接收短信RToolStripMenuItem.Text = "接收短信(&R)"
        Me.接收短信RToolStripMenuItem.Visible = False
        '
        '关键字管理ToolStripMenuItem
        '
        Me.关键字管理ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.key
        Me.关键字管理ToolStripMenuItem.Name = "关键字管理ToolStripMenuItem"
        Me.关键字管理ToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.关键字管理ToolStripMenuItem.Text = "关键字管理"
        '
        'mnuReport
        '
        Me.mnuReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.账户短信汇总报表ToolStripMenuItem})
        Me.mnuReport.Name = "mnuReport"
        Me.mnuReport.Size = New System.Drawing.Size(59, 20)
        Me.mnuReport.Text = "报表(&R)"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.OptionsToolStripMenuItem.Text = "用户短信汇总报表"
        '
        '账户短信汇总报表ToolStripMenuItem
        '
        Me.账户短信汇总报表ToolStripMenuItem.Name = "账户短信汇总报表ToolStripMenuItem"
        Me.账户短信汇总报表ToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.账户短信汇总报表ToolStripMenuItem.Text = "账户短信汇总报表"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(63, 20)
        Me.WindowsMenu.Text = "窗口(&W)"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.CascadeToolStripMenuItem.Text = "层叠(&C)"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.TileVerticalToolStripMenuItem.Text = "垂直平铺(&V)"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "水平平铺(&H)"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.CloseAllToolStripMenuItem.Text = "全部关闭(&L)"
        '
        'ArrangeIconsToolStripMenuItem
        '
        Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
        Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.ArrangeIconsToolStripMenuItem.Text = "排列图标(&A)"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolStripSeparator8, Me.下载最新版本ToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(60, 20)
        Me.HelpMenu.Text = "帮助(&H)"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ContentsToolStripMenuItem.Text = "目录(&C)"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Image = CType(resources.GetObject("IndexToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.IndexToolStripMenuItem.Text = "索引(&I)"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.SearchToolStripMenuItem.Text = "搜索(&S)"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(160, 6)
        '
        '下载最新版本ToolStripMenuItem
        '
        Me.下载最新版本ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.web_download
        Me.下载最新版本ToolStripMenuItem.Name = "下载最新版本ToolStripMenuItem"
        Me.下载最新版本ToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.下载最新版本ToolStripMenuItem.Text = "下载最新版本"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.AboutToolStripMenuItem.Text = "关于(&A) ..."
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(31, 17)
        Me.ToolStripStatusLabel.Text = "状态"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(625, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "[用户编码]"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(63, 17)
        Me.ToolStripStatusLabel2.Text = "[用户姓名]"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(50, 17)
        Me.ToolStripStatusLabel3.Text = "[IP地址]"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.新建NToolStripButton, Me.打开OToolStripButton, Me.保存SToolStripButton, Me.打印PToolStripButton, Me.toolStripSeparator, Me.帮助LToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '新建NToolStripButton
        '
        Me.新建NToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.新建NToolStripButton.Image = Global.klMessage.My.Resources.Resources.mail
        Me.新建NToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.新建NToolStripButton.Name = "新建NToolStripButton"
        Me.新建NToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.新建NToolStripButton.Text = "编写短信(&N)"
        '
        '打开OToolStripButton
        '
        Me.打开OToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.打开OToolStripButton.Image = Global.klMessage.My.Resources.Resources.User_Options
        Me.打开OToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.打开OToolStripButton.Name = "打开OToolStripButton"
        Me.打开OToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.打开OToolStripButton.Text = "用户管理(&U)"
        '
        '保存SToolStripButton
        '
        Me.保存SToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.保存SToolStripButton.Image = Global.klMessage.My.Resources.Resources.accounts
        Me.保存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.保存SToolStripButton.Name = "保存SToolStripButton"
        Me.保存SToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.保存SToolStripButton.Text = "帐户管理(&A)"
        '
        '打印PToolStripButton
        '
        Me.打印PToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.打印PToolStripButton.Image = Global.klMessage.My.Resources.Resources.Report
        Me.打印PToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.打印PToolStripButton.Name = "打印PToolStripButton"
        Me.打印PToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.打印PToolStripButton.Text = "短信状态(&S)"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        '帮助LToolStripButton
        '
        Me.帮助LToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.帮助LToolStripButton.Image = CType(resources.GetObject("帮助LToolStripButton.Image"), System.Drawing.Image)
        Me.帮助LToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.帮助LToolStripButton.Name = "帮助LToolStripButton"
        Me.帮助LToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.帮助LToolStripButton.Text = "帮助(&L)"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmMain"
        Me.Text = "短信平台"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUserManagement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSystem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuChangePwd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuMessage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 发送短信SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 短信状态查询RToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUserInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents 新建NToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 打开OToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 保存SToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 打印PToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 帮助LToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 帐户管理AToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAccountManagement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 帐户验证CToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents 接收短信RToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 账户短信汇总报表ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 关键字管理ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 下载最新版本ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
