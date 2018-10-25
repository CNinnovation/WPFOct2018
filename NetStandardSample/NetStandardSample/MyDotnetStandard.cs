using System;
using TheReallyOldLib;

namespace NetStandardSample
{
    public class MyDotnetStandard
    {
        public string JustAMethod(string s)
        {
            var d = new DotnetFramework();
            return d.ReturnAString(s);
        }

        public void ShowMessage(string s)
        {
            var d = new DotnetFramework();
            d.ShowAMessage(s);
        }

    }
}
