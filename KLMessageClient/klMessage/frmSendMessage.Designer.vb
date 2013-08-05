<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendMessage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendMessage))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtMessage = New System.Windows.Forms.RichTextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.tscbInvockPersecond = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.tscbMaxBatchNumber = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tst_QueueSize = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.gridLog = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbInput = New System.Windows.Forms.RadioButton()
        Me.rbImport = New System.Windows.Forms.RadioButton()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtRecipients = New System.Windows.Forms.RichTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssl_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_发送进度 = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssl_Speed = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_字数 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_短信条数 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.暂停PToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.终止发送EToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.仅找出关键字ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.刷新关键字列表ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关键字管理ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSplitButton2 = New System.Windows.Forms.ToolStripSplitButton()
        Me.CheckBox1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckBox2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssm_addEnd = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkShowDebugInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.忽略重复号码ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss_timer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMessage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gridLog)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(784, 539)
        Me.SplitContainer1.SplitterDistance = 190
        Me.SplitContainer1.TabIndex = 0
        '
        'txtMessage
        '
        Me.txtMessage.AutoWordSelection = True
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMessage.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtMessage.Location = New System.Drawing.Point(0, 31)
        Me.txtMessage.MaxLength = 300
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(784, 159)
        Me.txtMessage.TabIndex = 1
        Me.txtMessage.Text = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripLabel5, Me.tscbInvockPersecond, Me.ToolStripLabel6, Me.ToolStripLabel3, Me.ToolStripLabel4, Me.tscbMaxBatchNumber, Me.ToolStripLabel7, Me.ToolStripLabel1, Me.tst_QueueSize, Me.ToolStripSeparator2, Me.ToolStripSplitButton1, Me.ToolStripButton2, Me.ToolStripSplitButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(55, 28)
        Me.ToolStripLabel5.Text = "每秒发送"
        '
        'tscbInvockPersecond
        '
        Me.tscbInvockPersecond.Items.AddRange(New Object() {"自动", "10", "20", "50", "100"})
        Me.tscbInvockPersecond.Name = "tscbInvockPersecond"
        Me.tscbInvockPersecond.Size = New System.Drawing.Size(75, 31)
        Me.tscbInvockPersecond.Text = "自动"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(22, 28)
        Me.ToolStripLabel6.Text = "次,"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(55, 28)
        Me.ToolStripLabel3.Text = "每批发送"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(0, 28)
        Me.ToolStripLabel4.Text = "ToolStripLabel4"
        '
        'tscbMaxBatchNumber
        '
        Me.tscbMaxBatchNumber.Items.AddRange(New Object() {"10", "100", "1000", "20", "200", "50", "500", "自动"})
        Me.tscbMaxBatchNumber.Name = "tscbMaxBatchNumber"
        Me.tscbMaxBatchNumber.Size = New System.Drawing.Size(75, 31)
        Me.tscbMaxBatchNumber.Sorted = True
        Me.tscbMaxBatchNumber.Text = "自动"
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(31, 28)
        Me.ToolStripLabel7.Text = "号码"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(55, 28)
        Me.ToolStripLabel1.Text = "队列大小"
        '
        'tst_QueueSize
        '
        Me.tst_QueueSize.Items.AddRange(New Object() {"自动", "1000", "3000", "5000"})
        Me.tst_QueueSize.Name = "tst_QueueSize"
        Me.tst_QueueSize.Size = New System.Drawing.Size(75, 31)
        Me.tst_QueueSize.Text = "自动"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'gridLog
        '
        Me.gridLog.AllowColumnReorder = True
        Me.gridLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader2, Me.ColumnHeader4})
        Me.gridLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridLog.FullRowSelect = True
        Me.gridLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.gridLog.Location = New System.Drawing.Point(0, 116)
        Me.gridLog.Name = "gridLog"
        Me.gridLog.Size = New System.Drawing.Size(784, 229)
        Me.gridLog.SmallImageList = Me.ImageList1
        Me.gridLog.StateImageList = Me.ImageList1
        Me.gridLog.TabIndex = 8
        Me.gridLog.UseCompatibleStateImageBehavior = False
        Me.gridLog.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "发送状态"
        Me.ColumnHeader1.Width = 90
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "发送时间"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "收件人"
        Me.ColumnHeader2.Width = 400
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "说明"
        Me.ColumnHeader4.Width = 200
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ok.ico")
        Me.ImageList1.Images.SetKeyName(1, "error.ico")
        Me.ImageList1.Images.SetKeyName(2, "right.ico")
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.rbInput, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbImport, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRecipients, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 116)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'rbInput
        '
        Me.rbInput.Checked = True
        Me.rbInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbInput.Location = New System.Drawing.Point(4, 4)
        Me.rbInput.Name = "rbInput"
        Me.rbInput.Size = New System.Drawing.Size(114, 74)
        Me.rbInput.TabIndex = 2
        Me.rbInput.TabStop = True
        Me.rbInput.Text = "输入联系人(0人)"
        Me.rbInput.UseVisualStyleBackColor = True
        '
        'rbImport
        '
        Me.rbImport.Dock = System.Windows.Forms.DockStyle.Top
        Me.rbImport.Location = New System.Drawing.Point(4, 85)
        Me.rbImport.Name = "rbImport"
        Me.rbImport.Size = New System.Drawing.Size(114, 26)
        Me.rbImport.TabIndex = 4
        Me.rbImport.Text = "导入联系人"
        Me.rbImport.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.txtFileName)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(125, 85)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(801, 29)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'txtFileName
        '
        Me.txtFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileName.BackColor = System.Drawing.SystemColors.Window
        Me.txtFileName.Location = New System.Drawing.Point(3, 3)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(575, 21)
        Me.txtFileName.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(584, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "浏览文件.."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtRecipients
        '
        Me.txtRecipients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRecipients.Location = New System.Drawing.Point(125, 4)
        Me.txtRecipients.Name = "txtRecipients"
        Me.txtRecipients.Size = New System.Drawing.Size(801, 74)
        Me.txtRecipients.TabIndex = 5
        Me.txtRecipients.Text = ""
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssl_Status, Me.tss_timer, Me.tssl_发送进度, Me.tssl_Speed, Me.tssl_字数, Me.tssl_短信条数})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssl_Status
        '
        Me.tssl_Status.Name = "tssl_Status"
        Me.tssl_Status.Size = New System.Drawing.Size(82, 17)
        Me.tssl_Status.Text = "状态:编辑短信"
        '
        'tssl_发送进度
        '
        Me.tssl_发送进度.Name = "tssl_发送进度"
        Me.tssl_发送进度.Size = New System.Drawing.Size(100, 16)
        Me.tssl_发送进度.Step = 1
        Me.tssl_发送进度.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tssl_发送进度.Visible = False
        '
        'tssl_Speed
        '
        Me.tssl_Speed.Name = "tssl_Speed"
        Me.tssl_Speed.Size = New System.Drawing.Size(43, 17)
        Me.tssl_Speed.Text = "0条/秒"
        Me.tssl_Speed.Visible = False
        '
        'tssl_字数
        '
        Me.tssl_字数.Name = "tssl_字数"
        Me.tssl_字数.Size = New System.Drawing.Size(388, 17)
        Me.tssl_字数.Spring = True
        Me.tssl_字数.Text = "已录入:00字"
        Me.tssl_字数.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tssl_短信条数
        '
        Me.tssl_短信条数.Name = "tssl_短信条数"
        Me.tssl_短信条数.Size = New System.Drawing.Size(81, 17)
        Me.tssl_短信条数.Text = "共计00条短信"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.暂停PToolStripMenuItem, Me.终止发送EToolStripMenuItem})
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(71, 28)
        Me.ToolStripButton1.Text = "发送"
        '
        '暂停PToolStripMenuItem
        '
        Me.暂停PToolStripMenuItem.Name = "暂停PToolStripMenuItem"
        Me.暂停PToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.暂停PToolStripMenuItem.Text = "暂停发送(&P)"
        '
        '终止发送EToolStripMenuItem
        '
        Me.终止发送EToolStripMenuItem.Name = "终止发送EToolStripMenuItem"
        Me.终止发送EToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.终止发送EToolStripMenuItem.Text = "终止发送(&E)"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.仅找出关键字ToolStripMenuItem, Me.刷新关键字列表ToolStripMenuItem, Me.关键字管理ToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = Global.klMessage.My.Resources.Resources.wordicon_exe_207_
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(99, 28)
        Me.ToolStripSplitButton1.Text = "处理关键字"
        '
        '仅找出关键字ToolStripMenuItem
        '
        Me.仅找出关键字ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.find1
        Me.仅找出关键字ToolStripMenuItem.Name = "仅找出关键字ToolStripMenuItem"
        Me.仅找出关键字ToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.仅找出关键字ToolStripMenuItem.Text = "仅找出关键字"
        '
        '刷新关键字列表ToolStripMenuItem
        '
        Me.刷新关键字列表ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.db_refresh
        Me.刷新关键字列表ToolStripMenuItem.Name = "刷新关键字列表ToolStripMenuItem"
        Me.刷新关键字列表ToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.刷新关键字列表ToolStripMenuItem.Text = "获取关键字列表"
        '
        '关键字管理ToolStripMenuItem
        '
        Me.关键字管理ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources.key
        Me.关键字管理ToolStripMenuItem.Name = "关键字管理ToolStripMenuItem"
        Me.关键字管理ToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.关键字管理ToolStripMenuItem.Text = "关键字管理"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.klMessage.My.Resources.Resources.Foxmail_exe_146_
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(75, 28)
        Me.ToolStripButton2.Text = "发送状态"
        '
        'ToolStripSplitButton2
        '
        Me.ToolStripSplitButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckBox1, Me.CheckBox2, Me.tssm_addEnd, Me.chkShowDebugInfo, Me.忽略重复号码ToolStripMenuItem})
        Me.ToolStripSplitButton2.Image = Global.klMessage.My.Resources.Resources.options
        Me.ToolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton2.Name = "ToolStripSplitButton2"
        Me.ToolStripSplitButton2.Size = New System.Drawing.Size(87, 20)
        Me.ToolStripSplitButton2.Text = "高级选项"
        '
        'CheckBox1
        '
        Me.CheckBox1.CheckOnClick = True
        Me.CheckBox1.Image = Global.klMessage.My.Resources.Resources.message1
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(170, 22)
        Me.CheckBox1.Text = "仅模拟发送"
        Me.CheckBox1.ToolTipText = "除了真实发送短信那一步,其他步骤都会执行"
        Me.CheckBox1.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.CheckOnClick = True
        Me.CheckBox2.Image = Global.klMessage.My.Resources.Resources.Record24
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(170, 22)
        Me.CheckBox2.Text = "本地记录日志"
        Me.CheckBox2.ToolTipText = "将发送记录写入系统所以目录的data文件平下"
        '
        'tssm_addEnd
        '
        Me.tssm_addEnd.CheckOnClick = True
        Me.tssm_addEnd.Image = Global.klMessage.My.Resources.Resources.addin
        Me.tssm_addEnd.Name = "tssm_addEnd"
        Me.tssm_addEnd.Size = New System.Drawing.Size(170, 22)
        Me.tssm_addEnd.Text = "末尾自动增加符号"
        Me.tssm_addEnd.ToolTipText = "此选项通过在短信末尾增加一个随机符号可以让每条短信都不同,提升发送成功率,但会增长短信."
        '
        'chkShowDebugInfo
        '
        Me.chkShowDebugInfo.CheckOnClick = True
        Me.chkShowDebugInfo.Image = Global.klMessage.My.Resources.Resources.cmd
        Me.chkShowDebugInfo.Name = "chkShowDebugInfo"
        Me.chkShowDebugInfo.Size = New System.Drawing.Size(170, 22)
        Me.chkShowDebugInfo.Text = "显示调试信息"
        Me.chkShowDebugInfo.Visible = False
        '
        '忽略重复号码ToolStripMenuItem
        '
        Me.忽略重复号码ToolStripMenuItem.CheckOnClick = True
        Me.忽略重复号码ToolStripMenuItem.Image = Global.klMessage.My.Resources.Resources._double
        Me.忽略重复号码ToolStripMenuItem.Name = "忽略重复号码ToolStripMenuItem"
        Me.忽略重复号码ToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.忽略重复号码ToolStripMenuItem.Text = "忽略重复号码"
        '
        'tss_timer
        '
        Me.tss_timer.Image = Global.klMessage.My.Resources.Resources.clock
        Me.tss_timer.Name = "tss_timer"
        Me.tss_timer.Size = New System.Drawing.Size(42, 17)
        Me.tss_timer.Text = "0秒"
        Me.tss_timer.Visible = False
        '
        'frmSendMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSendMessage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "发送消息"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbInput As System.Windows.Forms.RadioButton
    Friend WithEvents rbImport As System.Windows.Forms.RadioButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tssl_Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssl_字数 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssl_短信条数 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssl_发送进度 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tss_timer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents gridLog As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtRecipients As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbInvockPersecond As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbMaxBatchNumber As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel7 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tssl_Speed As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents 关键字管理ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 仅找出关键字ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 刷新关键字列表ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSplitButton2 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckBox2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tssm_addEnd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tst_QueueSize As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents 暂停PToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 终止发送EToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkShowDebugInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 忽略重复号码ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
