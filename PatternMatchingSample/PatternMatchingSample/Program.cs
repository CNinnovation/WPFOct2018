using System;

namespace PatternMatchingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            PatternsSample();
        }

        static void PatternsSample()
        {
            object[] data = { 42, "astring", null, new Person() { FirstName = "Katharina", LastName = "Nagel" } };
            foreach (var item in data)
            {
                // IsSample(item);
                SwitchSample(item);
            }
        }

        static void IsSample(object o)
        {
            // if (o is null) throw new ArgumentNullException(nameof(o));

            if (o is 42)  // const pattern
            {
                Console.WriteLine("it's 42");
            }

            if (o is int i)  // type pattern
            {
                Console.WriteLine($"it's an int with {i}");
            }

            if (o is Person p && p.LastName == "Nagel")
            {
                Console.WriteLine($"person {p.FirstName}");
            }

            if (o is var v)  // var pattern
            {
                Console.WriteLine($"it's var of type {v?.GetType().Name}");
            }
        }

        static void SwitchSample(object o)
        {
            switch (o)
            {
                case 42: // const pattern
                    Console.WriteLine("42");
                    break;
                case null: // const pattern
                    Console.WriteLine("null");
                    break;
                case int i: // type pattern
                    Console.WriteLine($"int {i}");
                    break;

                case Person p when p.FirstName.StartsWith("Kat"):
                    Console.WriteLine($"person {p}");
                    break;
                case Person p:
                    Console.WriteLine("other person");
                    break;
                //case var v:
                //    Console.WriteLine("always var");
                //    break;
                default:
                    break;
            }
        }
    }
}
