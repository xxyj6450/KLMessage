<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBadwords
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBadwords))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BadWord = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Method = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ReplaceString = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtBadwords = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbLoading = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssl_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_Position = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.打开OToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.新建NToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripSplitButton()
        Me.清空ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存SToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripImport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.帮助LToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripExit = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CBType = New System.Windows.Forms.ComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLoading.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "关键字"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(199, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "分类"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected, Me.BadWord, Me.Type, Me.Method, Me.ReplaceString, Me.Remark})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(784, 484)
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
        Me.Selected.Width = 35
        '
        'BadWord
        '
        Me.BadWord.DataPropertyName = "badword"
        Me.BadWord.HeaderText = "关键字"
        Me.BadWord.Name = "BadWord"
        Me.BadWord.Width = 66
        '
        'Type
        '
        Me.Type.DataPropertyName = "Type"
        Me.Type.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Type.HeaderText = "分类"
        Me.Type.Items.AddRange(New Object() {"政治军事", "犯罪", "宗教", "广告营销", "道德伦理", "未分类"})
        Me.Type.Name = "Type"
        Me.Type.Width = 39
        '
        'Method
        '
        Me.Method.DataPropertyName = "Method"
        Me.Method.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Method.HeaderText = "处理方案"
        Me.Method.Items.AddRange(New Object() {"分割关键字", "替换关键字", "替换成繁体"})
        Me.Method.Name = "Method"
        Me.Method.Width = 59
        '
        'ReplaceString
        '
        Me.ReplaceString.DataPropertyName = "ReplaceString"
        Me.ReplaceString.HeaderText = "替换文字"
        Me.ReplaceString.Name = "ReplaceString"
        Me.ReplaceString.Width = 78
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "说明"
        Me.Remark.Name = "Remark"
        Me.Remark.Width = 54
        '
        'txtBadwords
        '
        Me.txtBadwords.Location = New System.Drawing.Point(101, 3)
        Me.txtBadwords.Name = "txtBadwords"
        Me.txtBadwords.Size = New System.Drawing.Size(92, 21)
        Me.txtBadwords.TabIndex = 4
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
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssl_Status, Me.tssl_Position, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssl_Status
        '
        Me.tssl_Status.Name = "tssl_Status"
        Me.tssl_Status.Size = New System.Drawing.Size(46, 17)
        Me.tssl_Status.Text = "Ready."
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开OToolStripButton, Me.ToolStripSeparator4, Me.新建NToolStripButton, Me.ToolStripdelete, Me.保存SToolStripButton, Me.toolStripSeparator, Me.ToolStripImport, Me.ToolStripExport, Me.ToolStripSeparator2, Me.帮助LToolStripButton, Me.toolStripSeparator1, Me.ToolStripExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 25)
        Me.ToolStrip1.TabIndex = 7
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
        Me.TableLayoutPanel1.Controls.Add(Me.txtBadwords, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CBType, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 26)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CBType
        '
        Me.CBType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CBType.FormattingEnabled = True
        Me.CBType.Items.AddRange(New Object() {"政治军事", "犯罪", "宗教", "广告营销", "道德伦理", "未分类"})
        Me.CBType.Location = New System.Drawing.Point(297, 3)
        Me.CBType.Name = "CBType"
        Me.CBType.Size = New System.Drawing.Size(92, 20)
        Me.CBType.TabIndex = 6
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
        Me.SplitContainer1.SplitterDistance = 26
        Me.SplitContainer1.TabIndex = 8
        '
        'frmBadwords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBadwords"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "关键字管理"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLoading.ResumeLayout(False)
        Me.gbLoading.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtBadwords As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbLoading As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents 打开OToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 新建NToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents 清空ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 保存SToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 帮助LToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CBType As System.Windows.Forms.ComboBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents tssl_Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssl_Position As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BadWord As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Method As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ReplaceString As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
