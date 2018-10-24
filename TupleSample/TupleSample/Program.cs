using System;

namespace TupleSample
{
    readonly struct MyStruct
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            var t1 = Tuple.Create("hello", 42);
            string s1 = t1.Item1;
            int i1 = t1.Item2;
            // t1.Item1 = "test";

            var t2 = (s: "magic", i: 42, p: new Person("Stephanie", "Nagel"));  // ValueTuple
            t2.s = "more magic";


            var person = new Person("Matthias", "Nagel");
            // deconstruction
            (string mystring, int myval) = ("magic", 42);

            (string first, string last) = person;

            Console.WriteLine(first);


        }
    }
}
