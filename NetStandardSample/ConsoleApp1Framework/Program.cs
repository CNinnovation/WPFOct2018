using NetStandardSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            var std = new MyDotnetStandard();
            string result = std.JustAMethod("hello");
            std.ShowMessage("hello");
        }
    }
}
