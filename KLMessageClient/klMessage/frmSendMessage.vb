Imports System.Threading
Imports System.Runtime.Remoting.Messaging
Public Class frmSendMessage
    Private _time As Long
    Private _progress As Long
    Private _ThreadCount As Integer
    Private _ThreadCount_Fact As Integer, SessionID As String
    Private _StartTime As Long, _TotalCount As Long, _SendCount As Long
    Private _MessageType As Integer = 0
    Private _SessionMessageCount As Long
    Private _SessionSendCount As Long
    Private _Wait As New System.Threading.AutoResetEvent(False)
    Public WriteOnly Property Recipients() As String()
        Set(value As String())
            txtRecipients.Text = System.String.Join(vbCrLf, value)
        End Set
    End Property
    Public WriteOnly Property Content As String
        Set(value As String)
            txtMessage.Text = value
        End Set
    End Property
    Public Sub SetSessionID(value As String)
        SessionID = value
        _MessageType = 2
    End Sub
    Private Delegate Sub ChangeContolTextDelegate(Control As Object, Text As String)
    Private Sub ChangeControlText(Control As Object, Text As String)
        Control.Text = Text
    End Sub

   

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim FileName As String
        Me.rbInput.Checked = False
        Me.rbImport.Checked = True
        With Me.OpenFileDialog1

            .Filter = "文本文件|*.txt"
            .AddExtension = True
            .SupportMultiDottedExtensions = True
            .Title = "导入收件人"
            .Multiselect = False
            .FileName = "*.txt"
            .Multiselect = True
            .ShowDialog()
            FileName = .FileName
            If FileName <> "" And Me.OpenFileDialog1.CheckFileExists() Then txtFileName.Text = System.String.Join(";", .FileNames)
        End With

    End Sub

   

    Private Sub txtMessage_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMessage.TextChanged
        Me.tssl_字数.Text = "已输入" & txtMessage.TextLength & "字"
        Me.tssl_短信条数.Text = "共计" & Math.Ceiling(txtMessage.TextLength / 70) & "条短信"
        If (dt_Keywords Is Nothing) OrElse dt_Keywords.Tables.Count = 0 OrElse dt_Keywords.Tables(0).Rows.Count = 0 Then getDataASYN("Select Badword,Method,ReplaceString From T_Badwords with(nolock)", New System.AsyncCallback(AddressOf getKeywords_Compeleted))
        Me.Text = "发送短信-" & Microsoft.VisualBasic.Left(txtMessage.Text, 7) & "..."
    End Sub
    Private Sub InitialSendMessage()
        
        'frmSendMessageLog.Show()
        'frmSendMessageLog.txtLog.Text = ""
        'frmSendMessageLog.sb.Remove(0, frmSendMessageLog.sb.Length)
        Me.tssl_Status.Text = "正在发送消息..."
        gridLog.Items.Clear()
        _ThreadCount = 0
        _ThreadCount_Fact = 0
        _time = 0
        _progress = 0
        Me.tssl_发送进度.Visible = True
        Me.tssl_发送进度.Value = 0
        Me.Timer1.Tag = 0
        Me.tss_timer.Visible = True
        Me.tssl_Speed.Visible = True
        Me.tssl_Speed.Text = "0%,0条/秒"
        Me.Timer1.Enabled = True
        Me.ToolStripButton1.Enabled = False
        Me.Refresh()
    End Sub

 
    Public Sub BeginSendMessage(param As SendMessageParameter)
        Dim Start As Long = 0, SendCount As Long = 0
        '开始按运营商循环
        For i As Integer = 0 To 2
            '初始化起始值
            Start = 0 : SendCount = 0
            '当此运营商有号码时才处理
            If Not (param.Recipients(i) Is Nothing) AndAlso param.Recipients(i).Count > 0 Then

                For j As Long = 0 To param.Recipients(i).Count Step param.QueueSize
                    If Start >= param.Recipients(i).Count Then Exit For
                    If Start + param.QueueSize >= param.Recipients(i).Count Then
                        SendCount = param.Recipients(i).Count - Start
                    Else
                        SendCount = param.QueueSize
                    End If
                    Dim Recipients_Copy(SendCount - 1) As String, ret As Long
                    'System.Array.Resize(Recipients_Copy, SendCount)
                    param.Recipients(i).CopyTo(Start, Recipients_Copy, 0, SendCount)
                    ret = SplitSendMessage(SessionID, Recipients_Copy, param.Message, param.InvockPerSecond, param.MaxBatchNumber, _
                                     i, param.Simulation, param.RecordLog, param.AddTag, param.ShowDebugInfo)
                    If ret < 0 Then Exit Sub
                    Start = Start + SendCount
                    _Wait.WaitOne()
                Next
                
            End If
        Next
    End Sub
    Private Function SplitSendMessage(SessionID As String, Recipients() As String, Message As String, InvockPerSecondText As String, MaxBatchNumberText As String, _
                                 Nettype As Integer, Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, ShowDebugInfo As Boolean) As Long
        Dim i As Long = Nettype
        Dim MaxBatchNumber As Long, InvockPerSecond As Long, SendCount As Long, Start As Long

        Dim ws As New SendMessage.myWebService
        Dim dt As DataTable
        '注册消息,获得需要的用户

        Try
            Me.Invoke(New ChangeContolTextDelegate(AddressOf ChangeControlText), tssl_Status, "申请短信资源中...")
            dt = ws.AddNewMessage(CurrentUser.Usercode, CurrentUser.Password, SessionID, Recipients.Length, i, Message, _MessageType, IP, MAC, My.Computer.Name, My.User.Name, CPUID, DiskID)
        Catch ex As Exception
            MsgBox("发送失败" & vbCrLf & ex.Message, vbInformation, "发送消息")
            ws.FinishedSendMessage(CurrentUser.Usercode, CurrentUser.Password, "", "", SessionID, "0", 0, 0, -1, ex.Message)
            Me.Invoke(New Report_Delegate(AddressOf Callback_Compelted), MessageInfo.SharedObject)
            _Wait.Set()
            Return -1
        End Try
        '再次确认资源是否足够,免得被服务端乌龙
        If dt.Rows.Count <= 0 OrElse dt.Compute("Sum(SendCount)", "") < Recipients.Length Then
            MsgBox("分配的资源不足以发送这么多短信,请联系管理员", vbInformation, "提示消息")
            ws.FinishedSendMessage(CurrentUser.Usercode, CurrentUser.Password, "", "", SessionID, "0", 0, 0, -1, "分配的资源不足以发送这么多短信,请联系管理员")
            Me.Invoke(New Report_Delegate(AddressOf Callback_Compelted), MessageInfo.SharedObject)
            _Wait.Set()
            Return -1
        End If
        Dim SendSMS As New BatchSendMessage_Delegate(AddressOf BatchSendMessage)
        _SessionMessageCount = Recipients.Length : _SessionSendCount = 0
        Me.Invoke(New ChangeContolTextDelegate(AddressOf ChangeControlText), tssl_Status, "发送短信...")
        '下面循环开始发送短信,原则是先将每个账户的可发数量耗尽,下面每一次循环耗尽一个帐户
        For Each row As System.Data.DataRow In dt.Rows
            '每次循环都是新的数组对象

            '若起始值已经大于当前的长度,则直接退出
            If Start >= Recipients.Length Then Exit For
            MaxBatchNumber = IIf(MaxBatchNumberText = "自动", row("BatchSendNumbers"), Val(MaxBatchNumberText))
            InvockPerSecond = IIf(InvockPerSecondText = "自动", row("InvockPerSecond"), Val(InvockPerSecondText))
            If Start + row("SendCount") > Recipients.Length Then
                SendCount = Recipients.Length - Start
            Else
                SendCount = row("SendCount")
            End If

            Dim Recipients_Copy(SendCount - 1) As String
            'System.Array.Resize(Recipients_Copy, SendCount)
            'Recipients(i).CopyTo(Start, Recipients_Copy, 0, SendCount)
            System.Array.Copy(Recipients, Start, Recipients_Copy, 0, SendCount)
            Start = Start + SendCount
            SendSMS.BeginInvoke(SessionID, Recipients_Copy.Clone, row("RegisterUsercode"), row("RegisterPassword"), _
                                row("AccessUsercode"), row("AccessPassword"), CurrentUser.Usercode, CurrentUser.Password, _
                                i, Message, 1000 / InvockPerSecond, MaxBatchNumber, SendCount, Simulation, RecordLog, AddTag, ShowDebugInfo, Nothing, Nothing)


        Next
        Return 0
    End Function
    Private Function ReadRecipients(Optional SkipRepeatRecipient As Boolean = False) As ArrayList()
        Dim Recipients(0 To 3) As ArrayList, Value As String, Nettype As Integer
        Dim FileName() As String

        '从文件中读取出联系人到数组
        If Me.rbImport.Checked = True Then
            FileName = txtFileName.Text.Split(";")
            For i As Long = 0 To FileName.Length - 1
                Using fs As New System.IO.StreamReader(FileName(i))
                    Do While fs.EndOfStream = False
                        Value = fs.ReadLine
                        If Trim(Value) <> "" Then
                            Nettype = getNetType(Value)
                            If Recipients(Nettype) Is Nothing Then Recipients(Nettype) = New ArrayList
                            If SkipRepeatRecipient = True AndAlso Recipients(Nettype).Contains(Trim(Value)) Then Continue Do
                            Recipients(Nettype).Add(Microsoft.VisualBasic.Left(Trim(Value), 11))
                        End If
                    Loop
                End Using
            Next
        Else
            '从文本框中读出联系人到数组
            Using fs As New System.IO.StringReader(txtRecipients.Text)
                'RecipientString = System.Text.RegularExpressions.Regex.Split(txtRecipients.Text, "\s+|,", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Multiline Or System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace) 'txtRecipients.Text.Split(New Char() {Chr(10), Chr(13)}, StringSplitOptions.RemoveEmptyEntries)
                Do While True
                    Value = fs.ReadLine
                    If Value Is Nothing Then Exit Do
                    If Value <> "" Then
                        Nettype = getNetType(Value)
                        If Recipients(Nettype) Is Nothing Then Recipients(Nettype) = New ArrayList
                        If SkipRepeatRecipient = True AndAlso Recipients(Nettype).Contains(Trim(Value)) Then Continue Do
                        Recipients(Nettype).Add(Microsoft.VisualBasic.Left(Trim(Value), 11))
                    End If
                Loop
            End Using
        End If
        Return Recipients
    End Function
    '调用发送短信方法投递短信
    '关于休眠时间,最佳时机是异步调用SendSMS.BeginInvoke方法后,这样不会阻碍其他
    Private Function BatchSendMessage(SessionID As String, RegisterUsercode As String, RegisterPassword As String, _
                                AccessUsercode As String, AccessPassword As String, _
                                Usercode As String, Password As String, _
                                Recipients() As String, Nettype As Integer, Message As String, Sleep As Long, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, ShowDebugInfo As Boolean) As Integer
        Dim ret As Long
        Dim MessageInfo As MessageInfo = New MessageInfo(Join(Recipients, ";"), Recipients.Length, "等待发送", "")

        Me.Invoke(New Report_Delegate(AddressOf AddListView), MessageInfo)

        '将联系人复制到待发送列表
        Try
            System.Threading.Thread.Sleep(Sleep)
            
            ret = Common.SendMessage(SessionID, RegisterUsercode, RegisterPassword, AccessUsercode, AccessPassword, _
                                Usercode, Password, Recipients, Nettype, Message, Simulation, RecordLog, Sleep, AddTag, ShowDebugInfo)
            If ret = 0 Then
                MessageInfo.Status = "发送成功"
            Else
                MessageInfo.Status = "发送失败"
                MessageInfo.ErrorText = ret
            End If
        Catch ex As Exception
            MessageInfo.Status = "发送失败"
            MessageInfo.ErrorText = ex.Message
            ret = -9999
        Finally
            _SendCount = System.Threading.Interlocked.Add(_SendCount, Recipients.Length)
            _SessionSendCount = System.Threading.Interlocked.Add(_SessionSendCount, Recipients.Length)
            Debug.Print(_SendCount & "," & _TotalCount)
            If _SessionSendCount >= _SessionMessageCount - My.Settings.MinThreadCount Then

                'Me.Invoke(New ChangeContolTextDelegate(AddressOf ChangeControlText), Me.tssl_Status, "发完一批了,休息5s吧")
                'Thread.Sleep(5000)
                _Wait.Set()
            End If
            If _SendCount >= _TotalCount And _TotalCount <> 0 Then
                Try
                    '向服务器发送一个消息发送完毕的消息
                    Dim ws As New SendMessage.myWebService
                    ws.FinishedSendMessage(CurrentUser.Usercode, CurrentUser.Password, "", "", SessionID, "0", 0, 0, 1, "")
                Catch ex As Exception
                End Try
                '报告消息发送完毕,取消进度显示
                Me.Invoke(New Report_Delegate(AddressOf Callback_Compelted), MessageInfo.SharedObject)
            End If
            
            Me.Invoke(New Report_Delegate(AddressOf Report), MessageInfo)
        End Try
        Return ret
    End Function
    Private Delegate Function BatchSendMessage_Delegate(SessionID As String, Recipients As String(), RegisterUsercode As String, RegisterPassword As String, _
                                AccessUsercode As String, AccessPassword As String, _
                                Usercode As String, Password As String, Nettype As Integer, Message As String, _
                                Sleep As Long, MaxBatchNumber As Long, SendCount As Integer, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, ShowDebugInfo As Boolean) As Integer
    '调用发送短信方法投递短信
    '关于休眠时间,最佳时机是异步调用SendSMS.BeginInvoke方法后,这样不会阻碍其他
    Private Function BatchSendMessage(SessionID As String, Recipients As String(), RegisterUsercode As String, RegisterPassword As String, _
                                AccessUsercode As String, AccessPassword As String, _
                                Usercode As String, Password As String, Nettype As Integer, Message As String, _
                                Sleep As Long, MaxBatchNumber As Long, SendCount As Integer, _
                                Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, ShowDebugInfo As Boolean) As Integer
        Dim ret As Integer
        '若账户可发送的号码数量小于可批量发送的数量,则将帐户可发送的号码一次发完
        If SendCount <= MaxBatchNumber Then
            '若帐户的可发送数量比当前待发的收件人数量还少,那就将所有的收件人一次发完
            ret = BatchSendMessage(SessionID, RegisterUsercode, RegisterPassword, AccessUsercode, AccessPassword, _
                                Usercode, Password, Recipients, Nettype, Message, Sleep, Simulation, RecordLog, AddTag, ShowDebugInfo)

        Else
            Dim Start As Long = 0
            '若帐户可发送的号码数量大于可批量发送的数量,则循环发送多批,直到此号码完全用完,要注意最后一段的处理
            For j As Long = 1 To SendCount \ MaxBatchNumber + 1
                Dim _tempMaxNumber As Long
                If Start >= SendCount Then Exit For
                If j * MaxBatchNumber > SendCount Then
                    _tempMaxNumber = SendCount - (j - 1) * MaxBatchNumber
                    '如果刚好相等了,则退出本次循环
                    If _tempMaxNumber = 0 Then Exit For
                Else
                    _tempMaxNumber = MaxBatchNumber
                End If
                'Start = Start + _tempMaxNumber
                Dim Recipients_Copy(_tempMaxNumber - 1) As String
                '重置联系人数组大小,否则会直接挂掉退出,并且不报任何错误
                System.Array.Resize(Recipients_Copy, _tempMaxNumber)
                '将联系人复制到待发送列表
                System.Array.Copy(Recipients, Start, Recipients_Copy, 0, _tempMaxNumber)
                'Recipients.Copy(Recipients_Copy, 0, SendCount)
                Start = Start + _tempMaxNumber
                'System.Array.Copy(Recipients(i), Start, Recipients_Copy, 0, SendCount)
                ret = BatchSendMessage(SessionID, RegisterUsercode, RegisterPassword, AccessUsercode, AccessPassword, _
                                Usercode, Password, Recipients_Copy, Nettype, Message, Sleep, Simulation, RecordLog, AddTag, ShowDebugInfo)

            Next
        End If
        Return 0
    End Function
    Private Sub rbInput_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbInput.CheckedChanged
        If rbInput.Checked = True Then rbImport.Checked = False
    End Sub

    Private Sub txtFileName_GotFocus(sender As Object, e As System.EventArgs) Handles txtFileName.GotFocus
        Me.rbInput.Checked = False
        Me.rbImport.Checked = True
    End Sub


    Private Sub rbImport_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbImport.CheckedChanged
        If rbImport.Checked = True Then rbInput.Checked = False
    End Sub

    Private Sub frmSendMessage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If CurrentUser.isAdmin = True Then
            CheckBox1.Visible = True
        End If
        'txtMessage.Focus()

    End Sub
    
    Private Sub getKeywords_Compeleted(itfAR As System.IAsyncResult)
        Dim far As System.Runtime.Remoting.Messaging.AsyncResult = CType(itfAR, System.Runtime.Remoting.Messaging.AsyncResult)
        Dim f As QueryData_Deletegate = far.AsyncDelegate
        Try
            dt_Keywords = f.EndInvoke(itfAR)
            Me.Invoke(New ChangeContolTextDelegate(AddressOf ChangeControlText), tssl_Status, "获取关键字列表成功,共" & dt_Keywords.Tables(0).Rows.Count & "个")
        Catch ex As Exception
            Me.Invoke(New ChangeContolTextDelegate(AddressOf ChangeControlText), tssl_Status, "获取关键字列表失败" & ex.Message)
            ' Me.tssl_Status.Text = "获取关键字列表失败"
        End Try
    End Sub

    Private Function SendMessage_Compeleted(itfAR As IAsyncResult) As Integer
        Dim ar As AsyncResult = CType(itfAR, AsyncResult)
        Dim SendSMS As SendMessage_Delegate = ar.AsyncDelegate, ret As Integer
        Dim msgInfo As MessageInfo
        msgInfo = CType(ar.AsyncState, MessageInfo)
        Try
            ret = SendSMS.EndInvoke(ar)
            If ret = 0 Then
                msgInfo.Status = "发送成功"
            Else
                msgInfo.Status = "发送失败"
                msgInfo.ErrorText = ret
            End If
        Catch ex As Exception
            msgInfo.Status = "发送失败"
            msgInfo.ErrorText = ex.Message
        Finally
            'rwLock.AcquireWriterLock(100)
            System.Threading.Interlocked.Increment(_ThreadCount)

            Debug.Print(_ThreadCount & "," & _ThreadCount_Fact)
            If _ThreadCount >= _ThreadCount_Fact And _ThreadCount_Fact <> 0 Then
                Try
                    '向服务器发送一个消息发送完毕的消息
                    Dim ws As New SendMessage.myWebService
                    ws.FinishedSendMessage(CurrentUser.Usercode, CurrentUser.Password, "", "", SessionID, "0", 0, 0, 1, "")
                Catch ex As Exception
                End Try
                '报告消息发送完毕,取消进度显示
                Me.Invoke(New Report_Delegate(AddressOf Callback_Compelted), MessageInfo.SharedObject)
            End If
            Me.Invoke(New Report_Delegate(AddressOf Report), msgInfo)
        End Try
        Return 0
    End Function
    Private Delegate Function Report_Delegate(Message As MessageInfo) As Integer
    Private Function Callback_Compelted(Message As MessageInfo) As Integer

        Me.Timer1.Enabled = False
        Me.tssl_发送进度.Visible = False
        Me.tss_timer.Visible = False
        Me.ToolStripButton1.Enabled = True
        Me.tssl_Speed.Visible = False
        Me.tssl_Status.Text = "发送完毕,共用时" & CLng((System.Environment.TickCount - _StartTime) / 1000) & "秒,平均速度:" & Format(1000 * _SendCount / (System.Environment.TickCount - _StartTime), "0.00") & "条/秒"
        Me.Refresh()
        Return 0
        'MsgBox("发送完毕")
    End Function
    Private Function Report(Message As MessageInfo) As Integer
        For Each Item As Windows.Forms.ListViewItem In gridLog.Items
            If Item.Tag = Message.MessageID Then
                Item.StateImageIndex = IIf(Message.Status = "发送成功", 0, 1)
                Item.Text = Message.Status
                Item.SubItems(1).Text = Now
                Item.SubItems(3).Text = Message.ErrorText & "用时" & System.Environment.TickCount - Message.StartTick & "毫秒"

            End If
        Next
        'System.Threading.Interlocked.Add(_SendCount, Message.RecipientsCount)
        Return 0
    End Function
    '从文件中读取号码
    Public Function getNumbers(fs As System.IO.StreamReader, Count As Integer, Optional Start As Integer = 0) As String
        Dim i As Long = 1, s As New System.Text.StringBuilder
        If fs.EndOfStream = True Then Return ""
        While fs.EndOfStream = False And i <= Count
            s.Append(Trim(fs.ReadLine))
            s.Append(";")
            i = i + 1
        End While
        Return s.ToString
    End Function
    '从收件人中读号码
    Public Function getNumbers(Recipients() As String, Count As Integer, Optional Start As Integer = 0) As String
        If Start >= Recipients.Length Then Return ""
        If Start + Count > Recipients.Length Then Count = Recipients.Length - Start
        Return String.Join(";", Recipients, Start, Count)

    End Function

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        _time = _time + 1

        Me.tss_timer.Text = _time & "秒"
        Timer1.Tag = _time
        If _TotalCount > 0 Then Me.tssl_发送进度.Value = Format(100.0 * _SendCount / _TotalCount, "0.00")
        If _TotalCount > 0 Then Me.tssl_Speed.Text = Format(100.0 * _SendCount / _TotalCount, "0.00") & "%," & Format(1000 * _SendCount / (System.Environment.TickCount - _StartTime), "0.00") & "条/秒"
    End Sub

    Private Function AddListView(_MessageInfo As MessageInfo) As Integer
        Dim item As Windows.Forms.ListViewItem
        With Me.gridLog

            item = .Items.Add(_MessageInfo.Status)
            item.StateImageIndex = 2
            item.Tag = _MessageInfo.MessageID
            item.SubItems.Add(Now)
            item.SubItems.Add(_MessageInfo.Recipients)
            item.SubItems.Add("")

        End With
        Return 0
    End Function

    Private Sub ToolStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub txtRecipients_GotFocus(sender As Object, e As System.EventArgs) Handles txtRecipients.GotFocus
        Me.rbInput.Checked = True
        Me.rbImport.Checked = False
    End Sub

    Private Sub txtRecipients_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRecipients.TextChanged
        rbInput.Text = "输入联系人(已输入" & System.Text.RegularExpressions.Regex.Split(txtRecipients.Text, "\s+|,", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Multiline Or System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace).Length & "人)"
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dim f As New rpt_MessageStatus
        f.MdiParent = frmMain
        f.Show()
        f.MessageSessionID = SessionID

        f.getData(SessionID)
    End Sub

    Private Sub 关键字管理ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 关键字管理ToolStripMenuItem.Click
        Dim f As New frmBadwords
        f.MdiParent = frmMain
        f.Show()
    End Sub

    Private Sub txtMessage_Validated(sender As Object, e As System.EventArgs) Handles txtMessage.Validated

    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(sender As System.Object, e As System.EventArgs) Handles ToolStripSplitButton1.ButtonClick

        If dt_Keywords Is Nothing OrElse dt_Keywords.Tables.Count = 0 OrElse dt_Keywords.Tables(0).Rows.Count = 0 Then
            If MsgBox("尚未拉取敏感字,是否立即获取敏感字数据?", vbQuestion + vbYesNo, "处理关键字") = vbYes Then
                dt_Keywords = Query("Select Badword,Method,ReplaceString From T_Badwords with(nolock)")
                Me.tssl_Status.Text = "拉取敏感字完毕."
            Else
                Return
            End If
        End If
        Dim s As String = txtMessage.Text
        For Each row As System.Data.DataRow In dt_Keywords.Tables(0).Rows
            Try

                If System.Text.RegularExpressions.Regex.IsMatch(txtMessage.Text, row("badword").ToString, System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Multiline) Then
                    s = System.Text.RegularExpressions.Regex.Replace(s, row("badword").ToString, _
                                                                 SplitKeyword(row("badword"), row("Method"), _
                                                                              IIf(row("Replacestring").ToString = "", _
                                                                                    "-", row("Replacestring"))), _
                                                                            System.Text.RegularExpressions.RegexOptions.Multiline _
                                                                            Or System.Text.RegularExpressions.RegexOptions.IgnoreCase)


                End If
            Catch ex As Exception

            Finally
            End Try
        Next
        txtMessage.Text = s

    End Sub

    Private Sub 仅找出关键字ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 仅找出关键字ToolStripMenuItem.Click
        Dim matches As System.Text.RegularExpressions.MatchCollection
        If dt_Keywords Is Nothing OrElse dt_Keywords.Tables.Count = 0 OrElse dt_Keywords.Tables(0).Rows.Count = 0 Then
            If MsgBox("尚未拉取敏感字,是否立即获取敏感字数据?", vbQuestion + vbYesNo, "处理关键字") = vbYes Then
                dt_Keywords = Query("Select Badword,Method,ReplaceString From T_Badwords with(nolock)")
                Me.tssl_Status.Text = "拉取敏感字完毕."
            Else
                Return
            End If
        End If

        For Each row As System.Data.DataRow In dt_Keywords.Tables(0).Rows
            Try
                matches = System.Text.RegularExpressions.Regex.Matches(txtMessage.Text, row("badword").ToString, System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Multiline)
                If matches.Count > 0 Then
                    For Each match As System.Text.RegularExpressions.Match In matches
                        txtMessage.Select(match.Index, match.Length)
                        txtMessage.SelectionBackColor = Color.Yellow
                    Next
                End If
            Catch ex As Exception

            Finally
               
            End Try
        Next
        txtMessage.SelectionStart = 0
        txtMessage.SelectionLength = 0
    End Sub

    Private Sub 刷新关键字列表ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 刷新关键字列表ToolStripMenuItem.Click
        getDataASYN("Select Badword,Method,ReplaceString From T_Badwords with(nolock)", New System.AsyncCallback(AddressOf getKeywords_Compeleted))
    End Sub
    Private Function hasKeywords(Message As String) As String
        If dt_Keywords Is Nothing OrElse dt_Keywords.Tables.Count = 0 OrElse dt_Keywords.Tables(0).Rows.Count = 0 Then
            dt_Keywords = Query("Select Badword,Method,ReplaceString From T_Badwords with(nolock)")
            Me.tssl_Status.Text = "拉取敏感字完毕."
        End If
        If dt_Keywords Is Nothing OrElse dt_Keywords.Tables.Count = 0 OrElse dt_Keywords.Tables(0).Rows.Count = 0 Then Return ""
        Try
            For Each row As System.Data.DataRow In dt_Keywords.Tables(0).Rows
                If System.Text.RegularExpressions.Regex.IsMatch(txtMessage.Text, row("badword").ToString, System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Multiline) Then
                    Return row("badword").ToString
                End If
            Next
        Catch ex As Exception
            Return ""
        End Try
        Return ""
    End Function

    Private Sub ToolStripComboBox2_Click(sender As System.Object, e As System.EventArgs) Handles tscbInvockPersecond.Click

    End Sub

    
    Private Sub ToolStripButton1_ButtonClick(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.ButtonClick
        Dim Recipients(0 To 3) As ArrayList
        Dim Keywords As String, QueueSize As Long
        Dim Simulation As Boolean, RecordLog As Boolean, AddTag As Boolean, ShowDebugInfo As Boolean
        Simulation = CheckBox1.Checked
        RecordLog = CheckBox2.Checked
        AddTag = Me.tssm_addEnd.Checked
        ShowDebugInfo = Me.chkShowDebugInfo.Checked
        QueueSize = IIf(Not IsDBNull(UserPermissions.UserData("QueueSize")) AndAlso UserPermissions.UserData("QueueSize") > 0, UserPermissions.UserData("QueueSize"), IIf(IsNumeric(tst_QueueSize.Text) = True, tst_QueueSize.Text, My.Settings.QueueSize))
        'QueueSize = IIf(IsNumeric(tst_QueueSize.Text) = True, tst_QueueSize.Text, My.Settings.QueueSize)
        QueueSize = IIf(QueueSize = 0, 9999999, QueueSize)
        ThreadPool.SetMaxThreads(My.Settings.MaxThreadCount, My.Settings.MaxThreadCount)
        ThreadPool.SetMinThreads(My.Settings.MinThreadCount, My.Settings.MinThreadCount)
        If txtMessage.Text = "" Then MsgBox("请先输入消息内容后再发送.", vbInformation, "发送消息") : txtMessage.Focus() : Return
        If txtRecipients.Text = "" And rbInput.Checked Then MsgBox("请先输入收件人(每行一个)后再发送.", vbInformation, "发送消息") : txtRecipients.Focus() : Return
        If txtFileName.Text = "" And rbImport.Checked Then MsgBox("请先指定收件人文件后再发送.", vbInformation, "发送消息") : Return
        Keywords = hasKeywords(txtMessage.Text)
        If Keywords <> "" Then
            If MsgBox("短信内容中包含关键字[" & Keywords & "]建议修改后再发送,现在去修改吗?", vbQuestion + vbYesNo, "关键字检查") = vbYes Then
                Return
            End If
        End If
        _TotalCount = 0 : _SendCount = 0
        '获取联系人列表
        Recipients = ReadRecipients(Me.忽略重复号码ToolStripMenuItem.Checked)


        If Recipients Is Nothing Then
            MsgBox("读取联系人失败,请重试!", vbInformation, "发送消息")
            Callback_Compelted(Nothing)
            Return
        End If
        For i As Long = 0 To 3
            If Not (Recipients(i) Is Nothing) And i < 3 Then _TotalCount = _TotalCount + Recipients(i).Count
            If i = 3 And Not (Recipients(i) Is Nothing) Then
                MsgBox("收件人中包含" & Recipients(i).Count & "个错误号码,请注意检查.", vbInformation, "异常提示")

            End If
        Next
        If _TotalCount = 0 Then
            MsgBox("没有读取到收件人,请确认输入的收件人都正确", vbInformation, "发送消息") : txtRecipients.Focus()
            Callback_Compelted(Nothing)
            Return
        End If
        If MsgBox("将发送" & _TotalCount & "条短信,执行发送消息可能产生费用,您确认要继续操作吗?", vbQuestion + vbYesNo, "确认发送") = vbNo Then
            Callback_Compelted(Nothing)
            Return
        End If
        _StartTime = System.Environment.TickCount
        '初始化消息发送状态
        InitialSendMessage()

        SessionID = Guid.NewGuid().ToString
        Dim t As New Thread(New ParameterizedThreadStart(AddressOf BeginSendMessage))
        t.Start(New SendMessageParameter(SessionID, Recipients, txtMessage.Text, Me.tscbInvockPersecond.Text, Me.tscbMaxBatchNumber.Text, 0, QueueSize, Simulation, RecordLog, AddTag, ShowDebugInfo))
        ' Callback_Compelted(Nothing)
    End Sub
End Class