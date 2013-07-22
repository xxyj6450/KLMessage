Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim ws As New KLMessageWebService.KLMessageWebService
        ws.SendMessageWithMessageID(TextBox3.Text, TextBox1.Text.Split(";"), TextBox2.Text)
    End Sub
End Class
