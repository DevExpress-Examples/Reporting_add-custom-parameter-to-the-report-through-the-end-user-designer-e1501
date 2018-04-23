using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraReports.Parameters;
using System.ComponentModel;

namespace CustomParameters
{
    public class MyParameter : Parameter
    {
        string _valueMember;
        string _displayMember;
        string _statement;

        [DisplayName("Value Member"), Browsable(true), DefaultValue(""), Category("Data")]
        public string ValueMember
        {
            get { return _valueMember; }
            set { _valueMember = value; }
        }
        [DisplayName("Display Member"), Browsable(true), DefaultValue(""),Category("Data")]
        public string DisplayMember
        {
            get { return _displayMember; }
            set { _displayMember = value; }
        }
        [DisplayName("Statement"), Browsable(true), DefaultValue(""), Category("Data")]
        public string Statement
        {
            get { return _statement; }
            set { _statement = value; }
        }
    }
}
