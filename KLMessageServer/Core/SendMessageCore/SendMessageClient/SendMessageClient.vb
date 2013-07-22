
Public Class SendMessageClient
    Private Shared MessageList As New System.Collections.Concurrent.ConcurrentQueue(Of SendMessageParameter)
    Private Shared WithEvents KLMessage As KLMessage.SendMessageCore
    Private Shared SendMessageThread As New Threading.Thread(New System.Threading.ThreadStart(AddressOf StartSendMessage))
    Private Shared ClientInformationLog As log4net.ILog
    Private Shared _Wait As New System.Threading.AutoResetEvent(False)
    '事件定义
    '开始发送短信,在整批短信发送时触发一次,可用于记录线程信息
    Public Shared Event BeginSendMessage(UserMessageID As String, SessionID As String, TotalCount As Long, StartTime As Long, Content As String, Usercode As String)
    '报告每条短信的发送状态,只记录一条短信从发送开始到发送结束的过程,可用于显示每条短信的发送状态
    Public Shared Event ReportMessageStatus(SendEvent As SendMessageCore.enumSendEvent, MessageInfo As MessageInfo)
    '报告短信发送进度,记录整个短信发送过程的进度,可用于短信的整体发送进度,速度,时长与预计剩余时间
    Public Shared Event ReportProgress(UserMessageID As String, SessionID As String, TotalCount As UInt64, SendCount As UInt64, SuccessedCount As Long, SpentTime As UInt64, Information As String)
    '报告杂项信息,报告各种各样的信息,包括异常,警告,成功,状态等信息,可用于输出调试或日志信息
    Public Shared Event ReportInformation(Status As Long, Information As String, Param As Object)
    '发送短信结束,在整批短信发送结束时报告此消息,触发一次,可用于处理线程信息
    Public Shared Event SendCompeleted(UserMessageID As String, SessionID As String, TotalCount As UInt64, SendCount As UInt64, SuccessedCount As Long, SpentTime As UInt64, Status As Long)
    '发送短信结束,在整批短信发送结束时报告此消息,触发一次,可用于处理线程信息
    Public Shared Event Enqueue(Message As SendMessageParameter)
    '发送短信结束,在整批短信发送结束时报告此消息,触发一次,可用于处理线程信息
    Public Shared Event Dequeue(Message As SendMessageParameter)

    Public Shared Function SendMessage(Message As SendMessageParameter) As Long
        MessageList.Enqueue(Message)
        RaiseEvent Enqueue(Message)
        ClientInformationLog = log4net.LogManager.GetLogger("ClientInformation")
        ClientInformationLog.Info("当前线程状态" & SendMessageThread.ThreadState & "-" & SendMessageThread.ThreadState.ToString)
        If SendMessageThread.ThreadState = Threading.ThreadState.Unstarted Then
            SendMessageThread.Start()
        ElseIf SendMessageThread.ThreadState <> Threading.ThreadState.Running Then
            SendMessageThread = New Threading.Thread(New System.Threading.ThreadStart(AddressOf StartSendMessage))
            SendMessageThread.Start()
 
        End If
        Return 0
    End Function
    Private Shared Sub StartSendMessage()
        Dim MessageInfo As SendMessageParameter, ret As Boolean
        If KLMessage Is Nothing Then KLMessage = New KLMessage.SendMessageCore
        While Not MessageList.IsEmpty
            Try
                ret = MessageList.TryDequeue(MessageInfo)
                If ret = True Then
                    RaiseEvent Dequeue(MessageInfo)
                    KLMessage.SendMessage(MessageInfo.Version, MessageInfo.UserMessageID, MessageInfo.SessionID, MessageInfo.MessageType, MessageInfo.Usercode, MessageInfo.Password, _
                                          MessageInfo.Recipients, MessageInfo.Message, MessageInfo.CallbackURL, MessageInfo.ThreadMode, _
                                          MessageInfo.MaxBatchNumber, MessageInfo.InvockPerSecond, MessageInfo.QueueSize, _
                                          MessageInfo.Simulation, MessageInfo.RecordLog, MessageInfo.AddTag, _
                                          MessageInfo.IP, MessageInfo.MAC, MessageInfo.CPUID, MessageInfo.DiskID, MessageInfo.ComputerName, MessageInfo.ComputerUserName)
                Else
                    ClientInformationLog.Error("取出消息异常")
                End If
            Catch ex As Exception
                ClientInformationLog = log4net.LogManager.GetLogger("FailedMessage")
                ClientInformationLog.Error("beginSendMessage", ex)
                Continue While
            End Try
        End While
        ClientInformationLog.Info("发送完这批了")
    End Sub

    Private Shared Sub KLMessage_BeginSendMessage(UserMessageID As String, SessionID As String, TotalCount As Long, StartTime As Long, Content As String, Usercode As String) Handles KLMessage.BeginSendMessage
        RaiseEvent BeginSendMessage(UserMessageID, SessionID, TotalCount, StartTime, Content, Usercode)
    End Sub

    Private Shared Sub KLMessage_ReportInformation(Status As Long, Information As String, Param As Object) Handles KLMessage.ReportInformation
        RaiseEvent ReportInformation(Status, Information, Param)
    End Sub

    Private Shared Sub KLMessage_ReportMessageStatus(SendEvent As SendMessageCore.enumSendEvent, MessageInfo As MessageInfo) Handles KLMessage.ReportMessageStatus
        RaiseEvent ReportMessageStatus(SendEvent, MessageInfo)
    End Sub

    Private Shared Sub KLMessage_ReportProgress(UserMessageID As String, SessionID As String, TotalCount As ULong, SendCount As ULong, SuccessedCount As Long, SpentTime As ULong, Information As String) Handles KLMessage.ReportProgress
        RaiseEvent ReportProgress(UserMessageID, SessionID, TotalCount, SendCount, SuccessedCount, SpentTime, Information)
    End Sub

    Private Shared Sub KLMessage_SendCompeleted(UserMessageID As String, SessionID As String, TotalCount As ULong, SendCount As ULong, SuccessedCount As Long, SpentTime As ULong, Status As Long) Handles KLMessage.SendCompeleted
        RaiseEvent SendCompeleted(UserMessageID, SessionID, TotalCount, SendCount, SuccessedCount, SpentTime, Status)
    End Sub
End Class