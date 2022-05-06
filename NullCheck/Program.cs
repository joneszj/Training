using System;
using System.Collections.Generic;

namespace NullCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            // There is no way to get null using the Console, so we will have to simulate null values in our own variables
            // given a collection of nullable types, iterate over each and if a value is not, cw Null, otherwise cw the value

            // reference types
            Console.WriteLine("string collection");
            List<string> groceries = new() { "Apple", null, "Carrot", "Bround Beef", null, "", "  ", string.Empty };
            foreach (var item in groceries)
            {
                if (item == null)
                {
                    Console.WriteLine("Null");
                }
                else
                {
                    Console.WriteLine(item);
                }
            }

            // value types
            Console.WriteLine("\nint? collection");
            var numbers = new List<int?> { 1, 2, 3, null, 5, null, 7, null, null, 10 };
            foreach (var number in numbers)
            {
                if (number.HasValue) // (number != null) would work as well
                {
                    Console.WriteLine(number);
                }
                else
                {
                    Console.WriteLine("Null");
                }
            }

            // strings also have another very useful method for checking is a string is null or empty or just whitespace
            // notice in out previous string collection loop, there were some empty spaces? These static methods help us with those
            Console.WriteLine("\nstring static methods IsNullOrEmpty and IsNullOrWhiteSpace");
            foreach (var str in groceries)
            {
                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Null or Empty");
                }
                else if (string.IsNullOrWhiteSpace(str))
                {
                    Console.WriteLine("Null or Whitespace");
                }
                else
                {
                    Console.WriteLine(str);
                }
            }

            Console.WriteLine("\nobjects collection");
            var objects = new List<object> { "", 1, null, string.Empty  };
            foreach (var obj in objects)
            {
                if (obj == null)
                {
                    Console.WriteLine("Null");
                }
                else
                {
                    Console.WriteLine(obj);
                }
            }
        }
    }
}
