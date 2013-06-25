<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountLimit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountLimit))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.打开OToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.保存SToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.帮助LToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripExit = New System.Windows.Forms.ToolStripButton()
        Me.gbLoading = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvockPerSecond = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BatchSendNumbers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MergeLimit = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SendPerMonth_CM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendPerMonth_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendPerMonth_UN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendPerday_CM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendPerday_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendPerday_UN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendPerHour_CM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendPerHour_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendPerHour_UN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.gbLoading.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开OToolStripButton, Me.ToolStripSeparator4, Me.保存SToolStripButton, Me.toolStripSeparator, Me.ToolStripSeparator2, Me.帮助LToolStripButton, Me.toolStripSeparator1, Me.ToolStripExit})
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
        'gbLoading
        '
        Me.gbLoading.Controls.Add(Me.Label4)
        Me.gbLoading.Controls.Add(Me.PictureBox2)
        Me.gbLoading.Location = New System.Drawing.Point(316, 215)
        Me.gbLoading.Name = "gbLoading"
        Me.gbLoading.Size = New System.Drawing.Size(184, 74)
        Me.gbLoading.TabIndex = 9
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
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected, Me.ID, Me.InvockPerSecond, Me.BatchSendNumbers, Me.MergeLimit, Me.SendPerMonth_CM, Me.SendPerMonth_TEL, Me.SendPerMonth_UN, Me.SendPerday_CM, Me.SendPerday_TEL, Me.SendPerday_UN, Me.SendPerHour_CM, Me.SendPerHour_TEL, Me.SendPerHour_UN})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(784, 514)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 8
        Me.DataGridView1.VirtualMode = True
        '
        'Selected
        '
        Me.Selected.DataPropertyName = "Selected"
        Me.Selected.FalseValue = ""
        Me.Selected.Frozen = True
        Me.Selected.HeaderText = "选中"
        Me.Selected.IndeterminateValue = ""
        Me.Selected.Name = "Selected"
        Me.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Selected.TrueValue = ""
        Me.Selected.Width = 35
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        Me.ID.Width = 42
        '
        'InvockPerSecond
        '
        Me.InvockPerSecond.DataPropertyName = "InvockPerSecond"
        Me.InvockPerSecond.HeaderText = "每秒调用次数"
        Me.InvockPerSecond.Name = "InvockPerSecond"
        Me.InvockPerSecond.Width = 72
        '
        'BatchSendNumbers
        '
        Me.BatchSendNumbers.DataPropertyName = "BatchSendNumbers"
        Me.BatchSendNumbers.HeaderText = "每批号码量"
        Me.BatchSendNumbers.Name = "BatchSendNumbers"
        Me.BatchSendNumbers.Width = 72
        '
        'MergeLimit
        '
        Me.MergeLimit.DataPropertyName = "MergeLimit"
        Me.MergeLimit.FalseValue = "false"
        Me.MergeLimit.HeaderText = "合并运营商限制"
        Me.MergeLimit.IndeterminateValue = "false"
        Me.MergeLimit.Name = "MergeLimit"
        Me.MergeLimit.TrueValue = "true"
        Me.MergeLimit.Width = 64
        '
        'SendPerMonth_CM
        '
        Me.SendPerMonth_CM.DataPropertyName = "SendPerMonth_CM"
        Me.SendPerMonth_CM.HeaderText = "月发送量|移动"
        Me.SendPerMonth_CM.Name = "SendPerMonth_CM"
        Me.SendPerMonth_CM.Width = 72
        '
        'SendPerMonth_TEL
        '
        Me.SendPerMonth_TEL.DataPropertyName = "SendPerMonth_TEL"
        Me.SendPerMonth_TEL.HeaderText = "月发送量|电信"
        Me.SendPerMonth_TEL.Name = "SendPerMonth_TEL"
        Me.SendPerMonth_TEL.Width = 72
        '
        'SendPerMonth_UN
        '
        Me.SendPerMonth_UN.DataPropertyName = "SendPerMonth_UN"
        Me.SendPerMonth_UN.HeaderText = "月发送量|联通"
        Me.SendPerMonth_UN.Name = "SendPerMonth_UN"
        Me.SendPerMonth_UN.Width = 72
        '
        'SendPerday_CM
        '
        Me.SendPerday_CM.DataPropertyName = "SendPerday_CM"
        Me.SendPerday_CM.HeaderText = "日发送量|移动"
        Me.SendPerday_CM.Name = "SendPerday_CM"
        Me.SendPerday_CM.Width = 72
        '
        'SendPerday_TEL
        '
        Me.SendPerday_TEL.DataPropertyName = "SendPerday_TEL"
        Me.SendPerday_TEL.HeaderText = "日发送量|电信"
        Me.SendPerday_TEL.Name = "SendPerday_TEL"
        Me.SendPerday_TEL.Width = 72
        '
        'SendPerday_UN
        '
        Me.SendPerday_UN.DataPropertyName = "SendPerday_UN"
        Me.SendPerday_UN.HeaderText = "日发送量|联通"
        Me.SendPerday_UN.Name = "SendPerday_UN"
        Me.SendPerday_UN.Width = 72
        '
        'SendPerHour_CM
        '
        Me.SendPerHour_CM.DataPropertyName = "SendPerHour_CM"
        Me.SendPerHour_CM.HeaderText = "每小时发送量|移动"
        Me.SendPerHour_CM.Name = "SendPerHour_CM"
        Me.SendPerHour_CM.Width = 99
        '
        'SendPerHour_TEL
        '
        Me.SendPerHour_TEL.DataPropertyName = "SendPerHour_TEL"
        Me.SendPerHour_TEL.HeaderText = "每小时发送量|电信"
        Me.SendPerHour_TEL.Name = "SendPerHour_TEL"
        Me.SendPerHour_TEL.Width = 99
        '
        'SendPerHour_UN
        '
        Me.SendPerHour_UN.DataPropertyName = "SendPerHour_UN"
        Me.SendPerHour_UN.HeaderText = "每小时发送量|联通"
        Me.SendPerHour_UN.Name = "SendPerHour_UN"
        Me.SendPerHour_UN.Width = 99
        '
        'frmAccountLimit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.gbLoading)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmAccountLimit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "帐户功能限制"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbLoading.ResumeLayout(False)
        Me.gbLoading.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 保存SToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 帮助LToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbLoading As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents 打开OToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvockPerSecond As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchSendNumbers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MergeLimit As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SendPerMonth_CM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendPerMonth_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendPerMonth_UN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendPerday_CM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendPerday_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendPerday_UN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendPerHour_CM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendPerHour_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendPerHour_UN As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
