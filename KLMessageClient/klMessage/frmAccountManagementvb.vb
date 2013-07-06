Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging
Imports System.Threading
Public Class frmAccountManagement
    Dim WithEvents ds As New System.Data.DataSet
    Dim UpdateCommand As New System.Data.SqlClient.SqlCommand
    Dim InsertCommand As New System.Data.SqlClient.SqlCommand
    Dim DeleteCommand As New System.Data.SqlClient.SqlCommand
    Dim p As System.Data.SqlClient.SqlParameter
    Private _ModifiedRows As Long
    Private _ThreadCount As Long
    Private _ThreadCount_Fact As Long
    Private _LastActiveRow As Long
    Private _LashRow As Windows.Forms.DataGridViewRow
    Private Delegate Sub RefreshForm_Delegage(_ds As Object)
    Private Delegate Sub ReportProgress_Delegate(s As String, value As Integer)
    Private HeaderCheckbox As CheckBox
    Private IsHeaderCheckBoxClicked As Boolean
    Private TotalCheckBoxes As Long
    Private TotalCheckedCheckBoxes As Long
    Private SessionID As String

    Private Sub ReportProgress(s As String, value As Integer)
        Me.tssl_reportText.Visible = True
        Me.tssp_Report.Value = value
        Me.tssl_reportText.Text = s
        Me.tssl_reportText.Visible = True
        Me.tssp_Report.Visible = True
    End Sub
    Private Sub HideLoading(_ds As Object)
        CType(DataGridView1.DataSource, BindingSource).ResetBindings(False)
        gbLoading.Visible = False
        Me.tssl_reportText.Visible = False
        Me.tssp_Report.Visible = False
    End Sub

 
 

    Private Sub frmAccountManagementvb_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        DataGridView1.AutoGenerateColumns = False
        getData("Select * from fn_QueryAccountInfo('初始化数据','','','')")
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
        

    End Sub

    Private Sub ToolStripdelete_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripdelete.Click

    End Sub

 
    Private Function getData(Optional sql As String = "")

        Dim df As New Query_Deletgate(AddressOf Query)
        gbLoading.Visible = True
        Me.Refresh()
        If sql = "" Then sql = "Select * from fn_QueryAccountInfo('" & txtAccountID.Text & "','','" & CBAccountType.Text & "','" & CBAccountStatus.Text & "')"
        df.BeginInvoke(sql, New AsyncCallback(AddressOf Query_Compeleted), Nothing)

    End Function

    Private Sub RefreshForm(_ds As Object)
        Dim _bindingSource As New BindingSource
        If Not (TypeOf (_ds) Is System.Data.DataSet) Then Return
        ds = CType(_ds, DataSet)
        ds.Tables(0).TableName = "T_AccountInfo"
        ds.Tables(0).PrimaryKey = New DataColumn() {ds.Tables(0).Columns("AccountID")}
        'ds.Tables(0).Columns("Selected").DefaultValue = 0
        ds.Tables(0).Columns("AccountID").DefaultValue = "请输入账号"
        'ds.Tables(0).Columns("Selected").DataType = GetType(Boolean)
        ds.Tables(0).Columns("Selected").DefaultValue = False
        ds.Tables(0).Columns("Password").DefaultValue = "123456"
        ds.Tables(0).Columns("Password").AllowDBNull = False
        ds.Tables(0).Columns("AccountType").DefaultValue = "访问账号"
        ds.Tables(0).Columns("AccountStatus").DefaultValue = "未验证"
        ds.Tables(0).Columns("IdleState").DefaultValue = "空闲"
        ds.Tables(0).Columns("ReleaseTime").DefaultValue = "1900-01-01"
        ds.Tables(0).Columns("EnterDate").DefaultValue = Now
        'ds.Tables(0).Columns("ParentAccountID").AllowDBNull = False
        'ds.Tables(0).Columns("ParentAccountPassword").AllowDBNull = False
        'ds.Tables(0).Columns("AccountType").AllowDBNull = False
        _bindingSource.DataSource = ds.Tables("T_AccountInfo")
        DataGridView1.DataSource = _bindingSource
        Me.ToolStripStatusLabel1.Text = "总" & ds.Tables(0).Rows.Count & "行"
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
            Me.Invoke(New RefreshForm_Delegage(AddressOf HideLoading), ds)
        End Try
        Return 0
    End Function
    Private Function Update_Compeleted(itfAR As IAsyncResult) As Integer
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim d As UpdateDataSet_Delegate = ar.AsyncDelegate

        Try
            d.EndInvoke(itfAR)


            Me.Invoke(New RefreshForm_Delegage(AddressOf RefreshForm), New Object)
            ds.AcceptChanges()
        Catch ex As Exception
            MsgBox("执行失败!" & vbCrLf & ex.Message, vbInformation, "保存数据")
        Finally
            Me.Invoke(New RefreshForm_Delegage(AddressOf HideLoading), New Object)
        End Try
        Return 0
    End Function
 


    Private Sub 保存SToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 保存SToolStripButton.Click

        Try
            Dim upd As New UpdateDataSet_Delegate(AddressOf UpdateDataSet)
            DataGridView1.EndEdit()
            CType(DataGridView1.DataSource, BindingSource).EndEdit()
            If ds.Tables(0).GetChanges Is Nothing Then
                Me.tssl_Status.Text = "没有数据被修改"
                Return
            End If

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
            p = .Parameters.Add("@IdleState", SqlDbType.VarChar, 50, "IdleState")
            p.SourceVersion = DataRowVersion.Current
            p = .Parameters.Add("@ACCOUNTStatus", SqlDbType.VarChar, 50, "AccountStatus")
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

            p = .Parameters.Add("@NewAccountStatus", SqlDbType.VarChar, 50, "AccountStatus")
            p = .Parameters.Add("@NewIdleState", SqlDbType.VarChar, 50, "IdleState")

        End With
        With DeleteCommand
            .CommandText = "sp_DeleteAccountInfo"
            .CommandType = CommandType.StoredProcedure
            p = .Parameters.Add("@AccountID", SqlDbType.VarChar, 50, "accountID")
        End With
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
 

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dim f As New frmAccountLimit
        f.MdiParent = frmMain
        f.Show()
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
        Dim s As String, data() As String, row As System.Data.DataRow, i As Long = 0, L As Long
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
                If L < 2 Then
                    If MsgBox("第" & i & "行数据列数不正确,无法导入,是否跳过这行继续导入?", vbQuestion + vbYesNo, "导入账户") = vbYes Then
                        Continue While
                    Else
                        Exit While
                    End If
                End If
                row = ds.Tables(0).NewRow()
                With row
                    If ds.Tables(0).Rows.Contains(data(0)) Then
                        tssl_Status.Text = "第" & i & "行数据重复,无法导入,该行被忽略."
                        Continue While
                    End If
                    row("AccountID") = data(0)
                    row("Password") = IIf(data(1) = "", "123456", data(1))
                    If L > 2 Then row("AccountType") = IIf(data(2) = "", "访问账号", data(2))
                    If L > 3 Then row("ParentAccountID") = data(3)
                    If L > 4 Then row("ParentAccountPassword") = data(4)
                    If L > 5 Then row("AccountStatus") = IIf(data(5) = "", "未验证", data(5))

                    ds.Tables(0).Rows.Add(row)
                    Me.ToolStripStatusLabel1.Text = "总" & ds.Tables(0).Rows.Count & "行"
                    tssl_Status.Text = "已导入" & i & "行"
                End With
