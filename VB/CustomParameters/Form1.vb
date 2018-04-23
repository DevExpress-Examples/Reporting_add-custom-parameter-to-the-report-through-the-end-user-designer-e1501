Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Design
Imports DevExpress.XtraReports.Design.Commands

Namespace CustomParameters
	Partial Public Class Form1
		Inherits Form
		Private designerHost As IDesignerHost
		Private selectionServ As ISelectionService
		Private changeServ As IComponentChangeService
		Private report As XtraReport
		Public Sub New()
			InitializeComponent()
			xrDesignPanel1.OpenReport(New XtraReport1())
		End Sub

		Private Sub xrDesignPanel1_DesignerHostLoaded(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs) Handles xrDesignPanel1.DesignerHostLoaded
			report = TryCast(e.DesignerHost.RootComponent, XtraReport)
			designerHost = e.DesignerHost
			selectionServ = TryCast(e.DesignerHost.GetService(GetType(ISelectionService)), ISelectionService)
			changeServ = TryCast(e.DesignerHost.GetService(GetType(IComponentChangeService)), IComponentChangeService)
			Dim menuCommandService As IMenuCommandService = TryCast(e.DesignerHost.GetService(GetType(IMenuCommandService)), IMenuCommandService)
			menuCommandService.RemoveCommand(menuCommandService.FindCommand(FieldListCommands.AddParameter))
			Dim command As New MenuCommand(New EventHandler(AddressOf AddParameter), FieldListCommands.AddParameter)
			menuCommandService.AddCommand(command)
		End Sub
		Private Sub AddParameter(ByVal sender As Object, ByVal e As EventArgs)
			Dim description As String = String.Format(DesignSR.Trans_Add, GetType(MyParameter).Name)
			Dim transaction As DesignerTransaction = designerHost.CreateTransaction(description)
			Dim parameter As New MyParameter()
			Try
				Dim [property] As PropertyDescriptor = DevExpress.XtraReports.Native.XRAccessor.GetPropertyDescriptor(report, XRComponentPropertyNames.Parameters)
				changeServ.OnComponentChanging(report, [property])
				ReportDesigner.AddToContainer(designerHost, parameter)
				report.Parameters.Add(parameter)
				changeServ.OnComponentChanged(report, [property], Nothing, Nothing)
			Finally
				transaction.Commit()
			End Try
			selectionServ.SetSelectedComponents(New Object() { parameter })
		End Sub
	End Class
End Namespace