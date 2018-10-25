using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReallyOldLib
{
    public class DotnetFramework
    {
        public string ReturnAString(string s) => s.ToUpper();

        public void ShowAMessage(string s)
        {
            System.Windows.Forms.MessageBox.Show("Test");
        }
    }
}
