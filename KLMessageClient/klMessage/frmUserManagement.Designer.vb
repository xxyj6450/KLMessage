<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserManagement))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbLoading = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.打开OToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.新建NToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripSplitButton()
        Me.清空ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存SToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.帮助LToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripExit = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAccountID = New System.Windows.Forms.TextBox()
        Me.CBAccountStatus = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Password = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.isAdmin = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DistributionMode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.QueueSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShowEchoInfo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NofityNewMessage = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.AccountManagement = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.RecieveMessage = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ReportStatus = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ReportMessage = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ReportURL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalLimit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalSend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreditLeft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LimitPerday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendToday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbLoading.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "执行中，请稍候..."
        '
        'gbLoading
        '
        Me.gbLoading.Controls.Add(Me.Label4)
        Me.gbLoading.Controls.Add(Me.PictureBox2)
        Me.gbLoading.Location = New System.Drawing.Point(312, 91)
        Me.gbLoading.Name = "gbLoading"
        Me.gbLoading.Size = New System.Drawing.Size(184, 74)
        Me.gbLoading.TabIndex = 7
        Me.gbLoading.TabStop = False
        Me.gbLoading.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(10, 26)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
        Me.ToolStripStatusLabel1.Text = "共0行"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开OToolStripButton, Me.ToolStripSeparator4, Me.新建NToolStripButton, Me.ToolStripdelete, Me.保存SToolStripButton, Me.toolStripSeparator, Me.ToolStripButton1, Me.ToolStripExport, Me.ToolStripSeparator2, Me.帮助LToolStripButton, Me.toolStripSeparator1, Me.ToolStripExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '打开OToolStripButton
        '
        Me.打开OToolStripButton.Image = CType(resources.GetObject("打开OToolStripButton.Image"), System.Drawing.Image)
        Me.打开OToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.打开OToolStripButton.Name = "打开OToolStripButton"
        Me.打开OToolStripButton.Size = New System.Drawing.Size(69, 22)
        Me.打开OToolStripButton.Text = "查询(&Q)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        '新建NToolStripButton
        '
        Me.新建NToolStripButton.Image = Global.klMessage.My.Resources.Resources.Tree_View_Add
        Me.新建NToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.新建NToolStripButton.Name = "新建NToolStripButton"
        Me.新建NToolStripButton.Size = New System.Drawing.Size(69, 22)
        Me.新建NToolStripButton.Text = "新增(&N)"
        '
        'ToolStripdelete
        '
        Me.ToolStripdelete.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.清空ToolStripMenuItem})
        Me.ToolStripdelete.Image = CType(resources.GetObject("ToolStripdelete.Image"), System.Drawing.Image)
        Me.ToolStripdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripdelete.Name = "ToolStripdelete"
        Me.ToolStripdelete.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripdelete.Text = "删除(&D)"
        '
        '清空ToolStripMenuItem
        '
        Me.清空ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.Clear
        Me.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem"
        Me.清空ToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.清空ToolStripMenuItem.Text = "全部删除"
        '
        '保存SToolStripButton
        '
        Me.保存SToolStripButton.Image = CType(resources.GetObject("保存SToolStripButton.Image"), System.Drawing.Image)
        Me.保存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.保存SToolStripButton.Name = "保存SToolStripButton"
        Me.保存SToolStripButton.Size = New System.Drawing.Size(66, 22)
        Me.保存SToolStripButton.Text = "保存(&S)"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.klMessage.My.Resources.Resources.accounts
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(75, 22)
        Me.ToolStripButton1.Text = "分配账号"
        '
        'ToolStripExport
        '
        Me.ToolStripExport.Image = CType(resources.GetObject("ToolStripExport.Image"), System.Drawing.Image)
        Me.ToolStripExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripExport.Name = "ToolStripExport"
        Me.ToolStripExport.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripExport.Text = "导出(&E)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        '帮助LToolStripButton
        '
        Me.帮助LToolStripButton.Image = CType(resources.GetObject("帮助LToolStripButton.Image"), System.Drawing.Image)
        Me.帮助LToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.帮助LToolStripButton.Name = "帮助LToolStripButton"
        Me.帮助LToolStripButton.Size = New System.Drawing.Size(68, 22)
        Me.帮助LToolStripButton.Text = "帮助(&H)"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripExit
        '
        Me.ToolStripExit.Image = CType(resources.GetObject("ToolStripExit.Image"), System.Drawing.Image)
        Me.ToolStripExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripExit.Name = "ToolStripExit"
        Me.ToolStripExit.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripExit.Text = "退出(&Q)"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Panel1MinSize = 20
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbLoading)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(784, 514)
        Me.SplitContainer1.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAccountID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CBAccountStatus, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTel, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCompanyName, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEmail, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUserName, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 50)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 25)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "公司名称"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "用户编码"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(199, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "用户名"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(395, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "用户状态"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAccountID
        '
        Me.txtAccountID.Location = New System.Drawing.Point(101, 3)
        Me.txtAccountID.Name = "txtAccountID"
        Me.txtAccountID.Size = New System.Drawing.Size(92, 21)
        Me.txtAccountID.TabIndex = 4
        '
        'CBAccountStatus
        '
        Me.CBAccountStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CBAccountStatus.FormattingEnabled = True
        Me.CBAccountStatus.Items.AddRange(New Object() {"正常", "锁定"})
        Me.CBAccountStatus.Location = New System.Drawing.Point(493, 3)
        Me.CBAccountStatus.Name = "CBAccountStatus"
        Me.CBAccountStatus.Size = New System.Drawing.Size(92, 20)
        Me.CBAccountStatus.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(591, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 25)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "联系电话"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTel
        '
        Me.txtTel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTel.Location = New System.Drawing.Point(689, 3)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(92, 21)
        Me.txtTel.TabIndex = 10
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCompanyName.Location = New System.Drawing.Point(101, 28)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(92, 21)
        Me.txtCompanyName.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(199, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 25)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "电子邮箱"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmail
        '
        Me.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEmail.Location = New System.Drawing.Point(297, 28)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(92, 21)
        Me.txtEmail.TabIndex = 11
        '
        'txtUserName
        '
        Me.txtUserName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUserName.Location = New System.Drawing.Point(297, 3)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(92, 21)
        Me.txtUserName.TabIndex = 13
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected, Me.UserID, Me.UserName, Me.Password, Me.isAdmin, Me.Status, Me.DistributionMode, Me.QueueSize, Me.ShowEchoInfo, Me.NofityNewMessage, Me.AccountManagement, Me.RecieveMessage, Me.ReportStatus, Me.ReportMessage, Me.ReportURL, Me.TotalLimit, Me.TotalSend, Me.CreditLeft, Me.LimitPerday, Me.Tel, Me.CompanyName, Me.EMail, Me.SendThisMonth, Me.SendToday, Me.Remark})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(784, 460)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.VirtualMode = True
        '
        'Selected
        '
        Me.Selected.DataPropertyName = "Selected"
        Me.Selected.FalseValue = "0"
        Me.Selected.Frozen = True
        Me.Selected.HeaderText = "选中"
        Me.Selected.IndeterminateValue = "0"
        Me.Selected.Name = "Selected"
        Me.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Selected.TrueValue = "1"
        Me.Selected.Width = 32
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserCode"
        Me.UserID.HeaderText = "用户编号"
        Me.UserID.Name = "UserID"
        Me.UserID.Width = 61
        '
        'UserName
        '
        Me.UserName.DataPropertyName = "UserName"
        Me.UserName.HeaderText = "用户名"
        Me.UserName.Name = "UserName"
        Me.UserName.Width = 61
        '
        'Password
        '
        Me.Password.DataPropertyName = "Password"
        Me.Password.HeaderText = "密码"
        Me.Password.Name = "Password"
        Me.Password.Width = 51
        '
        'isAdmin
        '
        Me.isAdmin.DataPropertyName = "isAdmin"
        Me.isAdmin.HeaderText = "是否管理员"
        Me.isAdmin.Name = "isAdmin"
        Me.isAdmin.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.isAdmin.Width = 53
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Status.HeaderText = "账号状态"
        Me.Status.Items.AddRange(New Object() {"正常", "锁定"})
        Me.Status.Name = "Status"
        Me.Status.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Status.Width = 61
        '
        'DistributionMode
        '
        Me.DistributionMode.DataPropertyName = "DistributionMode"
        Me.DistributionMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DistributionMode.HeaderText = "帐号分配模式"
        Me.DistributionMode.Items.AddRange(New Object() {"节省资源", "优先发送"})
        Me.DistributionMode.Name = "DistributionMode"
        Me.DistributionMode.Width = 53
        '
        'QueueSize
        '
        Me.QueueSize.DataPropertyName = "QueueSize"
        Me.QueueSize.HeaderText = "队列大小"
        Me.QueueSize.Name = "QueueSize"
        Me.QueueSize.Width = 61
        '
        'ShowEchoInfo
        '
        Me.ShowEchoInfo.DataPropertyName = "ShowEchoInfo"
        Me.ShowEchoInfo.FalseValue = "false"
        Me.ShowEchoInfo.HeaderText = "查看回执"
        Me.ShowEchoInfo.IndeterminateValue = "false"
        Me.ShowEchoInfo.Name = "ShowEchoInfo"
        Me.ShowEchoInfo.TrueValue = "true"
        Me.ShowEchoInfo.Width = 42
        '
        'NofityNewMessage
        '
        Me.NofityNewMessage.DataPropertyName = "NofityNewMessage"
        Me.NofityNewMessage.FalseValue = "False"
        Me.NofityNewMessage.HeaderText = "新短信通知"
        Me.NofityNewMessage.IndeterminateValue = "False"
        Me.NofityNewMessage.Name = "NofityNewMessage"
        Me.NofityNewMessage.TrueValue = "True"
        Me.NofityNewMessage.Width = 53
        '
        'AccountManagement
        '
        Me.AccountManagement.DataPropertyName = "accountManagement"
        Me.AccountManagement.FalseValue = "False"
        Me.AccountManagement.HeaderText = "管理账户"
        Me.AccountManagement.IndeterminateValue = "False"
        Me.AccountManagement.Name = "AccountManagement"
        Me.AccountManagement.TrueValue = "True"
        Me.AccountManagement.Width = 42
        '
        'RecieveMessage
        '
        Me.RecieveMessage.DataPropertyName = "RecieveMessage"
        Me.RecieveMessage.FalseValue = "False"
        Me.RecieveMessage.HeaderText = "查看回复"
        Me.RecieveMessage.IndeterminateValue = "False"
        Me.RecieveMessage.Name = "RecieveMessage"
        Me.RecieveMessage.TrueValue = "True"
        Me.RecieveMessage.Width = 42
        '
        'ReportStatus
        '
        Me.ReportStatus.DataPropertyName = "ReportStatus"
        Me.ReportStatus.FalseValue = "False"
        Me.ReportStatus.HeaderText = "报告短信状态"
        Me.ReportStatus.IndeterminateValue = "False"
        Me.ReportStatus.Name = "ReportStatus"
        Me.ReportStatus.TrueValue = "True"
        Me.ReportStatus.Width = 53
        '
        'ReportMessage
        '
        Me.ReportMessage.DataPropertyName = "ReportMessage"
        Me.ReportMessage.FalseValue = "False"
        Me.ReportMessage.HeaderText = "报告消息"
        Me.ReportMessage.IndeterminateValue = "False"
        Me.ReportMessage.Name = "ReportMessage"
        Me.ReportMessage.TrueValue = "True"
        Me.ReportMessage.Width = 42
        '
        'ReportURL
        '
        Me.ReportURL.DataPropertyName = "ReportURL"
        Me.ReportURL.HeaderText = "报告服务器"
        Me.ReportURL.Name = "ReportURL"
        Me.ReportURL.Width = 72
        '
        'TotalLimit
        '
        Me.TotalLimit.DataPropertyName = "TotalLimit"
        Me.TotalLimit.HeaderText = "总额度"
        Me.TotalLimit.Name = "TotalLimit"
        Me.TotalLimit.Width = 61
        '
        'TotalSend
        '
        Me.TotalSend.DataPropertyName = "TotalSend"
        Me.TotalSend.HeaderText = "总计发送量"
        Me.TotalSend.Name = "TotalSend"
        Me.TotalSend.ReadOnly = True
        Me.TotalSend.Width = 72
        '
        'CreditLeft
        '
        Me.CreditLeft.DataPropertyName = "CreditLeft"
        Me.CreditLeft.HeaderText = "余额"
        Me.CreditLeft.Name = "CreditLeft"
        Me.CreditLeft.ReadOnly = True
        Me.CreditLeft.Width = 51
        '
        'LimitPerday
        '
        Me.LimitPerday.DataPropertyName = "LimitPerday"
        Me.LimitPerday.HeaderText = "每日发送限制"
        Me.LimitPerday.Name = "LimitPerday"
        Me.LimitPerday.Width = 72
        '
        'Tel
        '
        Me.Tel.DataPropertyName = "Tel"
        Me.Tel.HeaderText = "联系电话"
        Me.Tel.Name = "Tel"
        Me.Tel.Width = 61
        '
        'CompanyName
        '
        Me.CompanyName.DataPropertyName = "CompanyName"
        Me.CompanyName.HeaderText = "公司名称"
        Me.CompanyName.Name = "CompanyName"
        Me.CompanyName.Width = 61
        '
        'EMail
        '
        Me.EMail.DataPropertyName = "Email"
        Me.EMail.HeaderText = "电子邮箱"
        Me.EMail.Name = "EMail"
        Me.EMail.Width = 61
        '
        'SendThisMonth
        '
        Me.SendThisMonth.DataPropertyName = "SendThisMonth"
        Me.SendThisMonth.HeaderText = "本月发送量"
        Me.SendThisMonth.Name = "SendThisMonth"
        Me.SendThisMonth.ReadOnly = True
        Me.SendThisMonth.Width = 72
        '
        'SendToday
        '
        Me.SendToday.DataPropertyName = "SendToday"
        Me.SendToday.HeaderText = "本日发送量"
        Me.SendToday.Name = "SendToday"
        Me.SendToday.ReadOnly = True
        Me.SendToday.Width = 72
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.Width = 51
        '
        'frmUserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUserManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "用户管理"
        Me.gbLoading.ResumeLayout(False)
        Me.gbLoading.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbLoading As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents 打开OToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 新建NToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 保存SToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 帮助LToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAccountID As System.Windows.Forms.TextBox
    Friend WithEvents CBAccountStatus As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents 清空ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Password As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isAdmin As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DistributionMode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents QueueSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShowEchoInfo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NofityNewMessage As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AccountManagement As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RecieveMessage As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ReportStatus As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ReportMessage As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ReportURL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalLimit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditLeft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LimitPerday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompanyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendToday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
