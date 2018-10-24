using System;
using System.IO;

namespace RefSample
{

    ref struct MyRefStruct
    {
        public int X;

        public override string ToString() => "A";
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3, 4, 5, 6, 7 };
            ref int x = ref GetValue(arr1, 3);
            Console.WriteLine(x);
            x = 42;
            Console.WriteLine(arr1[3]);

            Span<int> span1 = arr1.AsSpan();
            foreach (var item in span1)
            {
                Console.WriteLine(item);
            }

            Span<int> span2 = span1.Slice(3, 3);
            Console.WriteLine(span2[0]);

            Stream stream = new MemoryStream();
            string s1 = "the quick brown fox jumped over the lazy dogs 1234567890 times";
            ReadOnlySpan<char> span3 = s1.AsSpan();


            MyRefStruct x1 = new MyRefStruct();
            string s2 = x1.ToString();
            // object o = x1;

        }

        static ref int GetValue(int[] data, int index)
        {
            ref int val = ref data[index];  // ref local
            return ref val;
        }

        static void UseRefParameter(in int x)
        {
            // x = 42;  // cannot be changed
        }
    }
}
