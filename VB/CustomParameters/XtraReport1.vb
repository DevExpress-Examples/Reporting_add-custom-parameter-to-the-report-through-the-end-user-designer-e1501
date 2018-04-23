Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports DevExpress.XtraReports.UI
Imports System.Collections.ObjectModel
Imports DevExpress.XtraReports.Parameters
Imports System.Drawing.Design

Namespace CustomParameters
	Partial Public Class XtraReport1
		Inherits DevExpress.XtraReports.UI.XtraReport
		Public Sub New()
			InitializeComponent()
			Me.myParameters_Renamed = New MyParameterCollection(Me)
		End Sub

		<Browsable(False)> _
		Public Shadows ReadOnly Property Parameters() As ParameterCollection
			Get
				Return MyBase.Parameters
			End Get
		End Property

		Private myParameters_Renamed As MyParameterCollection
		<Editor(GetType(MyCollectionEditor), GetType(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Parameters")> _
		Public ReadOnly Property MyParameters() As MyParameterCollection
			Get
				Return Me.myParameters_Renamed
			End Get
		End Property

	End Class
	Public Class MyParameterCollection
		Inherits Collection(Of MyParameter)
		Public report As XtraReport
		Public Sub New(ByVal report As XtraReport)
			Me.report = report
		End Sub
	End Class
	Friend Class MyCollectionEditor
		Inherits CollectionEditor
		Public Sub New(ByVal type As Type)
			MyBase.New(type)
		End Sub
		Public Overrides Overloads Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
			value = (CType(value, MyParameterCollection)).report.Parameters
			Return MyBase.EditValue(context, provider, value)
		End Function

	End Class
End Namespace
