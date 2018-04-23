using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.Design.Commands;

namespace CustomParameters
{
    public partial class Form1 : Form
    {
        IDesignerHost designerHost;
        ISelectionService selectionServ;
        IComponentChangeService changeServ;
        XtraReport report;
        public Form1()
        {
            InitializeComponent();
            xrDesignPanel1.OpenReport(new XtraReport1());
        }

        private void xrDesignPanel1_DesignerHostLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        {
            report = e.DesignerHost.RootComponent as XtraReport;
            designerHost = e.DesignerHost;
            selectionServ = e.DesignerHost.GetService(typeof(ISelectionService)) as ISelectionService;
            changeServ = e.DesignerHost.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            IMenuCommandService menuCommandService = e.DesignerHost.GetService(typeof(IMenuCommandService)) as IMenuCommandService;
            menuCommandService.RemoveCommand(menuCommandService.FindCommand(FieldListCommands.AddParameter));
            MenuCommand command = new MenuCommand(new EventHandler(AddParameter), FieldListCommands.AddParameter);
            menuCommandService.AddCommand(command);
        }
        void AddParameter(object sender, EventArgs e)
        {
            string description = String.Format(DesignSR.Trans_Add, typeof(MyParameter).Name);
            DesignerTransaction transaction = designerHost.CreateTransaction(description);
            MyParameter parameter = new MyParameter();
            try
            {
                PropertyDescriptor property = DevExpress.XtraReports.Native.XRAccessor.GetPropertyDescriptor(report, XRComponentPropertyNames.Parameters);
                changeServ.OnComponentChanging(report, property);
                ReportDesigner.AddToContainer(designerHost, parameter);
                report.Parameters.Add(parameter);
                changeServ.OnComponentChanged(report, property, null, null);
            }
            finally
            {
                transaction.Commit();
            }
            selectionServ.SetSelectedComponents(new object[] { parameter });
        }
    }
}