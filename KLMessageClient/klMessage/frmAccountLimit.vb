Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging
Public Class frmAccountLimit

    Dim WithEvents ds As New System.Data.DataSet
    Dim WithEvents Bindings As New System.Windows.Forms.BindingSource
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
        If CurrentUser.isAdmin = False Then
            保存SToolStripButton.Visible = False
            DataGridView1.ReadOnly = True
        End If
        DataGridView1.AutoGenerateColumns = False
        getData("Select * from t_AccountLimit")
    End Sub

    Private Sub frmAccountManagementvb_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd

    End Sub
 
    Private Function getData(Optional sql As String = "") As Integer

        Dim df As New Query_Deletgate(AddressOf Query)
        Me.Refresh()
        If sql = "" Then sql = "Select * from t_AccountLimit"
        df.BeginInvoke(sql, New AsyncCallback(AddressOf Query_Compeleted), Nothing)
        Return 0
    End Function
    Private Delegate Sub RefreshForm_Delegage(_ds As Object)
    Private Sub RefreshForm(_ds As Object)

        If Not (TypeOf (_ds) Is System.Data.DataSet) Then Return
        ds = CType(_ds, DataSet)
        ds.Tables(0).TableName = "t_AccountLimit"
        ds.Tables(0).PrimaryKey = New DataColumn() {ds.Tables(0).Columns("ID")}
         
        Bindings.DataSource = ds.Tables("t_AccountLimit")
        DataGridView1.DataSource = Bindings
        Me.ToolStripStatusLabel1.Text = "总" & ds.Tables(0).Rows.Count & "行"
        gbLoading.Visible = False
    End Sub
    Private Sub HideLoading(_ds As Object)
        CType(DataGridView1.DataSource, BindingSource).ResetBindings(False)
        gbLoading.Visible = False
    End Sub
    Private Function Query_Compeleted(itfAR As IAsyncResult) As Integer
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim d As Query_Deletgate = ar.AsyncDelegate
        Dim obj As New Object
        Try
            ds = d.EndInvoke(itfAR)
            Me.Invoke(New RefreshForm_Delegage(AddressOf RefreshForm), ds)
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
    


    Private Sub 保存SToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 保存SToolStripButton.Click
        Dim upd As New UpdateDataSet_Delegate(AddressOf UpdateDataSet)
        DataGridView1.EndEdit()
        CType(DataGridView1.DataSource, BindingSource).EndEdit()
        If ds.Tables(0).GetChanges Is Nothing Then Return
        gbLoading.Visible = True
        Me.Refresh()
        upd.BeginInvoke(ds, "SElect * From t_AccountLimit", Nothing, Nothing, Nothing, _
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
 

    Private Sub ToolStripExit_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripExit.Click
        Me.Close()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub 打开OToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 打开OToolStripButton.Click
        getData()
    End Sub
End Class