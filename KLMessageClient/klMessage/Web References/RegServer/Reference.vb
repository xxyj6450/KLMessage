﻿'------------------------------------------------------------------------------
' <auto-generated>
'     此代码由工具生成。
'     运行时版本:4.0.30319.17929
'
'     对此文件的更改可能会导致不正确的行为，并且如果
'     重新生成代码，这些更改将会丢失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'此源代码是由 Microsoft.VSDesigner 4.0.30319.17929 版自动生成。
'
Namespace RegServer
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="RegisterSoapBinding", [Namespace]:="http://202.105.212.146:8080/jboss-net/services/Register")>  _
    Partial Public Class RegisterService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private getRandomOperationCompleted As System.Threading.SendOrPostCallback
        
        Private setCallBackAddrOperationCompleted As System.Threading.SendOrPostCallback
        
        Private setCallBackAddrV2OperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.klMessage.My.MySettings.Default.klMessage_RegServer_RegisterService
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event getRandomCompleted As getRandomCompletedEventHandler
        
        '''<remarks/>
        Public Event setCallBackAddrCompleted As setCallBackAddrCompletedEventHandler
        
        '''<remarks/>
        Public Event setCallBackAddrV2Completed As setCallBackAddrV2CompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://realization.webservice.uc.fin.huawei.com", ResponseNamespace:="http://202.105.212.146:8080/jboss-net/services/Register")>  _
        Public Function getRandom() As <System.Xml.Serialization.SoapElementAttribute("getRandomReturn")> String
            Dim results() As Object = Me.Invoke("getRandom", New Object(-1) {})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub getRandomAsync()
            Me.getRandomAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getRandomAsync(ByVal userState As Object)
            If (Me.getRandomOperationCompleted Is Nothing) Then
                Me.getRandomOperationCompleted = AddressOf Me.OngetRandomOperationCompleted
            End If
            Me.InvokeAsync("getRandom", New Object(-1) {}, Me.getRandomOperationCompleted, userState)
        End Sub
        
        Private Sub OngetRandomOperationCompleted(ByVal arg As Object)
            If (Not (Me.getRandomCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getRandomCompleted(Me, New getRandomCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://realization.webservice.uc.fin.huawei.com", ResponseNamespace:="http://202.105.212.146:8080/jboss-net/services/Register")>  _
        Public Function setCallBackAddr(ByVal uc As String, ByVal pw As String, ByVal rand As String, ByVal url As String) As <System.Xml.Serialization.SoapElementAttribute("setCallBackAddrReturn")> String
            Dim results() As Object = Me.Invoke("setCallBackAddr", New Object() {uc, pw, rand, url})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub setCallBackAddrAsync(ByVal uc As String, ByVal pw As String, ByVal rand As String, ByVal url As String)
            Me.setCallBackAddrAsync(uc, pw, rand, url, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub setCallBackAddrAsync(ByVal uc As String, ByVal pw As String, ByVal rand As String, ByVal url As String, ByVal userState As Object)
            If (Me.setCallBackAddrOperationCompleted Is Nothing) Then
                Me.setCallBackAddrOperationCompleted = AddressOf Me.OnsetCallBackAddrOperationCompleted
            End If
            Me.InvokeAsync("setCallBackAddr", New Object() {uc, pw, rand, url}, Me.setCallBackAddrOperationCompleted, userState)
        End Sub
        
        Private Sub OnsetCallBackAddrOperationCompleted(ByVal arg As Object)
            If (Not (Me.setCallBackAddrCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent setCallBackAddrCompleted(Me, New setCallBackAddrCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://realization.webservice.uc.fin.huawei.com", ResponseNamespace:="http://202.105.212.146:8080/jboss-net/services/Register")>  _
        Public Function setCallBackAddrV2(ByVal uc As String, ByVal pw As String, ByVal rand As String, ByVal url As String, ByVal version As String) As <System.Xml.Serialization.SoapElementAttribute("setCallBackAddrV2Return")> String
            Dim results() As Object = Me.Invoke("setCallBackAddrV2", New Object() {uc, pw, rand, url, version})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub setCallBackAddrV2Async(ByVal uc As String, ByVal pw As String, ByVal rand As String, ByVal url As String, ByVal version As String)
            Me.setCallBackAddrV2Async(uc, pw, rand, url, version, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub setCallBackAddrV2Async(ByVal uc As String, ByVal pw As String, ByVal rand As String, ByVal url As String, ByVal version As String, ByVal userState As Object)
            If (Me.setCallBackAddrV2OperationCompleted Is Nothing) Then
                Me.setCallBackAddrV2OperationCompleted = AddressOf Me.OnsetCallBackAddrV2OperationCompleted
            End If
            Me.InvokeAsync("setCallBackAddrV2", New Object() {uc, pw, rand, url, version}, Me.setCallBackAddrV2OperationCompleted, userState)
        End Sub
        
        Private Sub OnsetCallBackAddrV2OperationCompleted(ByVal arg As Object)
            If (Not (Me.setCallBackAddrV2CompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent setCallBackAddrV2Completed(Me, New setCallBackAddrV2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")>  _
    Public Delegate Sub getRandomCompletedEventHandler(ByVal sender As Object, ByVal e As getRandomCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getRandomCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")>  _
    Public Delegate Sub setCallBackAddrCompletedEventHandler(ByVal sender As Object, ByVal e As setCallBackAddrCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class setCallBackAddrCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")>  _
    Public Delegate Sub setCallBackAddrV2CompletedEventHandler(ByVal sender As Object, ByVal e As setCallBackAddrV2CompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class setCallBackAddrV2CompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace
