Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Services
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class ScriptManager
	Inherits BasePage

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If Not IsPostBack Then
			Session.Clear()
		End If
	End Sub
End Class