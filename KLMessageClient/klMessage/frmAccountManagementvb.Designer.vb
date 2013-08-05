<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountManagement))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssl_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssp_Report = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssl_reportText = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_Position = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.打开OToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.新建NToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripSplitButton()
        Me.全部删除CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存SToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripImport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.批量验证ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.查看验证短信状态ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.立即匹配结果ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.验证配对结果ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripExit = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAccountID = New System.Windows.Forms.TextBox()
        Me.CBAccountType = New System.Windows.Forms.ComboBox()
        Me.CBAccountStatus = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.gbLoading = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.AccountID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Password = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ParentAccountID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParentAccountPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.IdleState = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnterDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReleaseTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalSend_CM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalSend_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalSend_UN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisMonth_CM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisMonth_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisMonth_UN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendToday_CM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendToday_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendToday_UN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisHour_CM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisHour_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisHour_UN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.选中所有行ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.取消选中ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbLoading.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssl_Status, Me.tssp_Report, Me.tssl_reportText, Me.tssl_Position, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.ShowItemToolTips = True
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssl_Status
        '
        Me.tssl_Status.Name = "tssl_Status"
        Me.tssl_Status.Size = New System.Drawing.Size(46, 17)
        Me.tssl_Status.Text = "Ready."
        '
        'tssp_Report
        '
        Me.tssp_Report.Name = "tssp_Report"
        Me.tssp_Report.Size = New System.Drawing.Size(100, 16)
        Me.tssp_Report.Step = 1
        Me.tssp_Report.Visible = False
        '
        'tssl_reportText
        '
        Me.tssl_reportText.Name = "tssl_reportText"
        Me.tssl_reportText.Size = New System.Drawing.Size(32, 17)
        Me.tssl_reportText.Text = "10%"
        Me.tssl_reportText.Visible = False
        '
        'tssl_Position
        '
        Me.tssl_Position.Name = "tssl_Position"
        Me.tssl_Position.Size = New System.Drawing.Size(685, 17)
        Me.tssl_Position.Spring = True
        Me.tssl_Position.Text = "当前第0行,第0列"
        Me.tssl_Position.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开OToolStripButton, Me.ToolStripSeparator4, Me.新建NToolStripButton, Me.ToolStripdelete, Me.保存SToolStripButton, Me.toolStripSeparator, Me.ToolStripImport, Me.ToolStripExport, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.toolStripSeparator1, Me.ToolStripExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 25)
        Me.ToolStrip1.TabIndex = 1
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
        Me.ToolStripdelete.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.全部删除CToolStripMenuItem})
        Me.ToolStripdelete.Image = CType(resources.GetObject("ToolStripdelete.Image"), System.Drawing.Image)
        Me.ToolStripdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripdelete.Name = "ToolStripdelete"
        Me.ToolStripdelete.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripdelete.Text = "删除(&D)"
        '
        '全部删除CToolStripMenuItem
        '
        Me.全部删除CToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.Clear
        Me.全部删除CToolStripMenuItem.Name = "全部删除CToolStripMenuItem"
        Me.全部删除CToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.全部删除CToolStripMenuItem.Text = "全部删除(&C)"
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
        'ToolStripImport
        '
        Me.ToolStripImport.Image = CType(resources.GetObject("ToolStripImport.Image"), System.Drawing.Image)
        Me.ToolStripImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripImport.Name = "ToolStripImport"
        Me.ToolStripImport.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripImport.Text = "导入(&I)"
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.批量验证ToolStripMenuItem, Me.查看验证短信状态ToolStripMenuItem, Me.立即匹配结果ToolStripMenuItem, Me.验证配对结果ToolStripMenuItem})
        Me.ToolStripButton1.Image = Global.klMessage.My.Resources.Resources.Contact_Search
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(111, 22)
        Me.ToolStripButton1.Text = "查找注册账户"
        '
        '批量验证ToolStripMenuItem
        '
        Me.批量验证ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.autoformat_grid
        Me.批量验证ToolStripMenuItem.Name = "批量验证ToolStripMenuItem"
        Me.批量验证ToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.批量验证ToolStripMenuItem.Text = "自动配对选中账户"
        '
        '查看验证短信状态ToolStripMenuItem
        '
        Me.查看验证短信状态ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.Messages
        Me.查看验证短信状态ToolStripMenuItem.Name = "查看验证短信状态ToolStripMenuItem"
        Me.查看验证短信状态ToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.查看验证短信状态ToolStripMenuItem.Text = "查看验证短信状态"
        '
        '立即匹配结果ToolStripMenuItem
        '
        Me.立即匹配结果ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.two_end_arrow
        Me.立即匹配结果ToolStripMenuItem.Name = "立即匹配结果ToolStripMenuItem"
        Me.立即匹配结果ToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.立即匹配结果ToolStripMenuItem.Text = "生成配对结果"
        '
        '验证配对结果ToolStripMenuItem
        '
        Me.验证配对结果ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.Spell_Check
        Me.验证配对结果ToolStripMenuItem.Name = "验证配对结果ToolStripMenuItem"
        Me.验证配对结果ToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.验证配对结果ToolStripMenuItem.Text = "验证选中账户配对结果"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.klMessage.My.Resources.Resources.PrivateQueue
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(99, 22)
        Me.ToolStripButton2.Text = "帐户发送限制"
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
        Me.SplitContainer1.SplitterDistance = 57
        Me.SplitContainer1.TabIndex = 2
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
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpStartDate, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAccountID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CBAccountType, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CBAccountStatus, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBox1, 6, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 57)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dtpEndDate
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpEndDate, 2)
        Me.dtpEndDate.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.dtpEndDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(395, 33)
        Me.dtpEndDate.MinDate = New Date(2013, 5, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(190, 21)
        Me.dtpEndDate.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 27)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "导入时间 从"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(297, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 27)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "到"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpStartDate, 2)
        Me.dtpStartDate.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.dtpStartDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(101, 33)
        Me.dtpStartDate.MinDate = New Date(2013, 5, 1, 0, 0, 0, 0)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(190, 21)
        Me.dtpStartDate.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "账号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(199, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "账号类型"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(395, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 30)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "验证状态"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAccountID
        '
        Me.txtAccountID.Location = New System.Drawing.Point(101, 3)
        Me.txtAccountID.Name = "txtAccountID"
        Me.txtAccountID.Size = New System.Drawing.Size(92, 21)
        Me.txtAccountID.TabIndex = 4
        '
        'CBAccountType
        '
        Me.CBAccountType.FormattingEnabled = True
        Me.CBAccountType.Items.AddRange(New Object() {"注册账号", "访问账号"})
        Me.CBAccountType.Location = New System.Drawing.Point(297, 3)
        Me.CBAccountType.Name = "CBAccountType"
        Me.CBAccountType.Size = New System.Drawing.Size(92, 20)
        Me.CBAccountType.TabIndex = 5
        '
        'CBAccountStatus
        '
        Me.CBAccountStatus.FormattingEnabled = True
        Me.CBAccountStatus.Items.AddRange(New Object() {"已验证", "未验证"})
        Me.CBAccountStatus.Location = New System.Drawing.Point(493, 3)
        Me.CBAccountStatus.Name = "CBAccountStatus"
        Me.CBAccountStatus.Size = New System.Drawing.Size(92, 20)
        Me.CBAccountStatus.TabIndex = 6
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckBox1, 2)
        Me.CheckBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox1.Location = New System.Drawing.Point(591, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(190, 24)
        Me.CheckBox1.TabIndex = 20
        Me.CheckBox1.Text = "包含访问账号"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'gbLoading
        '
        Me.gbLoading.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbLoading.Controls.Add(Me.Label4)
        Me.gbLoading.Controls.Add(Me.PictureBox2)
        Me.gbLoading.Location = New System.Drawing.Point(316, 137)
        Me.gbLoading.Name = "gbLoading"
        Me.gbLoading.Size = New System.Drawing.Size(184, 74)
        Me.gbLoading.TabIndex = 7
        Me.gbLoading.TabStop = False
        Me.gbLoading.Visible = False
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
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected, Me.AccountID, Me.Password, Me.AccountType, Me.ParentAccountID, Me.ParentAccountPassword, Me.AccountStatus, Me.IdleState, Me.Remark, Me.EnterDate, Me.ReleaseTime, Me.TotalSend_CM, Me.TotalSend_TEL, Me.TotalSend_UN, Me.SendThisMonth_CM, Me.SendThisMonth_TEL, Me.SendThisMonth_UN, Me.SendToday_CM, Me.SendToday_TEL, Me.SendToday_UN, Me.SendThisHour_CM, Me.SendThisHour_TEL, Me.SendThisHour_UN})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(784, 453)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.VirtualMode = True
        '
        'Selected
        '
        Me.Selected.DataPropertyName = "Selected"
        Me.Selected.FalseValue = "false"
        Me.Selected.Frozen = True
        Me.Selected.HeaderText = "选中"
        Me.Selected.IndeterminateValue = "false"
        Me.Selected.Name = "Selected"
        Me.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Selected.TrueValue = "true"
        Me.Selected.Width = 32
        '
        'AccountID
        '
        Me.AccountID.DataPropertyName = "AccountID"
        Me.AccountID.Frozen = True
        Me.AccountID.HeaderText = "帐户编号"
        Me.AccountID.Name = "AccountID"
        Me.AccountID.Width = 61
        '
        'Password
        '
        Me.Password.DataPropertyName = "Password"
        Me.Password.Frozen = True
        Me.Password.HeaderText = "密码"
        Me.Password.Name = "Password"
        Me.Password.Width = 51
        '
        'AccountType
        '
        Me.AccountType.DataPropertyName = "AccountType"
        Me.AccountType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AccountType.Frozen = True
        Me.AccountType.HeaderText = "账号类型"
        Me.AccountType.Items.AddRange(New Object() {"注册账号", "访问账号"})
        Me.AccountType.Name = "AccountType"
        Me.AccountType.Width = 42
        '
        'ParentAccountID
        '
        Me.ParentAccountID.DataPropertyName = "ParentAccountID"
        Me.ParentAccountID.Frozen = True
        Me.ParentAccountID.HeaderText = "注册账号"
        Me.ParentAccountID.Name = "ParentAccountID"
        Me.ParentAccountID.Width = 61
        '
        'ParentAccountPassword
        '
        Me.ParentAccountPassword.DataPropertyName = "ParentAccountPassword"
        Me.ParentAccountPassword.Frozen = True
        Me.ParentAccountPassword.HeaderText = "注册账号密码"
        Me.ParentAccountPassword.Name = "ParentAccountPassword"
        Me.ParentAccountPassword.Width = 72
        '
        'AccountStatus
        '
        Me.AccountStatus.DataPropertyName = "AccountStatus"
        Me.AccountStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AccountStatus.Frozen = True
        Me.AccountStatus.HeaderText = "验证状态"
        Me.AccountStatus.Items.AddRange(New Object() {"已验证", "未验证"})
        Me.AccountStatus.Name = "AccountStatus"
        Me.AccountStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AccountStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.AccountStatus.Width = 61
        '
        'IdleState
        '
        Me.IdleState.DataPropertyName = "IdleState"
        Me.IdleState.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.IdleState.HeaderText = "空闲状态"
        Me.IdleState.Items.AddRange(New Object() {"空闲", "占用", "下架"})
        Me.IdleState.Name = "IdleState"
        Me.IdleState.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IdleState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IdleState.Width = 61
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注信息"
        Me.Remark.Name = "Remark"
        Me.Remark.Width = 61
        '
        'EnterDate
        '
        Me.EnterDate.DataPropertyName = "EnterDate"
        Me.EnterDate.HeaderText = "录入时间"
        Me.EnterDate.Name = "EnterDate"
        Me.EnterDate.ReadOnly = True
        Me.EnterDate.Width = 61
        '
        'ReleaseTime
        '
        Me.ReleaseTime.DataPropertyName = "ReleaseTime"
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ReleaseTime.DefaultCellStyle = DataGridViewCellStyle6
        Me.ReleaseTime.HeaderText = "释放时间"
        Me.ReleaseTime.Name = "ReleaseTime"
        Me.ReleaseTime.Width = 61
        '
        'TotalSend_CM
        '
        Me.TotalSend_CM.DataPropertyName = "TotalSend_CM"
        Me.TotalSend_CM.HeaderText = "总计发送|移动"
        Me.TotalSend_CM.Name = "TotalSend_CM"
        Me.TotalSend_CM.ReadOnly = True
        Me.TotalSend_CM.Width = 72
        '
        'TotalSend_TEL
        '
        Me.TotalSend_TEL.DataPropertyName = "TotalSend_TEL"
        Me.TotalSend_TEL.HeaderText = "总计发送|电信"
        Me.TotalSend_TEL.Name = "TotalSend_TEL"
        Me.TotalSend_TEL.ReadOnly = True
        Me.TotalSend_TEL.Width = 72
        '
        'TotalSend_UN
        '
        Me.TotalSend_UN.DataPropertyName = "TotalSend_UN"
        Me.TotalSend_UN.HeaderText = "总计发送|联通"
        Me.TotalSend_UN.Name = "TotalSend_UN"
        Me.TotalSend_UN.ReadOnly = True
        Me.TotalSend_UN.Width = 72
        '
        'SendThisMonth_CM
        '
        Me.SendThisMonth_CM.DataPropertyName = "SendThisMonth_CM"
        Me.SendThisMonth_CM.HeaderText = "本月发送量|移动"
        Me.SendThisMonth_CM.Name = "SendThisMonth_CM"
        Me.SendThisMonth_CM.ReadOnly = True
        Me.SendThisMonth_CM.Width = 88
        '
        'SendThisMonth_TEL
        '
        Me.SendThisMonth_TEL.DataPropertyName = "SendThisMonth_TEL"
        Me.SendThisMonth_TEL.HeaderText = "本月发送量|电信"
        Me.SendThisMonth_TEL.Name = "SendThisMonth_TEL"
        Me.SendThisMonth_TEL.ReadOnly = True
        Me.SendThisMonth_TEL.Width = 88
        '
        'SendThisMonth_UN
        '
        Me.SendThisMonth_UN.DataPropertyName = "SendThisMonth_UN"
        Me.SendThisMonth_UN.HeaderText = "本月发送量|联通"
        Me.SendThisMonth_UN.Name = "SendThisMonth_UN"
        Me.SendThisMonth_UN.ReadOnly = True
        Me.SendThisMonth_UN.Width = 88
        '
        'SendToday_CM
        '
        Me.SendToday_CM.DataPropertyName = "SendToday_CM"
        Me.SendToday_CM.HeaderText = "当日发送量|移动"
        Me.SendToday_CM.Name = "SendToday_CM"
        Me.SendToday_CM.ReadOnly = True
        Me.SendToday_CM.Width = 88
        '
        'SendToday_TEL
        '
        Me.SendToday_TEL.DataPropertyName = "SendToday_TEL"
        Me.SendToday_TEL.HeaderText = "当日发送量|电信"
        Me.SendToday_TEL.Name = "SendToday_TEL"
        Me.SendToday_TEL.ReadOnly = True
        Me.SendToday_TEL.Width = 88
        '
        'SendToday_UN
        '
        Me.SendToday_UN.DataPropertyName = "SendToday_UN"
        Me.SendToday_UN.HeaderText = "当日发送量|联通"
        Me.SendToday_UN.Name = "SendToday_UN"
        Me.SendToday_UN.ReadOnly = True
        Me.SendToday_UN.Width = 88
        '
        'SendThisHour_CM
        '
        Me.SendThisHour_CM.DataPropertyName = "SendThisHour_CM"
        Me.SendThisHour_CM.HeaderText = "当前时段发送量|移动"
        Me.SendThisHour_CM.Name = "SendThisHour_CM"
        Me.SendThisHour_CM.ReadOnly = True
        Me.SendThisHour_CM.Width = 94
        '
        'SendThisHour_TEL
        '
        Me.SendThisHour_TEL.DataPropertyName = "SendThisHour_TEL"
        Me.SendThisHour_TEL.HeaderText = "当前时段发送量|电信"
        Me.SendThisHour_TEL.Name = "SendThisHour_TEL"
        Me.SendThisHour_TEL.ReadOnly = True
        Me.SendThisHour_TEL.Width = 94
        '
        'SendThisHour_UN
        '
        Me.SendThisHour_UN.DataPropertyName = "SendThisHour_UN"
        Me.SendThisHour_UN.HeaderText = "当前时段发送量|联通"
        Me.SendThisHour_UN.Name = "SendThisHour_UN"
        Me.SendThisHour_UN.ReadOnly = True
        Me.SendThisHour_UN.Width = 94
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.选中所有行ToolStripMenuItem, Me.取消选中ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(123, 54)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(119, 6)
        '
        '选中所有行ToolStripMenuItem
        '
        Me.选中所有行ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.box_checked_all_over
        Me.选中所有行ToolStripMenuItem.Name = "选中所有行ToolStripMenuItem"
        Me.选中所有行ToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.选中所有行ToolStripMenuItem.Text = "选中所有"
        '
        '取消选中ToolStripMenuItem
        '
        Me.取消选中ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.box_unchecked_all
        Me.取消选中ToolStripMenuItem.Name = "取消选中ToolStripMenuItem"
        Me.取消选中ToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.取消选中ToolStripMenuItem.Text = "取消全选"
        '
        'frmAccountManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAccountManagement"
        Me.Text = "帐户管理"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gbLoading.ResumeLayout(False)
        Me.gbLoading.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents 新建NToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 打开OToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 保存SToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAccountID As System.Windows.Forms.TextBox
    Friend WithEvents CBAccountType As System.Windows.Forms.ComboBox
    Friend WithEvents CBAccountStatus As System.Windows.Forms.ComboBox
    Friend WithEvents gbLoading As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents 批量验证ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tssl_Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssp_Report As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tssl_reportText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents 立即匹配结果ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents 全部删除CToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 验证配对结果ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents tssl_Position As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 选中所有行ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 取消选中ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AccountID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Password As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ParentAccountID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParentAccountPassword As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents IdleState As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnterDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReleaseTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSend_CM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSend_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSend_UN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisMonth_CM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisMonth_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisMonth_UN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendToday_CM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendToday_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendToday_UN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisHour_CM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisHour_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisHour_UN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 查看验证短信状态ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
