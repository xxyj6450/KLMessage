
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging
Public Class frmUserManagement
    Dim WithEvents ds As New System.Data.DataSet
    Dim UpdateCommand As New System.Data.SqlClient.SqlCommand
    Dim InsertCommand As New System.Data.SqlClient.SqlCommand
    Dim DeleteCommand As New System.Data.SqlClient.SqlCommand
    Dim p As System.Data.SqlClient.SqlParameter

 

    Private Sub frmAccountManagementvb_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If CurrentUser.isAdmin = False Then
            'DataGridView1.Enabled = False
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToDeleteRows = False
            txtAccountID.Text = CurrentUser.Usercode
            txtAccountID.Enabled = False
            新建NToolStripButton.Visible = False
            ToolStripdelete.Visible = False
            保存SToolStripButton.Visible = False
        End If

        getData()

        'getData("Select * from fn_QueryUserInfo('','','','','','')")

    End Sub

    Private Sub frmAccountManagementvb_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd

    End Sub

    Private Sub 打开OToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 打开OToolStripButton.Click
        getData()

    End Sub

    Private Sub 新建NToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 新建NToolStripButton.Click
        Dim dr As System.Data.DataRow
        Try
            DataGridView1.EndEdit()
            CType(DataGridView1.DataSource, BindingSource).EndEdit()
            dr = ds.Tables(0).NewRow()

            CType(DataGridView1.DataSource, BindingSource).AddNew()
            CType(DataGridView1.DataSource, BindingSource).EndEdit()

            Me.ToolStripStatusLabel1.Text = "总计" & ds.Tables(0).Rows.Count & "行"
        Catch ex As Exception
            MsgBox("新增失败" & vbCrLf & ex.Message, vbInformation, "新增数据")
        End Try
 
        Me.ToolStripStatusLabel1.Text = "总" & ds.Tables(0).Rows.Count & "行"

    End Sub

    Private Sub ToolStripdelete_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripdelete.Click
        Dim RowCount As Long = ds.Tables(0).Rows.Count - 1
        DataGridView1.BeginEdit(True)

        For i As Integer = RowCount To 0 Step -1
            'Debug.Print(i & ds.Tables(0).Rows(i)("Selected") & "," & ds.Tables(0).Rows(i)("accountID"))
            If ds.Tables(0).Rows(i)("Selected") = 1 Then
                CType(DataGridView1.DataSource, BindingSource).RemoveAt(i)
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
        If sql = "" Then sql = "Select * from fn_QueryUserInfo('" & txtAccountID.Text & "','" & txtUserName.Text & "','" & txtCompanyName.Text & "','" & _
            CBAccountStatus.Text & "','" & txtTel.Text & "','" & txtEmail.Text & "')"
        df.BeginInvoke(sql, New AsyncCallback(AddressOf Query_Compeleted), Nothing)

    End Function
    Private Delegate Sub RefreshForm_Delegage(_ds As Object)
    Private Sub RefreshForm(_ds As Object)
        Dim _bindingSource As New BindingSource
        If Not (TypeOf (_ds) Is System.Data.DataSet) Then Return
        If Not (_ds Is Nothing) Then
            ds = CType(_ds, DataSet)
            ds.Tables(0).TableName = "T_UserInfo"
            ds.Tables(0).PrimaryKey = New DataColumn() {ds.Tables(0).Columns("Usercode")}
            ds.Tables(0).Columns("Usercode").DefaultValue = "请输入账号"

            ds.Tables(0).Columns("Password").DefaultValue = "123456"
            ds.Tables(0).Columns("Password").AllowDBNull = False
            ds.Tables(0).Columns("isAdmin").DefaultValue = 0
            ds.Tables(0).Columns("status").DefaultValue = "正常"
            ds.Tables(0).Columns("LimitPerday").DefaultValue = 10000
            ds.Tables(0).Columns("SendToday").DefaultValue = 0
            ds.Tables(0).Columns("SendThismonth").DefaultValue = 0
            ds.Tables(0).Columns("TotalLimit").DefaultValue = 0
            ds.Tables(0).Columns("CreditLeft").Expression = "IIF(TotalLimit>0,TotalLimit-TotalSend,0)"
            ds.Tables(0).Columns("DistributionMode").DefaultValue = "节省资源"
            ds.Tables(0).Columns("ShowEchoInfo").DefaultValue = False
            ds.Tables(0).Columns("NofityNewMessage").DefaultValue = False
            _bindingSource.DataSource = ds.Tables("T_UserInfo")
            DataGridView1.DataSource = _bindingSource
            Me.ToolStripStatusLabel1.Text = "总" & ds.Tables(0).Rows.Count & "行"
        End If
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
            Me.Invoke(New RefreshForm_Delegage(AddressOf HideLoading), New Object)
        End Try
        Return 0
    End Function
    Private Function Update_Compeleted(itfAR As IAsyncResult) As Integer
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim d As UpdateDataSet_Delegate = ar.AsyncDelegate
        Dim _ds As System.Data.DataSet
        Try
            ds.AcceptChanges()
            '_ds = d.EndInvoke(itfAR)
            Me.Invoke(New RefreshForm_Delegage(AddressOf RefreshForm), New Object)
        Catch ex As Exception
            MsgBox("执行失败!" & vbCrLf & ex.Message)
        Finally
            Me.Invoke(New RefreshForm_Delegage(AddressOf HideLoading), New Object)
        End Try
        Return 0
    End Function
 


    Private Sub 保存SToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 保存SToolStripButton.Click
        Dim upd As New UpdateDataSet_Delegate(AddressOf UpdateDataSet)
        Try
            DataGridView1.EndEdit()
            CType(DataGridView1.DataSource, BindingSource).EndEdit()
            If ds.Tables(0).GetChanges Is Nothing Then Return
            gbLoading.Visible = True
            Me.Refresh()
            upd.BeginInvoke(ds, "", sqlCommandToCommand(UpdateCommand), sqlCommandToCommand(InsertCommand), sqlCommandToCommand(DeleteCommand), _
                            New System.AsyncCallback(AddressOf Update_Compeleted), Nothing)

        Catch ex As Exception
            MsgBox("保存失败" & vbCrLf & ex.Message, vbInformation, "保存数据")
        End Try

    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()


        ' 在 InitializeComponent() 调用之后添加任何初始化。
        With UpdateCommand
            .CommandText = "sp_UpdateUserinfo"
            .CommandType = CommandType.StoredProcedure
            p = .Parameters.Add("@OldUsercode", SqlDbType.VarChar, 50, "Usercode")
            p.SourceVersion = DataRowVersion.Original
            p = .Parameters.Add("@NewUsercode", SqlDbType.VarChar, 50, "Usercode")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewUserName", SqlDbType.VarChar, 50, "UserName")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewPassword", SqlDbType.VarChar, 50, "Password")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewCompanyName", SqlDbType.VarChar, 50, "CompanyName")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewTel", SqlDbType.VarChar, 50, "Tel")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewEmail", SqlDbType.VarChar, 50, "Email")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewIsAdmin", SqlDbType.Bit, 50, "isAdmin")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewsStatus", SqlDbType.VarChar, 50, "Status")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewLimitPerday", SqlDbType.Int, 50, "LimitPerday")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewRemark", SqlDbType.VarChar, 50, "Remark")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewTotalLimit", SqlDbType.BigInt, 50, "TotalLimit")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewDistributionMode", SqlDbType.VarChar, 50, "DistributionMode")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewShowEchoInfo", SqlDbType.Bit, 50, "ShowEchoInfo")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewNofityNewMessage", SqlDbType.Bit, 50, "NofityNewMessage")
            p.SourceVersion = DataRowVersion.Current
        End With
        With InsertCommand
            .CommandText = "sp_AddUserInfo"
            .CommandType = CommandType.StoredProcedure
            p = .Parameters.Add("@Usercode", SqlDbType.VarChar, 50, "usercode")

            p = .Parameters.Add("@UserName", SqlDbType.VarChar, 50, "Username")

            p = .Parameters.Add("@Password", SqlDbType.VarChar, 50, "Password")

            p = .Parameters.Add("@CompanyNAME", SqlDbType.VarChar, 50, "CompanyName")

            p = .Parameters.Add("@Tel", SqlDbType.VarChar, 50, "Tel")

            p = .Parameters.Add("@Email", SqlDbType.VarChar, 50, "Email")
            p = .Parameters.Add("@Status", SqlDbType.VarChar, 50, "Status")
            p = .Parameters.Add("@LimitPerday", SqlDbType.Int, 50, "LimitPerday")
            p = .Parameters.Add("@isAdmin", SqlDbType.Bit, 50, "isAdmin")
            p = .Parameters.Add("@Remark", SqlDbType.VarChar, 50, "Remark")
            p = .Parameters.Add("@TotalLimit", SqlDbType.BigInt, 50, "TotalLimit")
            p = .Parameters.Add("@DistributionMode", SqlDbType.VarChar, 50, "DistributionMode")
            p = .Parameters.Add("@ShowEchoInfo", SqlDbType.Bit, 50, "ShowEchoInfo")
            p = .Parameters.Add("@NofityNewMessage", SqlDbType.Bit, 50, "NofityNewMessage")
 
        End With
        With DeleteCommand
            .CommandText = "sp_DeleteUser"
            .CommandType = CommandType.StoredProcedure
            p = .Parameters.Add("@Usercode", SqlDbType.VarChar, 50, "Usercode")
        End With
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        '若不是点第一列,则取消其他列的点选
        If e.ColumnIndex <> 0 Then
            For Each row As Windows.Forms.DataGridViewRow In DataGridView1.Rows
                If Not IsDBNull(row.Cells("Selected").Value) AndAlso row.Cells("Selected").Value = 1 Then row.Cells("Selected").Value = 0
            Next
            If e.RowIndex >= 0 Then DataGridView1.Rows(e.RowIndex).Cells("Selected").Value = 1

        End If
    End Sub
 

    Private Sub SplitContainer1_Resize(sender As Object, e As System.EventArgs) Handles SplitContainer1.Resize
        SplitContainer1.SplitterDistance = 50
    End Sub

    Private Sub ToolStripExport_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripExport.Click
        Dim _export As New Export
        If ds Is Nothing Then Return
        If ds.Tables.Count <= 0 Then Return
        If ds.Tables(0) Is Nothing Then Return
        _export.SaveExcel(ds.Tables(0), "", "", "用户")
    End Sub

    Private Sub ToolStripExit_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripExit.Click
        Me.Close()
    End Sub

   
    Private Sub DataGridView1_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        ToolStripStatusLabel1.Text = "总计" & DataGridView1.Rows.Count & "行"
    End Sub

    Private Sub DataGridView1_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        ToolStripStatusLabel1.Text = "总计" & DataGridView1.Rows.Count & "行"
    End Sub
 

    Private Sub ToolStripdelete_ButtonClick(sender As System.Object, e As System.EventArgs) Handles ToolStripdelete.ButtonClick
        Dim RowCount As Long
        Try
            DataGridView1.EndEdit()
            CType(DataGridView1.DataSource, BindingSource).EndEdit()
            'RowCount = ds.Tables(0).Rows.Count - 1
            'For i As Integer = RowCount To 0 Step -1
            '    Debug.Print(i & ds.Tables(0).Rows(i)("Selected") & "," & ds.Tables(0).Rows(i)("accountID"))
            '    If ds.Tables(0).Rows(i)("Selected") = 1 Then
            '        CType(DataGridView1.DataSource, BindingSource).RemoveAt(i)
            '    End If
            'Next
            RowCount = DataGridView1.Rows.Count - 1
            For i As Integer = RowCount To 0 Step -1
                If DataGridView1.Rows(i).Cells("Selected").Value = 1 Then DataGridView1.Rows.RemoveAt(i)
            Next
        Catch ex As Exception
            MsgBox("删除失败" & vbCrLf & ex.Message, vbInformation, "删除数据")
        End Try
        Me.ToolStripStatusLabel1.Text = "总" & ds.Tables(0).Rows.Count & "行"
    End Sub

    Private Sub ToolStripdelete_ButtonClick_1(sender As System.Object, e As System.EventArgs) Handles ToolStripdelete.ButtonClick
        Dim RowCount As Long = ds.Tables(0).Rows.Count - 1
        DataGridView1.BeginEdit(True)

        For i As Integer = RowCount To 0 Step -1
            ' Debug.Print(i & ds.Tables(0).Rows(i)("Selected") & "," & ds.Tables(0).Rows(i)("accountID"))
            If ds.Tables(0).Rows(i)("Selected") = 1 Then
                CType(DataGridView1.DataSource, BindingSource).RemoveAt(i)
            End If
        Next
        Me.ToolStripStatusLabel1.Text = "总" & ds.Tables(0).Rows.Count & "行"
    End Sub

    Private Sub 清空ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 清空ToolStripMenuItem.Click
        Dim RowCount As Long = ds.Tables(0).Rows.Count - 1, _BindingSource As Windows.Forms.BindingSource = CType(DataGridView1.DataSource, BindingSource)
        gbLoading.Visible = True
        Me.Refresh()
        Try
            _BindingSource.EndEdit()
            ds.Tables(0).Clear()
            'DataGridView1.Rows.Clear()
            'For i As Integer = RowCount To 0 Step -1
            '    'Debug.Print(i & ds.Tables(0).Rows(i)("Selected") & "," & ds.Tables(0).Rows(i)("accountID"))

            '    _BindingSource.RemoveAt(i)
            '    'DataGridView1.Rows.Clear()

            'Next
        Catch ex As Exception
            MsgBox("清空失败" & vbCrLf & ex.Message, vbInformation, "清空数据")
        End Try
        HideLoading(ds)
        Me.ToolStripStatusLabel1.Text = "总" & ds.Tables(0).Rows.Count & "行"
    End Sub

 
End Class