Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraReports.Parameters
Imports System.ComponentModel

Namespace CustomParameters
	Public Class MyParameter
		Inherits Parameter
		Private _valueMember As String
		Private _displayMember As String
		Private _statement As String

		<DisplayName("Value Member"), Browsable(True), DefaultValue(""), Category("Data")> _
		Public Property ValueMember() As String
			Get
				Return _valueMember
			End Get
			Set(ByVal value As String)
				_valueMember = value
			End Set
		End Property
		<DisplayName("Display Member"), Browsable(True), DefaultValue(""), Category("Data")> _
		Public Property DisplayMember() As String
			Get
				Return _displayMember
			End Get
			Set(ByVal value As String)
				_displayMember = value
			End Set
		End Property
		<DisplayName("Statement"), Browsable(True), DefaultValue(""), Category("Data")> _
		Public Property Statement() As String
			Get
				Return _statement
			End Get
			Set(ByVal value As String)
				_statement = value
			End Set
		End Property
	End Class
End Namespace