NextRow:
            End While

        End Using
        HideLoading(ds)
    End Sub
    Private Function check_Compeleted(itfAR As System.IAsyncResult) As Long
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim f As MessageRegister.getConnectionID_Delegate = ar.AsyncDelegate
        Dim CONNID As Long, index As Long, row As System.Data.DataRow
        Try
            CONNID = f.EndInvoke(ar)
            index = CType(ar.AsyncState, Long)
            row = ds.Tables(0).Rows(index)
            If CONNID > 0 Then

                row("AccountType") = "注册账号"
                row("ParentAccountID") = row("AccountID")
                row("ParentAccountPassword") = row("Password")
                'row("Selected") = 1
            Else
                row("AccountType") = "访问账号"
            End If
            row("Selected") = 1
        Catch ex As Exception
            MsgBox("验证帐户失败" & vbCrLf & ex.Message, vbInformation, "验证帐户")
        Finally
            System.Threading.Interlocked.Increment(_ModifiedRows)
            Try
                Me.Invoke(New ReportProgress_Delegate(AddressOf ReportProgress), CInt(100 * _ModifiedRows \ _ThreadCount) & "%,已处理" & _ModifiedRows & "行", CInt(100 * _ModifiedRows \ _ThreadCount))
 
            Catch ex As Exception

            End Try
            If _ModifiedRows = _ThreadCount Then
                Dim rd As New RefreshForm_Delegage(AddressOf Me.HideLoading)
                Me.Invoke(rd, ds)
            End If
            End Try
            Return CONNID
    End Function

    Private Sub ToolStripButton1_ButtonClick(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.ButtonClick
        Dim i As Long = 0
        Me.gbLoading.Visible = True
        Me.Refresh()
        _ThreadCount = 0 : _ModifiedRows = 0
        DataGridView1.EndEdit()
        For Each row As System.Data.DataRow In ds.Tables(0).Rows
            _ThreadCount = _ThreadCount + 1
            MessageRegister.BeginGetConnectionID(row("AccountID"), row("Password"), False, New System.AsyncCallback(AddressOf check_Compeleted), i)
            i = i + 1
            'If MessageRegister.getConnectionID(row("AccountID"), row("Password")) > 0 Then
            '    row("AccountType") = "注册账号"
            '    row("ParentAccountID") = row("AccountID")
            '    row("ParentAccountPassword") = row("Password")
            'Else
            '    row("AccountType") = "访问账号"
            'End If

        Next
 
    End Sub

    Private Sub gbLoading_Enter(sender As System.Object, e As System.EventArgs) Handles gbLoading.Enter

    End Sub

    Private Sub gbLoading_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles gbLoading.Paint
        With gbLoading
            .Left = (Me.Width - .Width) / 2
            .Top = (Me.Height - .Height) / 2
        End With
    End Sub

 


    Private Sub 立即匹配结果ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 立即匹配结果ToolStripMenuItem.Click
        Dim Accounts As New System.Text.StringBuilder
        If MsgBox("请在操作完账号匹配后的5分钟以后执行此功能,否则您将看不到任何效果,确认继续?", vbQuestion + vbYesNo, "立即匹配结果") = vbYes Then
            Dim ws As New SendMessage.myWebService
            Try
                ws.MatchAccountsManual(CurrentUser.Usercode, CurrentUser.Password)
                For Each row As DataGridViewRow In DataGridView1.Rows
                    Accounts.Append(row.Cells("AccountID").Value)
                    Accounts.Append(",")
                Next
                txtAccountID.Text = Accounts.ToString
                getData()
            Catch ex As Exception
                MsgBox("执行过程发生异常" & vbCrLf & ex.Message, vbInformation, "立即匹配结果")
            End Try

        End If
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

 
 

    Private Sub DataGridView1_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        ToolStripStatusLabel1.Text = "总计" & DataGridView1.Rows.Count & "行"
    End Sub

    Private Sub DataGridView1_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        ToolStripStatusLabel1.Text = "总计" & DataGridView1.Rows.Count & "行"
    End Sub

    Private Sub 全部删除CToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 全部删除CToolStripMenuItem.Click
        Dim RowCount As Long = ds.Tables(0).Rows.Count - 1, _BindingSource As Windows.Forms.BindingSource = CType(DataGridView1.DataSource, BindingSource)
        gbLoading.Visible = True
        Me.Refresh()
        Try
            DataGridView1.EndEdit()
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

    Private Sub ToolStripdelete_ButtonClick(sender As System.Object, e As System.EventArgs) Handles ToolStripdelete.ButtonClick
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

  
 
    Private Sub DataGridView1_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        MsgBox("第" & e.RowIndex & "行,第" & e.ColumnIndex & "列数据[" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "]不正确" & vbCrLf & e.Exception.Message, vbInformation, "数据异常")
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Private Sub 批量验证ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 批量验证ToolStripMenuItem.Click
        Dim f As New frmMatchAccount, ret As Windows.Forms.DialogResult, Content As String, Recipients As String, TotalCount As Long
        Dim AccessAccount As New System.Collections.Generic.Dictionary(Of String, String)
        Dim RegisterAccount As New System.Collections.Generic.Dictionary(Of String, String)
        DataGridView1.EndEdit()
        CType(DataGridView1.DataSource, BindingSource).EndEdit()
        If ds.Tables(0).Compute("Count(AccountID)", "Selected=1") = 0 Then
            MsgBox("您没有选中任何行,请选择需要配对的行,或右击""全选""所有行进行配对", vbInformation, "配对账号")
            Exit Sub
        End If
        SessionID = Guid.NewGuid().ToString
        f.TaskType = frmMatchAccount.enumTaskType.BeginMatchAccount
        ret = f.ShowDialog(Me)
        If ret = Windows.Forms.DialogResult.OK Then
            gbLoading.Visible = True
            Me.Refresh()
            '先分类取出账户信息
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells("Selected").Value = False Then Continue For
                Select Case row.Cells("AccountType").Value
                    Case "注册账号"
                        If row.Cells("AccountID").Value = "" Or row.Cells("Password").Value = "" Then
                            row.Cells("Remark").Value = "账户或密码为空，无法验证."
                            Continue For
                        End If
                        If RegisterAccount.ContainsKey(row.Cells("AccountID").Value) = False Then
                            RegisterAccount.Add(row.Cells("AccountID").Value, row.Cells("Password").Value)
                        End If
                    Case "访问账号"
                        If row.Cells("AccountID").Value = "" Or row.Cells("Password").Value = "" Then
                            row.Cells("Remark").Value = "账户或密码为空，无法验证."
                            Continue For
                        End If
                        If AccessAccount.ContainsKey(row.Cells("AccountID").Value) = False Then
                            AccessAccount.Add(row.Cells("AccountID").Value, row.Cells("Password").Value)
                        End If
                        If row.Cells("ParentAccountID").Value <> "" And row.Cells("ParentAccountID").Value <> "" Then
                            If RegisterAccount.ContainsKey(row.Cells("ParentAccountID").Value) = False Then
                                RegisterAccount.Add(row.Cells("ParentAccountID").Value, row.Cells("ParentAccountPassword").Value)
                            End If
                        End If
                    Case Else
                        row.Cells("Remark").Value = "没有账户类型信息，无法验证."
                End Select
            Next
            If AccessAccount.Count = 0 Then
                MsgBox("没有访问账号，无法继续配对。", vbInformation, "提示信息")
                HideLoading(ds)
                Return
            End If
            If RegisterAccount.Count = 0 Then
                MsgBox("没有注册账号，无法继续配对。", vbInformation, "提示信息")
                HideLoading(ds)
                Return
            End If
            TotalCount = AccessAccount.Count * RegisterAccount.Count
            If MsgBox("注意，共有" & RegisterAccount.Count & "个注册账号," & AccessAccount.Count & "个访问账号" & vbCrLf & _
                        "此操作将发出" & TotalCount & "条短信,是否继续?", vbQuestion + vbYesNo) = vbNo Then HideLoading(ds) : Return
            _ThreadCount_Fact = TotalCount : _ThreadCount = 0
            Dim SendSMS As New SendMessage_Delegate(AddressOf Common.SendMessage)
            Dim ws As New SendMessage.myWebService
            SessionID = Guid.NewGuid().ToString
            Recipients = f.txtRecipients.Text
            Content = f.txtContent.Text
            ws.AddNewMessage(CurrentUser.Usercode, CurrentUser.Password, SessionID, 1, 1, Content, 3, IP, MAC, My.Computer.Name, My.User.Name, CPUID, DiskID)
            For Each i In AccessAccount
                For Each j In RegisterAccount
                    System.Threading.Thread.Sleep(100)
                    SendSMS.BeginInvoke(SessionID, j.Key, j.Value, i.Key, i.Value, _
                               CurrentUser.Usercode, CurrentUser.Password, Split(Recipients, ";"), 1, Content, False, False, 100, True, False, New System.AsyncCallback(AddressOf MatchAccount_Compeleted), Nothing)
                Next
            Next
        End If
    End Sub
    Private Sub 验证配对结果ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 验证配对结果ToolStripMenuItem.Click
        Dim f As New frmMatchAccount, ret As Windows.Forms.DialogResult, Content As String, Recipients As String
        Dim SendSMS As New SendMessage_Delegate(AddressOf Common.SendMessage)
        Dim ws As New SendMessage.myWebService
        '提交数据
        DataGridView1.EndEdit()
        CType(DataGridView1.DataSource, BindingSource).EndEdit()
        If ds.Tables(0).Compute("Count(AccountID)", "Selected=1") = 0 Then
            MsgBox("您没有选中任何行,请选择需要验证的行,或右击""全选""所有行进行验证", vbInformation, "验证账号")
            Exit Sub
        End If
        f.TaskType = frmMatchAccount.enumTaskType.CheckMatchResult
        ret = f.ShowDialog(Me)
        _ThreadCount_Fact = 0 : _ThreadCount = 0

        If ret = Windows.Forms.DialogResult.OK Then
            gbLoading.Visible = True
            Me.Refresh()
            Recipients = f.txtRecipients.Text
            Content = f.txtContent.Text
            SessionID = Guid.NewGuid().ToString
            Try
                ws.AddNewMessage(CurrentUser.Usercode, CurrentUser.Password, SessionID, 1, 1, Content, 4, IP, MAC, My.Computer.Name, My.User.Name, CPUID, DiskID)
            Catch ex As Exception
                MsgBox("发送短信失败" & vbCrLf & ex.Message, vbInformation, "验证终止")
                HideLoading(ds)
                Return
            End Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells("Selected").Value = False Then Continue For
                If row.Cells("ParentAccountID").Value = "" Or row.Cells("ParentAccountPassword").Value = "" _
                    Or row.Cells("AccountID").Value = "" Or row.Cells("Password").Value = "" Then
                    row.Cells("Remark").Value = "账户或密码为空，无法验证."
                    row.Cells("AccountStatus").Value = "未验证"
                Else
                    _ThreadCount_Fact = _ThreadCount_Fact + 1
                    System.Threading.Thread.Sleep(100)
                    SendSMS.BeginInvoke(SessionID, row.Cells("ParentAccountID").Value, row.Cells("ParentAccountPassword").Value, _
                                     row.Cells("AccountID").Value, row.Cells("Password").Value, CurrentUser.Usercode, CurrentUser.Password,
                                     Split(Recipients, ";"), 1, Content, False, False, 100, True, False, New System.AsyncCallback(AddressOf CheckMatchAccount_Compeleted), row)
                End If

            Next
        End If
    End Sub

    Private Sub DataGridView1_CellMouseUp(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then Me.ContextMenuStrip1.Show(MousePosition)
    End Sub
 

    Private Sub 选中所有行ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 选中所有行ToolStripMenuItem.Click

        Me.gbLoading.Visible = True
        Me.Refresh()
        CType(DataGridView1.DataSource, BindingSource).SuspendBinding()

        For Each Row As DataGridViewRow In DataGridView1.Rows
            'DirectCast(Row.Cells("Selected"), DataGridViewCheckBoxCell).Value = True ' HCheckBox.Checked
            Row.Cells("Selected").Value = True
        Next

        CType(DataGridView1.DataSource, BindingSource).ResumeBinding()
        HideLoading(Nothing)
 
    End Sub

    Private Sub 取消选中ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 取消选中ToolStripMenuItem.Click
        
        Me.gbLoading.Visible = True
        Me.Refresh()
        CType(DataGridView1.DataSource, BindingSource).SuspendBinding()

        For Each Row As DataGridViewRow In DataGridView1.Rows
            'DirectCast(Row.Cells("Selected"), DataGridViewCheckBoxCell).Value = True ' HCheckBox.Checked
            Row.Cells("Selected").Value = False
        Next

        CType(DataGridView1.DataSource, BindingSource).ResumeBinding()
        HideLoading(Nothing)
    End Sub
 
    '验证匹配结果的回调
    Private Function CheckMatchAccount_Compeleted(itfAR As IAsyncResult) As Integer
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim SendSMS As SendMessage_Delegate = ar.AsyncDelegate, ret As Integer
        Dim Message As String, i As Integer
        Dim row As DataGridViewRow
        Dim rowIndex As Long
        row = CType(ar.AsyncState, DataGridViewRow)
        Try

            ret = SendSMS.EndInvoke(ar)
            Me.Invoke(New UpdateGridviewRow_Delegate(AddressOf UpdateGridviewRow), row, ret, "")
            
        Catch ex As Exception
            Me.Invoke(New UpdateGridviewRow_Delegate(AddressOf UpdateGridviewRow), row, -1, ex.Message)
            'row.Cells("Remark").Value = ex.Message
            'row.Cells("AccountStatus").Value = "未验证"
        Finally
            'rwLock.AcquireWriterLock(100)
            System.Threading.Interlocked.Increment(_ThreadCount)
            Me.Invoke(New ReportProgress_Delegate(AddressOf ReportProgress), CInt(100 * _ThreadCount \ _ThreadCount_Fact) & "%,已处理" & _ThreadCount & "行", CInt(100 * _ThreadCount \ _ThreadCount_Fact))


            If _ThreadCount >= _ThreadCount_Fact And _ThreadCount_Fact <> 0 Then
                '报告消息发送完毕,取消进度显示
                Me.Invoke(New RefreshForm_Delegage(AddressOf Me.HideLoading), ds)
            End If

        End Try
        Return 0
    End Function
    Private Delegate Sub UpdateGridviewRow_Delegate(Row As DataGridViewRow, Ret As Long, Text As String)
    Public Sub UpdateGridviewRow(Row As DataGridViewRow, Ret As Long, Text As String)
        If Ret = 0 Then
            Row.Cells("Remark").Value = "第一步验证通过,等待回执验证."
        Else
            Row.Cells("Remark").Value = Ret & "," & Text
            Row.Cells("AccountStatus").Value = "未验证"
        End If
    End Sub
    Private Function MatchAccount_Compeleted(itfAR As IAsyncResult) As Integer
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim SendSMS As SendMessage_Delegate = ar.AsyncDelegate, ret As Integer
        Dim Message As String, i As Integer

        'rwLock.AcquireWriterLock(100)
        System.Threading.Interlocked.Increment(_ThreadCount)
        Me.Invoke(New ReportProgress_Delegate(AddressOf ReportProgress), CInt(100 * _ThreadCount \ _ThreadCount_Fact) & "%,已处理" & _ThreadCount & "行", CInt(100 * _ThreadCount \ _ThreadCount_Fact))
        If _ThreadCount >= _ThreadCount_Fact And _ThreadCount_Fact <> 0 Then
            '报告消息发送完毕,取消进度显示
            Me.Invoke(New RefreshForm_Delegage(AddressOf Me.HideLoading), ds)
        End If
        Return 0
    End Function

    Private Sub 查看验证短信状态ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 查看验证短信状态ToolStripMenuItem.Click
        If SessionID = "" Then
            MsgBox("您尚未执行账号匹配工账号验证,无法查看相应的短信执行状态.", vbInformation, "提示消息")
            Return
        End If
        Dim f As New rpt_MessageStatus
        f.Show()
        f.MessageSessionID = SessionID
        f.getData(SessionID)
    End Sub
End Class