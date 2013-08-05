Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging
Public Class rpt_UserMessageSend
 
        Dim WithEvents ds As New System.Data.DataSet

 

    Private Sub 打开OToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 打开OToolStripButton.Click
        getData(txtAccountID.Text, txtSessionID.Text, Format(Me.dtpStartDate.Value, "yyyy-MM-dd"), Format(Me.dtpEndDate.Value, "yyyy-MM-dd"))

    End Sub
 
    Public Sub getData(Optional Usercode As String = "", Optional SessionID As String = "", Optional Beginday As String = "1900-01-01", _
                            Optional EndDay As String = "2050-01-01")

        Dim df As New Query_Deletgate(AddressOf Query), sql As String
        gbLoading.Visible = True
        Me.Refresh()
        sql = "Select * from fn_QueryUserMessageStat('" & Usercode & "','" & SessionID & "','" & _
            Beginday & "','" & EndDay & " ')"
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
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim d As Query_Deletgate = ar.AsyncDelegate
        Try
            ds = d.EndInvoke(itfAR)
            Me.Invoke(New RefreshForm_Delegage(AddressOf RefreshForm), ds)
        Catch ex As Exception
            MsgBox("执行失败!" & vbCrLf & ex.Message)
        Finally
            Try
                If Not (ds Is Nothing) Then Me.Invoke(New RefreshForm_Delegage(AddressOf HideLoading), ds)
            Catch ex As Exception
            End Try
        End Try
        Return 0
    End Function
    Private Function Update_Compeleted(itfAR As IAsyncResult) As Integer
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim d As UpdateDataSet_Delegate = ar.AsyncDelegate
        Dim obj As New Object
        Try
            'ds = d.EndInvoke(itfAR)
            ds.AcceptChanges()

            Me.Invoke(New RefreshForm_Delegage(AddressOf RefreshForm), obj)
        Catch ex As Exception
            MsgBox("执行失败!" & vbCrLf & ex.Message)
        Finally
            Try
                Me.Invoke(New RefreshForm_Delegage(AddressOf HideLoading), obj)
            Catch ex As Exception
            End Try
        End Try
        Return 0
    End Function
 

    Private Sub SplitContainer1_Resize(sender As Object, e As System.EventArgs) Handles SplitContainer1.Resize
        SplitContainer1.SplitterDistance = 80
    End Sub

    Private Sub ToolStripExport_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripExport.Click
        Dim _export As New Export
        If ds Is Nothing Then Return
        If ds.Tables.Count <= 0 Then Return
        If ds.Tables(0) Is Nothing Then Return
        _export.SaveExcel(ds.Tables(0), "", "", "号码状态")
    End Sub

    Private Sub ToolStripExit_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripExit.Click
        Me.Close()
    End Sub

    Private Sub rpt_MessageStatus_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If CurrentUser.isAdmin = False Then
            txtAccountID.Text = CurrentUser.Usercode
            txtAccountID.ReadOnly = True
        End If
        dtpEndDate.Value = DateAdd(DateInterval.Day, 1, Now)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Me.tssl_Position.Text = "当前第" & e.RowIndex + 1 & "行,第" & e.ColumnIndex + 1 & "列"
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class