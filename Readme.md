# Add custom parameter to the report through the End-User Designer


<p>This example illustrates how to provide the capability to add custom parameter through the End-User Designer instead of the default one. To accomplish this task you should create a custom parameter class that inherits from the parameter class. Than it is necessary to handle the XtraReport.DesignerLoaded event to get the IMenuCommandService service and replace the AddParameter menu command with a custom one. Finally your should replace parameters collection editor with your custom one and override its EditValue method to synchronize editable values with the actual report parameters.</p>

<br/>


