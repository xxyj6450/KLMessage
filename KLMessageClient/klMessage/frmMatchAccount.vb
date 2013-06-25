Public Class frmMatchAccount
    Private _TaskType As enumTaskType
    Public Enum enumTaskType
        BeginMatchAccount = 0
        CheckMatchResult = 2
    End Enum
    Public Property TaskType As enumTaskType
        Get
            Return _TaskType
        End Get
        Set(value As enumTaskType)
            _TaskType = value
            If value = enumTaskType.BeginMatchAccount Then
                lblTips.Text = "本功能将自动匹配表单上注册账号与访问账号的对应关系,需要等待短信回执,请在最终执行完后,5分钟后再执行[生成配对结果]任务,并刷新数据,就可以看到配对结果."
            ElseIf value = enumTaskType.CheckMatchResult Then
                lblTips.Text = "本功能将验证表格中的访问账号和注册账号是否正确配对,需要等待短信回执,请在最终执行完后,5分钟以后再执行[生成配对结果]任务,并刷新数据,就可以看到验证结果."
            End If
        End Set
    End Property
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim ws As New SendMessage.myWebService
        If Len(txtRecipients.Text) <> 11 Then
            MsgBox("请务必填写测试收件人号码.", vbInformation, "匹配账户")
            Return
        End If
 
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub frmMatchAccount_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class