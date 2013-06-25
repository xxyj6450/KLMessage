<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMatchAccount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMatchAccount))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblTips = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRecipients = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtContent = New System.Windows.Forms.RichTextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(336, 145)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 53)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "启动任务(&S)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblTips
        '
        Me.lblTips.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTips.Location = New System.Drawing.Point(23, 145)
        Me.lblTips.Name = "lblTips"
        Me.lblTips.Size = New System.Drawing.Size(304, 53)
        Me.lblTips.TabIndex = 9
        Me.lblTips.Text = "本功能将自动匹配系统中所有[未验证]的访问账户与注册账户的对应关系,该功能服务器执行,需要等待短信回执,这会需要一些时间,不会立刻返回账户状态,请10分钟后再进入" & _
    "[帐户管理]中查看账号验证状态."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.klMessage.My.Resources.Resources.PushMsgInfo
        Me.PictureBox1.Location = New System.Drawing.Point(5, 145)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtRecipients)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtContent)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 139)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(259, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(167, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "(为免打扰用户,建议使用空号)"
        '
        'txtRecipients
        '
        Me.txtRecipients.Location = New System.Drawing.Point(65, 109)
        Me.txtRecipients.Name = "txtRecipients"
        Me.txtRecipients.Size = New System.Drawing.Size(188, 21)
        Me.txtRecipients.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "收件人:"
        '
        'txtContent
        '
        Me.txtContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtContent.Location = New System.Drawing.Point(3, 17)
        Me.txtContent.Name = "txtContent"
        Me.txtContent.Size = New System.Drawing.Size(423, 85)
        Me.txtContent.TabIndex = 0
        Me.txtContent.Text = "这是一条运营商发出的测试账户的消息,谢谢您的配合,如有打扰,十分抱歉.(本消息免费)"
        '
        'frmMatchAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 211)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTips)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMatchAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "匹配账户"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTips As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRecipients As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtContent As System.Windows.Forms.RichTextBox
End Class
