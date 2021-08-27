<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1501)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/CustomParameters/Form1.cs) (VB: [Form1.vb](./VB/CustomParameters/Form1.vb))
* [MyParameter.cs](./CS/CustomParameters/MyParameter.cs) (VB: [MyParameter.vb](./VB/CustomParameters/MyParameter.vb))
* [Program.cs](./CS/CustomParameters/Program.cs) (VB: [Program.vb](./VB/CustomParameters/Program.vb))
* [XtraReport1.cs](./CS/CustomParameters/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/CustomParameters/XtraReport1.vb))
<!-- default file list end -->
# Add custom parameter to the report through the End-User Designer


<p>This example illustrates how to provide the capability to add custom parameter through the End-User Designer instead of the default one. To accomplish this task you should create a custom parameter class that inherits from the parameter class. Than it is necessary to handle the XtraReport.DesignerLoaded event to get the IMenuCommandService service and replace the AddParameter menu command with a custom one. Finally your should replace parameters collection editor with your custom one and override its EditValue method to synchronize editable values with the actual report parameters.</p>

<br/>


