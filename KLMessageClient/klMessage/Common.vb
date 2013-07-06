Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Management
Imports System.Net
Module Common
    Public CurrentUser As New CommonLib.cUser
    Public IP As String
    Public MAC As String
    Public CPUID As String
    Public DiskID As String
    Public dt_Keywords As System.Data.DataSet
    Public Sub main()
        Dim f As New frmLogin
        IP = GetIP()
        MAC = GetMacAddress()
        CPUID = GetCpuID()
        DiskID = GetDiskID()
        Application.EnableVisualStyles()
 
        Application.Run(f)
    End Sub
    Public Delegate Function QueryData_Deletegate(sql As String) As DataSet
    Public Sub getDataASYN(sql As String, Callback As System.AsyncCallback)
        Dim f As New QueryData_Deletegate(AddressOf Query)
        f.BeginInvoke(sql, Callback, Nothing)

    End Sub
    Public Function Query(sql As String) As DataSet
        Dim ws As New SendMessage.myWebService
        Try
            Return ws.getData(CurrentUser.Usercode, CurrentUser.Password, sql)
        Catch ex As Exception
            MsgBox("获取数据异常" & vbCrLf & ex.Message, vbInformation, "提示信息")
            Return Nothing
        End Try

    End Function
    Public Delegate Function UpdateDataSet_Delegate(ds As System.Data.DataSet, ByVal MetaQueryString As String, _
                                  ByVal UpdateCommand As SendMessage.Command, ByVal InsertCommand As SendMessage.Command, _
                                  ByVal DeleteCommand As SendMessage.Command) As System.Data.DataSet
    Public Function UpdateDataSet(ds As System.Data.DataSet, ByVal MetaQueryString As String, _
                                  ByVal UpdateCommand As SendMessage.Command, ByVal InsertCommand As SendMessage.Command, _
                                  ByVal DeleteCommand As SendMessage.Command) As System.Data.DataSet
        Dim ws As New SendMessage.myWebService

            Return ws.Update(CurrentUser.Usercode, CurrentUser.Password, ds.GetChanges, MetaQueryString, UpdateCommand, InsertCommand, DeleteCommand)
  
    End Function
    Public Delegate Function Query_Deletgate(sql As String) As DataSet

    '转换字符串至指定编码的字节
    Public Function getBytes(ByVal Input As String, ByVal Charset As String) As Byte()
        Select Case Charset
            Case "UTF-16", "Unicode", "UTF16"
                Return System.Text.Encoding.Unicode.GetBytes(Input)
            Case "UTF-7", "UTF7"
                Return System.Text.Encoding.UTF7.GetBytes(Input)
            Case "UTF-8", "UTF8"
                Return System.Text.Encoding.UTF8.GetBytes(Input)
            Case "UTF-32", "UTF32"
                Return System.Text.Encoding.UTF32.GetBytes(Input)
            Case "ASCII"
                Return System.Text.Encoding.ASCII.GetBytes(Input)
            Case "", "Default"
                Return System.Text.Encoding.Default.GetBytes(Input)
            Case Else
                Return System.Text.Encoding.Default.GetBytes(Input)
        End Select
    End Function
    '字节转换至指定编码的字符串
    Public Function getString(ByVal Input() As Byte, ByVal Charset As String) As String
        Select Case Charset
            Case "UTF-16", "Unicode", "UTF16"
                Return System.Text.Encoding.Unicode.GetString(Input)
            Case "UTF-7", "UTF7"
                Return System.Text.Encoding.UTF7.GetString(Input)
            Case "UTF-8", "UTF8"
                Return System.Text.Encoding.UTF8.GetString(Input)
            Case "UTF-32", "UTF32"
                Return System.Text.Encoding.UTF32.GetString(Input)
            Case "ASCII"
                Return System.Text.Encoding.ASCII.GetString(Input)
            Case "", "Default"
                Return System.Text.Encoding.Default.GetString(Input)
            Case Else
                Return System.Text.Encoding.Default.GetString(Input)
        End Select
    End Function
    Public Delegate Function SendMessage_Delegate(SessionID As String, RegisterUsercode As String, RegisterPassword As String, _
                                AccessUsercode As String, AccessPassword As String, _
                                Usercode As String, Password As String, _
                                Recipients() As String, Nettype As Integer, Message As String, _
                                imulation As Boolean, RecordLog As Boolean, Sleep As Long, AddTag As Boolean, ShowDebugInfo As Boolean) As Integer
    Public Function SendMessage(SessionID As String, RegisterUsercode As String, RegisterPassword As String, _
                                AccessUsercode As String, AccessPassword As String, _
                                Usercode As String, Password As String, _
                                Recipients() As String, Nettype As Integer, Message As String, _
                                Simulation As Boolean, RecordLog As Boolean, Sleep As Long, AddTag As Boolean, ShowDebugInfo As Boolean) As Integer
        Dim ws1 As New SendServer.SendSMSService
        Dim connID As Long, rand As String, ret As Int32, MessageID As Long
        Dim ws2 As New SendMessage.myWebService, Count As Integer
        Dim events As String, t As Long

        '登记消息,并获取MessageID
        events = "登记消息"
        Try
            If ShowDebugInfo = True Then Console.WriteLine("发送号码" & System.String.Join(";", Recipients))
            t = Environment.TickCount

            ws2.Timeout = 10000
            MessageID = ws2.SendMessage(Usercode, Password, "" & Join(Recipients, ";"), Recipients.Length, SessionID, RegisterUsercode, _
                            AccessUsercode, connID, Nettype)
            If ShowDebugInfo = True Then Console.WriteLine("注册消息" & MessageID & ",用时" & Environment.TickCount - t & "ms")
            If AddTag = True Then Message = Message & ChrW((MessageID Mod 40869) + 19968)
