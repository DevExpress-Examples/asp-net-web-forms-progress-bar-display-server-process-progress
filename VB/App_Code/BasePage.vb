Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web
Imports System.Web.Services

Public Class BasePage
    Inherits System.Web.UI.Page

    Private Shared ReadOnly Property Operation() As Operation
        Get
            If HttpContext.Current.Session("_Operation") Is Nothing Then
                HttpContext.Current.Session("_Operation") = New Operation()
            End If
            Return TryCast(HttpContext.Current.Session("_Operation"), Operation)
        End Get
    End Property

    <WebMethod(EnableSession := True)> _
    Public Shared Function GetProgress() As String
        If HttpContext.Current.Session Is Nothing OrElse Not (TypeOf HttpContext.Current.Session("_Operation") Is Operation) Then
            Return "NaN"
        End If
        Dim progress = (TryCast(HttpContext.Current.Session("_Operation"), Operation)).Progress
        Return progress.ToString()
    End Function

    <WebMethod(EnableSession := True)> _
    Public Shared Sub StartOperation()
        Operation.AsyncStart(5000)
    End Sub
End Class
