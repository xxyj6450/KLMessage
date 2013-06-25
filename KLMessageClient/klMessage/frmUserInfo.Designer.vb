<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserInfo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUserCode = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdReport = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtTel)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtCompanyName)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtUserName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtUserCode)
        Me.GroupBox1.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(386, 205)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtRemark
        '
        Me.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemark.Location = New System.Drawing.Point(77, 149)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.ReadOnly = True
        Me.txtRemark.Size = New System.Drawing.Size(241, 50)
        Me.txtRemark.TabIndex = 20
        Me.txtRemark.Text = "####@##.com"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 149)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "备注信息"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label11.Location = New System.Drawing.Point(79, 139)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(241, 1)
        Me.Label11.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 12)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "电子邮箱:"
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEmail.Location = New System.Drawing.Point(81, 122)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(241, 14)
        Me.txtEmail.TabIndex = 16
        Me.txtEmail.Text = "####@##.com"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label9.Location = New System.Drawing.Point(77, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(241, 1)
        Me.Label9.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 107)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 12)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "手机号码:"
        '
        'txtTel
        '
        Me.txtTel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTel.Location = New System.Drawing.Point(79, 101)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.ReadOnly = True
        Me.txtTel.Size = New System.Drawing.Size(241, 14)
        Me.txtTel.TabIndex = 13
        Me.txtTel.Text = "####"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(79, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(241, 1)
        Me.Label7.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "公司名称:"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCompanyName.Location = New System.Drawing.Point(81, 80)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.ReadOnly = True
        Me.txtCompanyName.Size = New System.Drawing.Size(241, 14)
        Me.txtCompanyName.TabIndex = 10
        Me.txtCompanyName.Text = "####"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(329, 53)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "修改.."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(79, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(241, 1)
        Me.Label5.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "用户密码:"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(81, 59)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(241, 14)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Text = "******"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(79, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(241, 1)
        Me.Label4.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(79, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(241, 1)
        Me.Label3.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "用户姓名:"
        '
        'txtUserName
        '
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUserName.Location = New System.Drawing.Point(81, 38)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.Size = New System.Drawing.Size(241, 14)
        Me.txtUserName.TabIndex = 2
        Me.txtUserName.Text = "####"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "用户编码:"
        '
        'txtUserCode
        '
        Me.txtUserCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUserCode.Location = New System.Drawing.Point(81, 18)
        Me.txtUserCode.Name = "txtUserCode"
        Me.txtUserCode.ReadOnly = True
        Me.txtUserCode.Size = New System.Drawing.Size(241, 14)
        Me.txtUserCode.TabIndex = 0
        Me.txtUserCode.Text = "####"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(303, 213)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(89, 30)
        Me.cmdOK.TabIndex = 10
        Me.cmdOK.Text = "确定(&R)"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdReport
        '
        Me.cmdReport.Location = New System.Drawing.Point(6, 213)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(93, 30)
        Me.cmdReport.TabIndex = 11
        Me.cmdReport.Text = "统计信息(&R)"
        Me.cmdReport.UseVisualStyleBackColor = True
        '
        'frmUserInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 252)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserInfo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "个人信息"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUserCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdReport As System.Windows.Forms.Button
End Class