BeginSend:
            events = "获取连接"
            t = Environment.TickCount
            connID = MessageRegister.getConnectionID(RegisterUsercode, RegisterPassword)
            rand = MessageRegister.getRandom()
            If ShowDebugInfo = True Then Console.WriteLine("获取连接" & connID & ",用时" & Environment.TickCount - t & "ms")
            '只在非模拟发送时才调用调用这个接口
            If Simulation = False Then
                events = "发送短信"
                ws1.Timeout = 10000
                t = Environment.TickCount
                ret = ws1.sendSMS(AccessUsercode, SOP.Security.Security.HashAlgorithm(rand & AccessPassword & AccessPassword, "md5", "UTF-8"), rand, Recipients, "1", SOP.Security.Security.Base64Encode(Message, ""), MessageID, connID)
                If ShowDebugInfo = True Then Console.WriteLine("发送短信" & System.String.Join(";", Recipients) & ",用时" & Environment.TickCount - t & "ms")
                If ret < 0 And Count <= 2 Then
                    Count = Count + 1
                    events = "获取连接"
                    MessageRegister.getConnectionID(RegisterUsercode, RegisterPassword, True)
                    GoTo BeginSend
                End If
            End If
        Catch ex As Exception

            Throw New Exception(events & ex.Message)

        Finally
            Try
                t = Environment.TickCount
                If ret < 0 Then ws2.FinishedSendMessage(Usercode, Password, RegisterUsercode, AccessUsercode, SessionID, MessageID, Recipients.Length, Nettype, ret)
                If RecordLog = True Then WriteLog(Application.StartupPath & "\data\" & SessionID & ".txt", String.Join(vbCrLf, Recipients) & vbTab & MessageID & vbTab & ret & vbTab & Now)
                If ShowDebugInfo = True Then Console.WriteLine("报告状态" & System.String.Join(";", Recipients) & ",用时" & Environment.TickCount - t & "ms")
            Catch ex As Exception

                'MsgBox("发送短信发生了点小意外,可能导致统计信息不正确,不过放心,短信已经给您发出去了!" & vbCrLf & "您最好把收到的这个消息(截图)告诉管理员." & vbCrLf & ex.Message, vbInformation, "发送短信")
            End Try

        End Try
        Return ret
    End Function
    Private Function CharToString(c As Char) As String
        Return c.ToString
    End Function
    Public Function SplitKeyword(Keyword As String, Optional Method As String = "分割关键字", Optional ReplaceString As String = "-") As String
        Select Case Method
            Case "分割关键字"
                Return String.Join(ReplaceString, System.Array.ConvertAll(Keyword.ToCharArray(), New System.Converter(Of Char, String)(AddressOf CharToString)))
            Case "替换关键字"
                Return ReplaceString
            Case "替换成繁体"
                Return Microsoft.VisualBasic.Strings.StrConv(Keyword, VbStrConv.TraditionalChinese)
        End Select
    End Function

    '返回运营商类型 0:电信 1:移动 2：联通  3:异常号码
    Public Function getNetType(SeriesNumber As String) As Integer
        Select Case Left(SeriesNumber, 3)
            Case "134" To "139", "147", "150", "151", "152", "157", "158", "159", "187", "188", "182", "183"
                Return 0
            Case "130", "131", "132", "145", "147", "155", "156", "182", "183", "185", "186"
                Return 2
            Case "133", "153", "180", "181", "189"
                Return 1
            Case Else
                Return 3
        End Select
    End Function
     
    Public Function sqlCommandToCommand(cmd As System.Data.SqlClient.SqlCommand) As SendMessage.Command
        Dim _cmd As New SendMessage.Command
        _cmd.CommandText = cmd.CommandText
        _cmd.CommandType = cmd.CommandType
        System.Array.Resize(_cmd.Parameters, cmd.Parameters.Count)
        For i As Integer = 0 To cmd.Parameters.Count - 1
            _cmd.Parameters(i) = New SendMessage.Parameter
            _cmd.Parameters(i).Direction = cmd.Parameters(i).Direction
            _cmd.Parameters(i).Name = cmd.Parameters(i).ParameterName
            _cmd.Parameters(i).SourceColumn = cmd.Parameters(i).SourceColumn
            _cmd.Parameters(i).SourceVersion = cmd.Parameters(i).SourceVersion
            _cmd.Parameters(i).SourceColumn = cmd.Parameters(i).SourceColumn
            _cmd.Parameters(i).Type = cmd.Parameters(i).SqlDbType
            _cmd.Parameters(i).Value = cmd.Parameters(i).Value

        Next
        Return _cmd
    End Function
    Public Function GetCpuID() As String
        Try
            '获取CPU序列号代码 
            Dim cpuInfo As String = ""
            'cpu序列号 
            Dim mc As New ManagementClass("Win32_Processor")
            Dim moc As ManagementObjectCollection = mc.GetInstances()
            For Each mo As ManagementObject In moc
                cpuInfo = mo.Properties("ProcessorId").Value.ToString()
            Next
            moc = Nothing
            mc = Nothing
            Return cpuInfo
        Catch
            Return "unknow"
        Finally
        End Try

    End Function
    Public Function GetMacAddress() As String
        Try
            '获取网卡硬件地址 
            Dim mac As String = ""
            Dim mc As New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim moc As ManagementObjectCollection = mc.GetInstances()
            For Each mo As ManagementObject In moc
                If DirectCast(mo("IPEnabled"), Boolean) = True Then
                    mac = mo("MacAddress").ToString()
                    Exit For
                End If
            Next
            moc = Nothing
            mc = Nothing
            Return mac
        Catch
            Return "unknow"
        Finally
        End Try
 
    End Function
    Public Function GetDiskID() As String
        Try
            '获取硬盘ID 
            Dim HDid As [String] = ""
            Dim mc As New ManagementClass("Win32_DiskDrive")
            Dim moc As ManagementObjectCollection = mc.GetInstances()
            For Each mo As ManagementObject In moc
                HDid = DirectCast(mo.Properties("Model").Value, String)
            Next
            moc = Nothing
            mc = Nothing
            Return HDid
        Catch
            Return "unknow"
        Finally
        End Try

    End Function
    Public Function GetIP() As String
        Dim tempip As String = "", all As String
        Try
            Dim wr As WebRequest = WebRequest.Create("http://iframe.ip138.com/ic.asp")
            With wr
                .Method = "get"

            End With

            Using sr As New System.IO.StreamReader(wr.GetResponse().GetResponseStream(), System.Text.Encoding.Default)
                all = sr.ReadToEnd()
            End Using
            '读取网站的数据
            Dim start As Integer = all.IndexOf("[") + 1
            Dim [end] As Integer = all.IndexOf("]", start)
            tempip = all.Substring(start, [end] - start)
 
        Catch ex As Exception
            Return GetIPAddress()
        End Try
        Return tempip
    End Function
    Public Function GetIPAddress() As String
        Try
            '获取IP地址 
            Dim st As String = ""
            Dim mc As New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim moc As ManagementObjectCollection = mc.GetInstances()
            For Each mo As ManagementObject In moc
                If DirectCast(mo("IPEnabled"), Boolean) = True Then
                    'st=mo["IpAddress"].ToString(); 
                    Dim ar As System.Array
                    ar = DirectCast((mo.Properties("IpAddress").Value), System.Array)
                    st = ar.GetValue(0).ToString()
                    Exit For
                End If
            Next
            moc = Nothing
            mc = Nothing
            Return st
        Catch
            Return "unknow"
        Finally
        End Try

    End Function
    Private Sub WriteLog(FileName As String, Message As String, Optional Append As Boolean = True)
        Dim f As System.IO.StreamWriter
        Try
            If Append = False Then
                f = System.IO.File.CreateText(FileName)

            Else
                f = System.IO.File.AppendText(FileName)
            End If

            f.WriteLine(Message)
            f.Flush()
            f.Close()
        Catch ex As Exception

        End Try
    End Sub
End Module
