Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging

Public Class frmBadwords

    Dim WithEvents ds As New System.Data.DataSet
    Dim UpdateCommand As New System.Data.SqlClient.SqlCommand
    Dim InsertCommand As New System.Data.SqlClient.SqlCommand
    Dim DeleteCommand As New System.Data.SqlClient.SqlCommand
    Dim p As System.Data.SqlClient.SqlParameter
    Private _LastActiveRow As Long
    Private _LashRow As Windows.Forms.DataGridViewRow

    Private Sub frmAccountManagementvb_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If CurrentUser.isAdmin = False Then
            'DataGridView1.Enabled = False
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToDeleteRows = False
            ToolStripImport.Visible = False
            新建NToolStripButton.Visible = False
            ToolStripdelete.Visible = False
            保存SToolStripButton.Visible = False
        End If

        'getData()

        getData("Select * from fn_QueryBadwords(NULL,'')")

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
            ' Debug.Print(i & ds.Tables(0).Rows(i)("Selected") & "," & ds.Tables(0).Rows(i)("'"))
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
    Private Sub getData(Optional sql As String = "")

        Dim df As New Query_Deletgate(AddressOf Query)
        gbLoading.Visible = True
        Me.Refresh()
        If sql = "" Then sql = "Select * from fn_QueryBadwords('" & txtBadwords.Text & "','" & CBType.Text & "')"
        df.BeginInvoke(sql, New AsyncCallback(AddressOf Query_Compeleted), Nothing)

    End Sub
    Private Delegate Sub RefreshForm_Delegage(_ds As Object)
    Private Sub RefreshForm(_ds As Object)
        Dim _bindingSource As New BindingSource
        If Not (TypeOf (_ds) Is System.Data.DataSet) Then Return
        If Not (_ds Is Nothing) Then
            ds = CType(_ds, DataSet)
            ds.Tables(0).TableName = "T_BadWords"
            ds.Tables(0).PrimaryKey = New DataColumn() {ds.Tables(0).Columns("Badword")}
            ds.Tables(0).Columns("Badword").DefaultValue = "请输入关键字"
            ds.Tables(0).Columns("Type").DefaultValue = "未分类"

            ds.Tables(0).Columns("Method").DefaultValue = "分割关键字"
             
            _bindingSource.DataSource = ds.Tables("T_BadWords")
            DataGridView1.DataSource = _bindingSource
            Me.ToolStripStatusLabel1.Text = "共" & ds.Tables(0).Rows.Count & "行"
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
            ds.AcceptChanges()
            '_ds = d.EndInvoke(itfAR)
            Me.Invoke(New RefreshForm_Delegage(AddressOf RefreshForm))
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
            .CommandText = "sp_UpdateBadword"
            .CommandType = CommandType.StoredProcedure
            p = .Parameters.Add("@OldBadword", SqlDbType.VarChar, 50, "Badword")
            p.SourceVersion = DataRowVersion.Original
            p = .Parameters.Add("@NewBadword", SqlDbType.VarChar, 50, "Badword")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewType", SqlDbType.VarChar, 50, "Type")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewMethod", SqlDbType.VarChar, 50, "Method")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewReplaceString", SqlDbType.VarChar, 50, "ReplaceString")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@NewRemark", SqlDbType.VarChar, 200, "Remark")
            p.SourceVersion = DataRowVersion.Current
        End With
        With InsertCommand
            .CommandText = "sp_AddNewBadword"
            .CommandType = CommandType.StoredProcedure
            p = .Parameters.Add("@Badword", SqlDbType.VarChar, 50, "Badword")

            p = .Parameters.Add("@Type", SqlDbType.VarChar, 50, "Type")

            p = .Parameters.Add("@Method", SqlDbType.VarChar, 50, "Method")

            p = .Parameters.Add("@ReplaceString", SqlDbType.VarChar, 50, "ReplaceString")

            p = .Parameters.Add("@Remark", SqlDbType.VarChar, 200, "Remark")

        End With
        With DeleteCommand
            .CommandText = "sp_DeleteBadword"
            .CommandType = CommandType.StoredProcedure
            p = .Parameters.Add("@Badword", SqlDbType.VarChar, 50, "Badword")
        End With
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim rowIndex As Long = e.RowIndex, colIndex As Long = e.ColumnIndex
        '若不是点第一列,则取消其他列的点选
        If colIndex <> 0 And rowIndex >= 0 Then
            If Not _LashRow Is Nothing Then
                If _LashRow.Index >= 0 Then _LashRow.Cells("Selected").Value = 0
            End If

            _LashRow = DataGridView1.CurrentRow

            _LashRow.Cells("Selected").Value = 1

        End If
        Me.tssl_Position.Text = "当前第" & e.RowIndex & "行,第" & e.ColumnIndex & "列"
    End Sub


    Private Sub SplitContainer1_Resize(sender As Object, e As System.EventArgs) Handles SplitContainer1.Resize
        SplitContainer1.SplitterDistance = 26
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
        Dim RowCount As Long
        Try
            gbLoading.Visible = True
            Me.Refresh()
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
                If DataGridView1.Rows(i).Cells("Selected").Value = True Then DataGridView1.Rows.RemoveAt(i)
            Next
        Catch ex As Exception
            MsgBox("删除失败" & vbCrLf & ex.Message, vbInformation, "删除数据")
        End Try
        HideLoading(Nothing)
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

    Private Sub ToolStripImport_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripImport.Click
        Dim f As New OpenFileDialog, FileName As String
        With f
            .Filter = "文本文件|*.txt|制表符分隔文件|*.tsv"
            .AddExtension = True
            .SupportMultiDottedExtensions = True
            .Title = "导入收件人"
            .Multiselect = False
            .FileName = "*.txt"
            .ShowDialog()
            FileName = .FileName
            If .FileName <> "" And f.CheckFileExists() Then FileName = .FileName
            ImportAccount(FileName)
        End With
    End Sub
    Public Sub ImportAccount(FileName As String)
        Dim data() As String, row As System.Data.DataRow, i As Long = 0, L As Long
        If My.Computer.FileSystem.FileExists(FileName) = False Then
            MsgBox("文件" & FileName & "不存在,无法继续导入.", vbInformation, "导入账号")
            Return
        End If
        gbLoading.Visible = True
        Me.Refresh()
        Using fs As New System.IO.StreamReader(FileName, System.Text.Encoding.Default)

            While Not fs.EndOfStream
                i = i + 1
                data = fs.ReadLine().Split(vbTab)
                L = data.Length
                If L < 1 Then
                    If MsgBox("第" & i & "行数据列数不正确,无法导入,是否跳过这行继续导入?", vbQuestion + vbYesNo, "导入账户") = vbYes Then
                        Continue While
                    Else
                        Exit While
                    End If
                End If
                row = ds.Tables(0).NewRow()
                With row
                    If ds.Tables(0).Rows.Contains(data(0)) Then
                        If MsgBox("第" & i & "行数据重复,无法导入,是否跳过这行继续导入?", vbQuestion + vbYesNo, "导入账户") = vbYes Then
                            Continue While
                        Else
                            Exit While
                        End If
                    End If
                    row("Badword") = data(0)
                    If L > 1 Then row("Type") = IIf(data(1) = "", "未分类", data(1))
                    If L > 2 Then row("Method") = IIf(data(2) = "", "分割关键字", data(2))
                    If L > 3 Then row("ReplaceString") = data(3)
                    If L > 4 Then row("Remark") = data(4)
 
                    ds.Tables(0).Rows.Add(row)
                    Me.ToolStripStatusLabel1.Text = "总" & ds.Tables(0).Rows.Count & "行"
                    tssl_Status.Text = "已导入" & i & "行"
                End With
NextRow:
            End While

        End Using
        HideLoading(ds)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class