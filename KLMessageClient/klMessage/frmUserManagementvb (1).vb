Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging
Public Class frmUserManagement
    Dim WithEvents ds As New System.Data.DataSet
    Dim UpdateCommand As New System.Data.SqlClient.SqlCommand
    Dim InsertCommand As New System.Data.SqlClient.SqlCommand
    Dim DeleteCommand As New System.Data.SqlClient.SqlCommand
    Dim p As System.Data.SqlClient.SqlParameter

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        '若不是点第一列,则取消其他列的点选
        If e.ColumnIndex <> 0 Then
            For Each row As Windows.Forms.DataGridViewRow In DataGridView1.Rows
                If Not IsDBNull(row.Cells("Selected").Value) AndAlso row.Cells("Selected").Value = 1 Then row.Cells("Selected").Value = 0
            Next
            If e.RowIndex >= 0 Then DataGridView1.Rows(e.RowIndex).Cells("Selected").Value = 1

        End If
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub frmAccountManagementvb_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        getData("Select * from fn_QueryAccountInfo('初始化数据','','','')")
    End Sub

    Private Sub frmAccountManagementvb_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd

    End Sub

    Private Sub 打开OToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 打开OToolStripButton.Click
        getData()

    End Sub

    Private Sub 新建NToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 新建NToolStripButton.Click
        Dim dr As DataRow
        dr = ds.Tables(0).NewRow()

        ds.Tables(0).Rows.Add(dr)
        'DataGridView1.DataSource = ds.Tables(0)
        Me.ToolStripStatusLabel1.Text = "总" & ds.Tables(0).Rows.Count & "行"
        'Me.DataGridView1.DataSource = ds
    End Sub

    Private Sub ToolStripdelete_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripdelete.Click
        DataGridView1.BeginEdit(True)

        For Each row As Windows.Forms.DataGridViewRow In DataGridView1.Rows

            If row.Cells("Selected").Value = 1 Then
                'ds.Tables(0).Rows.RemoveAt(row.Index)
                CType(DataGridView1.DataSource, BindingSource).RemoveAt(row.Index)
            End If
        Next

        Me.ToolStripStatusLabel1.Text = "总" & ds.Tables(0).Rows.Count & "行"
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub CBAccountType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Function getData(Optional sql As String = "")

        Dim df As New Query_Deletgate(AddressOf Query)
        gbLoading.Visible = True
        Me.Refresh()
        If sql = "" Then sql = "Select * from fn_QueryAccountInfo('" & txtAccountID.Text & "','','" & CBAccountType.Text & "','" & CBAccountStatus.Text & "')"
        df.BeginInvoke(sql, New AsyncCallback(AddressOf Query_Compeleted), Nothing)

    End Function
    Private Delegate Sub RefreshForm_Delegage(_ds As Object)
    Private Sub RefreshForm(_ds As Object)
        Dim _bindingSource As New BindingSource
        ds = CType(_ds, DataSet)
        ds.Tables(0).TableName = "T_AccountInfo"
        ds.Tables(0).PrimaryKey = New DataColumn() {ds.Tables(0).Columns("AccountID")}
        ds.Tables(0).Columns("AccountID").DefaultValue = "请输入账号"

        ds.Tables(0).Columns("Password").DefaultValue = "123456"
        ds.Tables(0).Columns("Password").AllowDBNull = False
        ds.Tables(0).Columns("AccountType").DefaultValue = "访问账号"
        'ds.Tables(0).Columns("ParentAccountID").AllowDBNull = False
        'ds.Tables(0).Columns("ParentAccountPassword").AllowDBNull = False
        'ds.Tables(0).Columns("AccountType").AllowDBNull = False
        _bindingSource.DataSource = ds.Tables("T_AccountInfo")
        DataGridView1.DataSource = _bindingSource
        Me.ToolStripStatusLabel1.Text = "总" & ds.Tables(0).Rows.Count & "行"
        gbLoading.Visible = False
    End Sub
    Private Sub HideLoading(_ds As Object)
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
            Me.Invoke(New RefreshForm_Delegage(AddressOf HideLoading), New Object)
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


    Private Sub 保存SToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 保存SToolStripButton.Click
        Dim upd As New UpdateDataSet_Delegate(AddressOf UpdateDataSet)
        DataGridView1.EndEdit()
        CType(DataGridView1.DataSource, BindingSource).EndEdit()
        If ds.Tables(0).GetChanges Is Nothing Then Return
        upd.BeginInvoke(ds, "", sqlCommandToCommand(UpdateCommand), sqlCommandToCommand(InsertCommand), sqlCommandToCommand(DeleteCommand), _
                        New System.AsyncCallback(AddressOf Update_Compeleted), Nothing)
        'UpdateDataSet(ds, "", sqlCommandToCommand(UpdateCommand), sqlCommandToCommand(InsertCommand), sqlCommandToCommand(DeleteCommand))
    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        With UpdateCommand
            .CommandText = "sp_UpdateAccountInfo"
            .CommandType = CommandType.StoredProcedure
            p = .Parameters.Add("@AccountID", SqlDbType.VarChar, 50, "accountID")
            p.SourceVersion = DataRowVersion.Original
            p = .Parameters.Add("@NewAccountID", SqlDbType.VarChar, 50, "accountID")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewParentAccountID", SqlDbType.VarChar, 50, "ParentAccountID")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewPassword", SqlDbType.VarChar, 50, "Password")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewParentPassword", SqlDbType.VarChar, 50, "ParentAccountPassword")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewAccountType", SqlDbType.VarChar, 50, "AccountType")
            p.SourceVersion = DataRowVersion.Current
        End With
        With InsertCommand
            .CommandText = "sp_InsertAccountInfo"
            .CommandType = CommandType.StoredProcedure
            p = .Parameters.Add("@NewAccountID", SqlDbType.VarChar, 50, "accountID")

            p = .Parameters.Add("@NewParentAccountID", SqlDbType.VarChar, 50, "ParentAccountID")

            p = .Parameters.Add("@NewPassword", SqlDbType.VarChar, 50, "Password")

            p = .Parameters.Add("@NewParentPassword", SqlDbType.VarChar, 50, "ParentAccountPassword")

            p = .Parameters.Add("@NewAccountType", SqlDbType.VarChar, 50, "AccountType")

        End With
        With DeleteCommand
            .CommandText = "sp_DeleteAccountInfo"
            .CommandType = CommandType.StoredProcedure
            p = .Parameters.Add("@AccountID", SqlDbType.VarChar, 50, "accountID")
        End With
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub SplitContainer1_Resize(sender As Object, e As System.EventArgs) Handles SplitContainer1.Resize
        SplitContainer1.SplitterDistance = 29
    End Sub

    Private Sub ToolStripExport_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripExport.Click
        Dim _export As New Export
        If ds Is Nothing Then Return
        If ds.Tables.Count <= 0 Then Return
        If ds.Tables(0) Is Nothing Then Return
        _export.SaveExcel(ds.Tables(0), "", "", "帐户")
    End Sub

    Private Sub ToolStripExit_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripExit.Click
        Me.Close()
    End Sub
End Class