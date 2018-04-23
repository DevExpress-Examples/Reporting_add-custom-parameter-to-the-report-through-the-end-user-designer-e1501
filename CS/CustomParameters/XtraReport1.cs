using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using DevExpress.XtraReports.UI;
using System.Collections.ObjectModel;
using DevExpress.XtraReports.Parameters;
using System.Drawing.Design;

namespace CustomParameters
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
            this.myParameters = new MyParameterCollection(this);
        }

        [Browsable(false)]
        new public ParameterCollection Parameters { get { return base.Parameters; } }

        MyParameterCollection myParameters;
        [Editor(typeof(MyCollectionEditor), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Parameters")]
        public MyParameterCollection MyParameters
        { get { return this.myParameters; } }

    }
    public class MyParameterCollection : Collection<MyParameter>
    {
        public XtraReport report;
        public MyParameterCollection(XtraReport report)
        {
            this.report = report;
        }
    }
    class MyCollectionEditor : CollectionEditor
    {
        public MyCollectionEditor(Type type)
            : base(type)
        {
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            value = ((MyParameterCollection)value).report.Parameters;
            return base.EditValue(context, provider, value);
        }

    }
}
