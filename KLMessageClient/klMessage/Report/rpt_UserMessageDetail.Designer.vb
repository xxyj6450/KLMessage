<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rpt_UserMessageDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rpt_UserMessageDetail))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripExport = New System.Windows.Forms.ToolStripButton()
        Me.打开OToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssl_Position = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.帮助LToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbLoading = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtSessionID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAccountID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.txtContent = New System.Windows.Forms.TextBox()
        Me.SessionID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usercode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.content = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContentLength = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FeeLength = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Messatetype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.applyCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendFailCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EchoFailCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EchoFailedPercent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOEchoCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EchoSuccessCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.begindate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.enddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.timeused = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.speed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLoading.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripExit
        '
        Me.ToolStripExit.Image = CType(resources.GetObject("ToolStripExit.Image"), System.Drawing.Image)
        Me.ToolStripExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripExit.Name = "ToolStripExit"
        Me.ToolStripExit.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripExit.Text = "退出(&Q)"
        '
        'ToolStripExport
        '
        Me.ToolStripExport.Image = CType(resources.GetObject("ToolStripExport.Image"), System.Drawing.Image)
        Me.ToolStripExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripExport.Name = "ToolStripExport"
        Me.ToolStripExport.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripExport.Text = "导出(&E)"
        '
        '打开OToolStripButton
        '
        Me.打开OToolStripButton.Image = CType(resources.GetObject("打开OToolStripButton.Image"), System.Drawing.Image)
        Me.打开OToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.打开OToolStripButton.Name = "打开OToolStripButton"
        Me.打开OToolStripButton.Size = New System.Drawing.Size(69, 22)
        Me.打开OToolStripButton.Text = "查询(&Q)"
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
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssl_Position, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssl_Position
        '
        Me.tssl_Position.Name = "tssl_Position"
        Me.tssl_Position.Size = New System.Drawing.Size(731, 17)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开OToolStripButton, Me.ToolStripSeparator4, Me.ToolStripButton2, Me.ToolStripButton1, Me.toolStripSeparator, Me.ToolStripExport, Me.ToolStripSeparator2, Me.帮助LToolStripButton, Me.ToolStripExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 25)
        Me.ToolStrip1.TabIndex = 13
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.klMessage.My.Resources.Resources.Report
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(75, 22)
        Me.ToolStripButton2.Text = "短信状态"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.klMessage.My.Resources.Resources.Report
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(75, 22)
        Me.ToolStripButton1.Text = "短信汇总"
        '
        '帮助LToolStripButton
        '
        Me.帮助LToolStripButton.Image = CType(resources.GetObject("帮助LToolStripButton.Image"), System.Drawing.Image)
        Me.帮助LToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.帮助LToolStripButton.Name = "帮助LToolStripButton"
        Me.帮助LToolStripButton.Size = New System.Drawing.Size(68, 22)
        Me.帮助LToolStripButton.Text = "帮助(&H)"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DataGridView1.ColumnHeadersHeight = 46
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SessionID, Me.Usercode, Me.content, Me.ContentLength, Me.FeeLength, Me.Messatetype, Me.applyCount, Me.SendCount, Me.SendFailCount, Me.EchoFailCount, Me.EchoFailedPercent, Me.NOEchoCount, Me.EchoSuccessCount, Me.begindate, Me.enddate, Me.timeused, Me.speed, Me.IP})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(784, 458)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.VirtualMode = True
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
        Me.gbLoading.Location = New System.Drawing.Point(312, 138)
        Me.gbLoading.Name = "gbLoading"
        Me.gbLoading.Size = New System.Drawing.Size(184, 74)
        Me.gbLoading.TabIndex = 7
        Me.gbLoading.TabStop = False
        Me.gbLoading.Visible = False
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
        Me.SplitContainer1.SplitterDistance = 52
        Me.SplitContainer1.TabIndex = 14
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
        Me.TableLayoutPanel1.Controls.Add(Me.txtSessionID, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAccountID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpStartDate, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtContent, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 52)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'txtSessionID
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtSessionID, 3)
        Me.txtSessionID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSessionID.Location = New System.Drawing.Point(493, 28)
        Me.txtSessionID.Name = "txtSessionID"
        Me.txtSessionID.Size = New System.Drawing.Size(288, 21)
        Me.txtSessionID.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(395, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 27)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "会话"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(3, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 27)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "短信内容"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpEndDate, 2)
        Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpEndDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(591, 3)
        Me.dtpEndDate.MinDate = New Date(2013, 5, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(190, 21)
        Me.dtpEndDate.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(199, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 25)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "起始时间"
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
        'txtAccountID
        '
        Me.txtAccountID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAccountID.Location = New System.Drawing.Point(101, 3)
        Me.txtAccountID.Name = "txtAccountID"
        Me.txtAccountID.Size = New System.Drawing.Size(92, 21)
        Me.txtAccountID.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(493, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 25)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "结束时间"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpStartDate, 2)
        Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpStartDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(297, 3)
        Me.dtpStartDate.MinDate = New Date(2013, 5, 1, 0, 0, 0, 0)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(190, 21)
        Me.dtpStartDate.TabIndex = 14
        '
        'txtContent
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtContent, 3)
        Me.txtContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtContent.Location = New System.Drawing.Point(101, 28)
        Me.txtContent.Name = "txtContent"
        Me.txtContent.Size = New System.Drawing.Size(288, 21)
        Me.txtContent.TabIndex = 20
        '
        'SessionID
        '
        Me.SessionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SessionID.DataPropertyName = "SessionID"
        Me.SessionID.HeaderText = "SessionID"
        Me.SessionID.Name = "SessionID"
        Me.SessionID.Visible = False
        Me.SessionID.Width = 60
        '
        'Usercode
        '
        Me.Usercode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Usercode.DataPropertyName = "Usercode"
        Me.Usercode.HeaderText = "用户编码"
        Me.Usercode.Name = "Usercode"
        Me.Usercode.ReadOnly = True
        Me.Usercode.Width = 50
        '
        'content
        '
        Me.content.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.content.DataPropertyName = "content"
        Me.content.HeaderText = "短信内容"
        Me.content.Name = "content"
        Me.content.Width = 250
        '
        'ContentLength
        '
        Me.ContentLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ContentLength.DataPropertyName = "ContentLength"
        Me.ContentLength.HeaderText = "短信长度"
        Me.ContentLength.Name = "ContentLength"
        Me.ContentLength.Width = 40
        '
        'FeeLength
        '
        Me.FeeLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.FeeLength.DataPropertyName = "FeeLength"
        Me.FeeLength.HeaderText = "计费长度"
        Me.FeeLength.Name = "FeeLength"
        Me.FeeLength.Width = 40
        '
        'Messatetype
        '
        Me.Messatetype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Messatetype.DataPropertyName = "Messatetype"
        Me.Messatetype.HeaderText = "短信类型"
        Me.Messatetype.Name = "Messatetype"
        Me.Messatetype.Width = 60
        '
        'applyCount
        '
        Me.applyCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.applyCount.DataPropertyName = "applyCount"
        Me.applyCount.HeaderText = "申请数量"
        Me.applyCount.Name = "applyCount"
        Me.applyCount.Width = 40
        '
        'SendCount
        '
        Me.SendCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SendCount.DataPropertyName = "SendCount"
        Me.SendCount.HeaderText = "短信提交量"
        Me.SendCount.Name = "SendCount"
        Me.SendCount.ReadOnly = True
        Me.SendCount.Width = 40
        '
        'SendFailCount
        '
        Me.SendFailCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SendFailCount.DataPropertyName = "SendFailCount"
        Me.SendFailCount.HeaderText = "发送失败量"
        Me.SendFailCount.Name = "SendFailCount"
        Me.SendFailCount.ReadOnly = True
        Me.SendFailCount.Width = 40
        '
        'EchoFailCount
        '
        Me.EchoFailCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.EchoFailCount.DataPropertyName = "EchoFailCount"
        Me.EchoFailCount.HeaderText = "回执失败量"
        Me.EchoFailCount.Name = "EchoFailCount"
        Me.EchoFailCount.ReadOnly = True
        Me.EchoFailCount.Width = 40
        '
        'EchoFailedPercent
        '
        Me.EchoFailedPercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.EchoFailedPercent.DataPropertyName = "EchoFailedPercent"
        Me.EchoFailedPercent.HeaderText = "回执失败率(%)"
        Me.EchoFailedPercent.Name = "EchoFailedPercent"
        Me.EchoFailedPercent.Width = 61
        '
        'NOEchoCount
        '
        Me.NOEchoCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NOEchoCount.DataPropertyName = "NOEchoCount"
        Me.NOEchoCount.HeaderText = "无回执量"
        Me.NOEchoCount.Name = "NOEchoCount"
        Me.NOEchoCount.ReadOnly = True
        Me.NOEchoCount.Width = 40
        '
        'EchoSuccessCount
        '
        Me.EchoSuccessCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.EchoSuccessCount.DataPropertyName = "EchoSuccessCount"
        Me.EchoSuccessCount.HeaderText = "回执成功量"
        Me.EchoSuccessCount.Name = "EchoSuccessCount"
        Me.EchoSuccessCount.ReadOnly = True
        Me.EchoSuccessCount.Width = 40
        '
        'begindate
        '
        Me.begindate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.begindate.DataPropertyName = "begindate"
        DataGridViewCellStyle2.Format = "G"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.begindate.DefaultCellStyle = DataGridViewCellStyle2
        Me.begindate.HeaderText = "开始发送时间"
        Me.begindate.Name = "begindate"
        Me.begindate.Width = 61
        '
        'enddate
        '
        Me.enddate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.enddate.DataPropertyName = "enddate"
        DataGridViewCellStyle3.Format = "G"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.enddate.DefaultCellStyle = DataGridViewCellStyle3
        Me.enddate.HeaderText = "最后发送时间"
        Me.enddate.Name = "enddate"
        Me.enddate.Width = 61
        '
        'timeused
        '
        Me.timeused.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.timeused.DataPropertyName = "timeused"
        Me.timeused.HeaderText = "用时(s)"
        Me.timeused.Name = "timeused"
        Me.timeused.Width = 40
        '
        'speed
        '
        Me.speed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.speed.DataPropertyName = "speed"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.speed.DefaultCellStyle = DataGridViewCellStyle4
        Me.speed.HeaderText = "速度(条/s)"
        Me.speed.Name = "speed"
        Me.speed.Width = 40
        '
        'IP
        '
        Me.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.IP.DataPropertyName = "IP"
        Me.IP.HeaderText = "发送IP"
        Me.IP.Name = "IP"
        Me.IP.Width = 51
        '
        'rpt_UserMessageDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "rpt_UserMessageDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "用户短信明细"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLoading.ResumeLayout(False)
        Me.gbLoading.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents 打开OToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tssl_Position As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents 帮助LToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbLoading As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtSessionID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAccountID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents SessionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usercode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents content As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContentLength As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeeLength As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Messatetype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents applyCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendFailCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EchoFailCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EchoFailedPercent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOEchoCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EchoSuccessCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents begindate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents enddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents timeused As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents speed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IP As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
