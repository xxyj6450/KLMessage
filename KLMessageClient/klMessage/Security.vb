Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.SqlServer.Server
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Data.SqlTypes
Imports System.Security.Cryptography
Namespace SOP.Security
    Public Class Security
        '散列加密算法

        Public Shared Function HashAlgorithm(ByVal Input As String, ByVal Algorithm As String, ByVal Charset As String) As String
            Dim _md5 As System.Security.Cryptography.HashAlgorithm = System.Security.Cryptography.HashAlgorithm.Create(Algorithm)
            Dim fs() As Byte, sb As New System.Text.StringBuilder
            fs = _md5.ComputeHash(getBytes(Input, Charset))
            For i As Integer = 0 To fs.Length - 1
                sb.Append(fs(i).ToString("x2"))
            Next
            Return sb.ToString()
        End Function
 
        '对称加密算法
        <Microsoft.SqlServer.Server.SqlFunction()> _
        Public Shared Function SymmetricEncrypt(ByVal Input As String, ByVal Key As String, ByVal IV As String, ByVal Algorithm As String, ByVal Charset As String) As String
            Dim sa As System.Security.Cryptography.SymmetricAlgorithm = System.Security.Cryptography.SymmetricAlgorithm.Create(Algorithm) ' New System.Security.Cryptography.DESCryptoServiceProvider
            Dim data() As Byte
            sa.Key = getBytes(Key, Charset)
            sa.IV = getBytes(IV, Charset)
            '将数据转换成字节
            data = getBytes(Input, Charset)
            Using ms As New System.IO.MemoryStream
                '将数据加密,并准备写入ms内存流中
                Dim cs As New System.Security.Cryptography.CryptoStream(ms, sa.CreateEncryptor, CryptoStreamMode.Write)
                '写入加密数据至缓存区
                cs.Write(data, 0, data.Length)
                '将数据更新到流对象
                cs.FlushFinalBlock()
                '关闭
                cs.Close()
                '用base64编码一次
                Return Convert.ToBase64String(ms.ToArray)

            End Using
        End Function
        '对称解密算法
        <Microsoft.SqlServer.Server.SqlFunction()> _
        Public Shared Function SymmetricDecrypt(ByVal Input As String, ByVal Key As String, ByVal IV As String, ByVal Algorithm As String, ByVal Charset As String) As String
            Dim sa As System.Security.Cryptography.SymmetricAlgorithm = System.Security.Cryptography.SymmetricAlgorithm.Create(Algorithm) '  System.Security.Cryptography.DESCryptoServiceProvider
            Dim data() As Byte
            sa.Key = getBytes(Key, Charset)
            sa.IV = getBytes(IV, Charset)
            '将数据用base64解码一次
            data = Convert.FromBase64String(Input)
            Using ms As New System.IO.MemoryStream()
                '将数据加密,并准备写入ms内存流中
                Dim cs As New System.Security.Cryptography.CryptoStream(ms, sa.CreateDecryptor, CryptoStreamMode.Write)
                '写入加密数据至缓存区
                cs.Write(data, 0, data.Length)
                '将数据更新到流对象
                cs.FlushFinalBlock()
                '关闭
                cs.Close()
                '再转换回字符串
                Return getString(ms.ToArray, Charset)

            End Using
        End Function
        'Base64
        <Microsoft.SqlServer.Server.SqlFunction()> _
        Public Shared Function Base64Encode(ByVal Input As String, ByVal Charset As String) As String
            Return Convert.ToBase64String(getBytes(Input, Charset))
        End Function
        <Microsoft.SqlServer.Server.SqlFunction()> _
        Public Shared Function Base64Decode(ByVal Input As String, ByVal Charset As String) As String
            Return getString(Convert.FromBase64String(Input), Charset)

        End Function
      
    End Class

End Namespace
