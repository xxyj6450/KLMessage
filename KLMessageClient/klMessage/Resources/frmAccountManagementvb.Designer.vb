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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountManagement))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.打开OToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.新建NToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton()
        Me.保存SToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripImport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.帮助LToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripExit = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAccountID = New System.Windows.Forms.TextBox()
        Me.CBAccountType = New System.Windows.Forms.ComboBox()
        Me.CBAccountStatus = New System.Windows.Forms.ComboBox()
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
        Me.CheckState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdleState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReleaseTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.theMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.theDay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.theHour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisMonth_CM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisMonth_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisMonth_UN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendToday_CM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendToday_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendToday_UN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisHour_CM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisHour_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendThisHour_UN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbLoading.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 315)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(977, 22)
        Me.StatusStrip1.TabIndex = 0
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开OToolStripButton, Me.ToolStripSeparator4, Me.新建NToolStripButton, Me.ToolStripdelete, Me.保存SToolStripButton, Me.toolStripSeparator, Me.ToolStripImport, Me.ToolStripExport, Me.ToolStripSeparator2, Me.帮助LToolStripButton, Me.toolStripSeparator1, Me.ToolStripExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(977, 25)
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
        Me.新建NToolStripButton.Image = CType(resources.GetObject("新建NToolStripButton.Image"), System.Drawing.Image)
        Me.新建NToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.新建NToolStripButton.Name = "新建NToolStripButton"
        Me.新建NToolStripButton.Size = New System.Drawing.Size(69, 22)
        Me.新建NToolStripButton.Text = "新增(&N)"
        '
        'ToolStripdelete
        '
        Me.ToolStripdelete.Image = CType(resources.GetObject("ToolStripdelete.Image"), System.Drawing.Image)
        Me.ToolStripdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripdelete.Name = "ToolStripdelete"
        Me.ToolStripdelete.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripdelete.Text = "删除(&D)"
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
        Me.SplitContainer1.Size = New System.Drawing.Size(977, 290)
        Me.SplitContainer1.SplitterDistance = 29
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
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAccountID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CBAccountType, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CBAccountStatus, 5, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(977, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "账号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(247, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "账号类型"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(491, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 30)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "验证状态"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAccountID
        '
        Me.txtAccountID.Location = New System.Drawing.Point(125, 3)
        Me.txtAccountID.Name = "txtAccountID"
        Me.txtAccountID.Size = New System.Drawing.Size(100, 21)
        Me.txtAccountID.TabIndex = 4
        '
        'CBAccountType
        '
        Me.CBAccountType.FormattingEnabled = True
        Me.CBAccountType.Items.AddRange(New Object() {"注册账号", "访问账号"})
        Me.CBAccountType.Location = New System.Drawing.Point(369, 3)
        Me.CBAccountType.Name = "CBAccountType"
        Me.CBAccountType.Size = New System.Drawing.Size(116, 20)
        Me.CBAccountType.TabIndex = 5
        '
        'CBAccountStatus
        '
        Me.CBAccountStatus.FormattingEnabled = True
        Me.CBAccountStatus.Items.AddRange(New Object() {"已验证", "未验证"})
        Me.CBAccountStatus.Location = New System.Drawing.Point(613, 3)
        Me.CBAccountStatus.Name = "CBAccountStatus"
        Me.CBAccountStatus.Size = New System.Drawing.Size(116, 20)
        Me.CBAccountStatus.TabIndex = 6
        '
        'gbLoading
        '
        Me.gbLoading.Controls.Add(Me.Label4)
        Me.gbLoading.Controls.Add(Me.PictureBox2)
        Me.gbLoading.Location = New System.Drawing.Point(396, 91)
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
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected, Me.AccountID, Me.Password, Me.AccountType, Me.ParentAccountID, Me.ParentAccountPassword, Me.CheckState, Me.IdleState, Me.ReleaseTime, Me.theMonth, Me.theDay, Me.theHour, Me.SendThisMonth_CM, Me.SendThisMonth_TEL, Me.SendThisMonth_UN, Me.SendToday_CM, Me.SendToday_TEL, Me.SendToday_UN, Me.SendThisHour_CM, Me.SendThisHour_TEL, Me.SendThisHour_UN})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(977, 257)
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
        'CheckState
        '
        Me.CheckState.DataPropertyName = "AccountStatus"
        Me.CheckState.HeaderText = "验证状态"
        Me.CheckState.Name = "CheckState"
        Me.CheckState.ReadOnly = True
        Me.CheckState.Width = 61
        '
        'IdleState
        '
        Me.IdleState.DataPropertyName = "IdleState"
        Me.IdleState.HeaderText = "空闲状态"
        Me.IdleState.Name = "IdleState"
        Me.IdleState.ReadOnly = True
        Me.IdleState.Width = 61
        '
        'ReleaseTime
        '
        Me.ReleaseTime.DataPropertyName = "ReleaseTime"
        Me.ReleaseTime.HeaderText = "释放时间"
        Me.ReleaseTime.Name = "ReleaseTime"
        Me.ReleaseTime.ReadOnly = True
        Me.ReleaseTime.Width = 61
        '
        'theMonth
        '
        Me.theMonth.DataPropertyName = "theMonth"
        Me.theMonth.HeaderText = "当前月份"
        Me.theMonth.Name = "theMonth"
        Me.theMonth.ReadOnly = True
        Me.theMonth.Width = 61
        '
        'theDay
        '
        Me.theDay.DataPropertyName = "theDay"
        Me.theDay.HeaderText = "当前日期"
        Me.theDay.Name = "theDay"
        Me.theDay.ReadOnly = True
        Me.theDay.Width = 61
        '
        'theHour
        '
        Me.theHour.DataPropertyName = "theHour"
        Me.theHour.HeaderText = "当前小时"
        Me.theHour.Name = "theHour"
        Me.theHour.ReadOnly = True
        Me.theHour.Width = 61
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
        'frmAccountManagementvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(977, 337)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmAccountManagementvb"
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
    Friend WithEvents 帮助LToolStripButton As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AccountID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Password As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ParentAccountID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParentAccountPassword As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckState As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdleState As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReleaseTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents theMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents theDay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents theHour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisMonth_CM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisMonth_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisMonth_UN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendToday_CM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendToday_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendToday_UN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisHour_CM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisHour_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendThisHour_UN As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
