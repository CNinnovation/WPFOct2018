using System;
using System.Collections.Generic;
using System.Text;

namespace TupleSample
{
    public class Person
    {
        public Person(string first, string last) => (FirstName, LastName) = (first, last);

        public string FirstName { get; }

        public string LastName { get; }

        //public void Deconstruct(out string first, out string last) =>
        //    (first, last) = (FirstName, LastName);
    }

    public static class PersonExtensions
    {
        public static void Deconstruct(this Person p, out string first, out string last) =>
            (first, last) = (p.FirstName, p.LastName);
    }
}
