using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BindingSample.Utilities
{
    public class MyTraceListener : TraceListener
    {
        public override void Write(string message)
        {
        }
        public override void WriteLine(string message)
        {

        }
    }
}
