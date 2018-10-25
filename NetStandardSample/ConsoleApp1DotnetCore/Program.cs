using NetStandardSample;
using System;

namespace ConsoleApp1DotnetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var std = new MyDotnetStandard();
            string result = std.JustAMethod("hello");
            Console.WriteLine(result);
            std.ShowMessage("hello");
        }
    }
}
