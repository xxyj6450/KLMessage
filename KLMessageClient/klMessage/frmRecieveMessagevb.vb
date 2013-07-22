Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging
Imports System.Threading
Public Class frmRecieveMessagevb

    Dim WithEvents ds As New System.Data.DataSet

 
    Private Sub 打开OToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 打开OToolStripButton.Click
        getData(txtSerialNumber.Text, Format(Me.dtpStartDate.Value, "yyyy-MM-dd HH:mm:ss"), Format(Me.dtpEndDate.Value, "yyyy-MM-dd HH:mm:ss"), txtContent.Text, txtAccountID.Text)

    End Sub


    Public Sub getData(Optional SerialNumber As String = "", Optional Beginday As String = "1900-01-01", _
                            Optional EndDay As String = "2050-01-01", Optional Content As String = "", Optional AccountID As String = "")

        Dim df As New Query_Deletgate(AddressOf Query), sql As String
        gbLoading.Visible = True
        Me.Refresh()
        sql = "Select * from fn_QueryRecieveMessage('" & SerialNumber & "','" & Beginday & "','" & EndDay & "','" & _
            Content & "','" & AccountID & "')"
        df.BeginInvoke(sql, New AsyncCallback(AddressOf Query_Compeleted), Nothing)

    End Sub
    Private Delegate Sub RefreshForm_Delegage(_ds As Object)
    Private Sub RefreshForm(_ds As Object)
        Dim _bindingSource As New BindingSource
        If Not (TypeOf (_ds) Is System.Data.DataSet) Then Return
        ds = CType(_ds, DataSet)

        _bindingSource.DataSource = ds.Tables(0)
        DataGridView1.DataSource = _bindingSource
        Me.ToolStripStatusLabel1.Text = "共 " & ds.Tables(0).Rows.Count & "行"
        gbLoading.Visible = False
    End Sub
    Private Sub HideLoading(_ds As Object)
        CType(DataGridView1.DataSource, BindingSource).ResetBindings(False)
        gbLoading.Visible = False
    End Sub
    Private Function Query_Compeleted(itfAR As IAsyncResult) As Integer
        Dim ar As System.Runtime.Remoting.Messaging.AsyncResult = CType(itfAR, AsyncResult)
        Dim d As Query_Deletgate = ar.AsyncDelegate
        Try
            ds = d.EndInvoke(itfAR)
            Me.Invoke(New RefreshForm_Delegage(AddressOf RefreshForm), ds)
        Catch ex As Exception
            MsgBox("执行失败!" & vbCrLf & ex.Message)
        Finally
            Me.Invoke(New RefreshForm_Delegage(AddressOf HideLoading), ds)
        End Try
        Return 0
    End Function
    Private Function Update_Compeleted(itfAR As IAsyncResult) As Integer
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim d As UpdateDataSet_Delegate = ar.AsyncDelegate

        Try
            'ds = d.EndInvoke(itfAR)
            ds.AcceptChanges()

            Me.Invoke(New RefreshForm_Delegage(AddressOf RefreshForm), New Object)
        Catch ex As Exception
            MsgBox("执行失败!" & vbCrLf & ex.Message)
        Finally
            Me.Invoke(New RefreshForm_Delegage(AddressOf HideLoading), New Object)
        End Try
        Return 0
    End Function
    Private Sub 批量删除ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub



    Private Sub SplitContainer1_Resize(sender As Object, e As System.EventArgs) Handles SplitContainer1.Resize
        SplitContainer1.SplitterDistance = 60
    End Sub

    Private Sub ToolStripExport_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripExport.Click
        Dim _export As New Export
        If ds Is Nothing Then Return
        If ds.Tables.Count <= 0 Then Return
        If ds.Tables(0) Is Nothing Then Return
        _export.SaveExcel(ds.Tables(0), "", "", "接收短信")
    End Sub

    Private Sub ToolStripExit_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripExit.Click
        Me.Close()
    End Sub

    Private Sub rpt_MessageStatus_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class