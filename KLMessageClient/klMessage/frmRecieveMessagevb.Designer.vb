<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecieveMessagevb
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecieveMessagevb))
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtContent = New System.Windows.Forms.TextBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.注册账号 = New System.Windows.Forms.Label()
        Me.txtAccountID = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RegisterUsercode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Caller = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Content = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnterDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbLoading = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.打开OToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.帮助LToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripExit = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLoading.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpStartDate
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpStartDate, 2)
        Me.dtpStartDate.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.dtpStartDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(101, 3)
        Me.dtpStartDate.MinDate = New Date(2013, 5, 1, 0, 0, 0, 0)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(190, 21)
        Me.dtpStartDate.TabIndex = 14
        Me.dtpStartDate.Value = New Date(2013, 6, 6, 23, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(199, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 26)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "短信内容"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContent
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtContent, 3)
        Me.txtContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtContent.Location = New System.Drawing.Point(297, 28)
        Me.txtContent.Name = "txtContent"
        Me.txtContent.Size = New System.Drawing.Size(288, 21)
        Me.txtContent.TabIndex = 20
        '
        'dtpEndDate
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpEndDate, 2)
        Me.dtpEndDate.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.dtpEndDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(395, 3)
        Me.dtpEndDate.MinDate = New Date(2013, 5, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(190, 21)
        Me.dtpEndDate.TabIndex = 15
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
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSerialNumber, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpStartDate, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtContent, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.注册账号, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAccountID, 7, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 51)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 26)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "手机号码"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSerialNumber.Location = New System.Drawing.Point(101, 28)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(92, 21)
        Me.txtSerialNumber.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 25)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "起始时间"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(297, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 25)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "结束时间"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '注册账号
        '
        Me.注册账号.Dock = System.Windows.Forms.DockStyle.Fill
        Me.注册账号.Location = New System.Drawing.Point(591, 0)
        Me.注册账号.Name = "注册账号"
        Me.注册账号.Size = New System.Drawing.Size(92, 25)
        Me.注册账号.TabIndex = 23
        Me.注册账号.Text = "注册账号"
        Me.注册账号.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAccountID
        '
        Me.txtAccountID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAccountID.Location = New System.Drawing.Point(689, 3)
        Me.txtAccountID.Name = "txtAccountID"
        Me.txtAccountID.Size = New System.Drawing.Size(92, 21)
        Me.txtAccountID.TabIndex = 24
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RegisterUsercode, Me.Caller, Me.Content, Me.EnterDate})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(784, 459)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.VirtualMode = True
        '
        'RegisterUsercode
        '
        Me.RegisterUsercode.DataPropertyName = "RegisterUsercode"
        Me.RegisterUsercode.HeaderText = "接收账户"
        Me.RegisterUsercode.Name = "RegisterUsercode"
        Me.RegisterUsercode.Width = 78
        '
        'Caller
        '
        Me.Caller.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Caller.DataPropertyName = "Caller"
        Me.Caller.HeaderText = "号码"
        Me.Caller.Name = "Caller"
        Me.Caller.Width = 54
        '
        'Content
        '
        Me.Content.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Content.DataPropertyName = "Content"
        Me.Content.HeaderText = "正文"
        Me.Content.Name = "Content"
        Me.Content.Width = 54
        '
        'EnterDate
        '
        Me.EnterDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.EnterDate.DataPropertyName = "EnterDate"
        Me.EnterDate.HeaderText = "接收时间"
        Me.EnterDate.Name = "EnterDate"
        Me.EnterDate.Width = 78
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
        Me.StatusStrip1.TabIndex = 9
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开OToolStripButton, Me.ToolStripSeparator4, Me.toolStripSeparator, Me.ToolStripExport, Me.ToolStripSeparator2, Me.帮助LToolStripButton, Me.toolStripSeparator1, Me.ToolStripExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 25)
        Me.ToolStrip1.TabIndex = 10
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
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
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
        Me.SplitContainer1.SplitterDistance = 51
        Me.SplitContainer1.TabIndex = 11
        '
        'frmRecieveMessagevb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmRecieveMessagevb"
        Me.Text = "接收短信"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 帮助LToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents 打开OToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbLoading As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents 注册账号 As System.Windows.Forms.Label
    Friend WithEvents txtAccountID As System.Windows.Forms.TextBox
    Friend WithEvents RegisterUsercode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Caller As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Content As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnterDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
