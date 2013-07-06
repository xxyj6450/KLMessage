
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging
Public Class rpt_MessageStatus

    Dim WithEvents ds As New System.Data.DataSet
 
    Dim m_SessionID As String
    Public Property MessageSessionID As String
        Get
            Return txtSessionID.Text
        End Get
        Set(value As String)
            m_SessionID = value
            Me.tsb_Resend.Visible = True
            Me.Text = Me.Text & "-会话[" & m_SessionID & "]"
            txtSessionID.Text = value
        End Set
    End Property


    Private Sub 打开OToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles 打开OToolStripButton.Click
        getData(txtSessionID.Text, txtAccountID.Text, txtSerialNumber.Text, Format(Me.dtpStartDate.Value, "yyyy-MM-dd HH:mm:ss"), Format(Me.dtpEndDate.Value, "yyyy-MM-dd HH:mm:ss"), txtContent.Text, CBSendStatus.Text, CBEchoStatus.Text)

    End Sub

  
    Public Function getData(Optional SessionID As String = "", Optional Usercode As String = "", Optional SerialNumber As String = "", Optional Beginday As String = "1900-01-01", _
                            Optional EndDay As String = "2050-01-01", Optional Content As String = "", Optional SendStatus As String = "", Optional EchoStatus As String = "")

        Dim df As New Query_Deletgate(AddressOf Query), sql As String
        gbLoading.Visible = True
        Me.Refresh()
        sql = "Select * from fn_QueryMessageStatus('" & SessionID & "','" & Usercode & "','" & SerialNumber & "','" & _
            Beginday & "','" & EndDay & "','" & Content & "','" & SendStatus & "','" & EchoStatus & "','" & txtAccount.Text & "')"
        df.BeginInvoke(sql, New AsyncCallback(AddressOf Query_Compeleted), Nothing)

    End Function
    Private Delegate Sub RefreshForm_Delegage(_ds As Object)
    Private Sub RefreshForm(_ds As Object)
        Dim _bindingSource As New BindingSource
        Dim SuccessedCount As Long, FailedCount As Long
        If Not (TypeOf (_ds) Is System.Data.DataSet) Then Return
        ds = CType(_ds, DataSet)
        
        _bindingSource.DataSource = ds.Tables(0)
        DataGridView1.DataSource = _bindingSource
        Me.tssl_Stat.Text = ds.Tables(0).Compute("Count(SessionID)", "EchoStatus<0 or isnull(SendRetValue,0)<0").ToString & "失败"
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
            txtAccountID.Enabled = False
            txtAccountID.Text = CurrentUser.Usercode
            
            'DataGridView1.Columns("SendStatus").Visible = False
            DataGridView1.Columns("SendStatusText").Visible = False
            If UserPermissions.UserData("ShowEchoInfo") = False Then
                DataGridView1.Columns("EchoStatus").Visible = False
                DataGridView1.Columns("EchoStatusText").Visible = False
                DataGridView1.Columns("EchoDate").Visible = False
            End If
            DataGridView1.Columns("SessionID").Visible = False
            DataGridView1.Columns("AccessAccountID").Visible = False
        End If
        dtpStartDate.Value = DateAdd(DateInterval.Hour, -8, Now)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Me.tssl_Position.Text = "当前第" & e.RowIndex & "行,第" & e.ColumnIndex & "列"
    End Sub
     
    'Private Sub StatMessage()
    '    Dim SuccessedCount As Long, FailedCount As Long
    '    If Not (ds Is Nothing) AndAlso ds.Tables.Count > 0 Then
    '        For i As Long = 0 To ds.Tables(0).Rows.Count - 1
    '            If ds.Tables(0).Rows(i)("EchoStatus") Then
    '        Next
    '    End If
    'End Sub

    Private Sub tsb_Resend_Click(sender As System.Object, e As System.EventArgs) Handles tsb_Resend.Click
        Dim Recipients As New List(Of String)
        Dim Content As String

        If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
            MsgBox("没有短信数据,无法执行重发.", vbInformation, "提示信息")
            Return
        End If
        For Each row As System.Data.DataRow In ds.Tables(0).Rows
            If (row("EchoStatus") < 0 Or (Not IsDBNull(row("SendRetValue")) AndAlso row("SendRetValue") < 0)) AndAlso Not Recipients.Contains(row("SerialNumber")) Then Recipients.Add(row("SerialNumber"))
            If row("SessionID") <> ds.Tables(0).Rows(0)("SessionID") Then
                MsgBox("结果中包含多次短信会话,无法执行重发,请使用指定的会话ID查询出结果后再执行此操作.", vbInformation, "提示信息")
                Return
            End If
        Next
        If Recipients.Count > 0 Then
            Dim f As New frmSendMessage
            f.SetSessionID(ds.Tables(0).Rows(0)("SessionID"))
            f.Recipients = Recipients.ToArray
            f.Content = ds.Tables(0).Rows(0)("Content")
            f.Show()
        Else
            MsgBox("没有失败的短信,无需执行重发.", vbInformation, "提示信息")
            Return
        End If
        
    End Sub
End Class


