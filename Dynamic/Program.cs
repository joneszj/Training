using System;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simply ignores compile-time checking and will be receive its type at runtime

            // Var vs Dynamic
            // var implies the variable type by what it is assigned by, thus you have type safety
            // dynamic skips compile-time and runtime type checks all together

            dynamic dynNumber = 100;
            Console.WriteLine(dynNumber);

            dynNumber = "100 as string";
            Console.WriteLine(dynNumber);

            dynNumber = 99;
            Console.WriteLine(dynNumber);

            Sum(new { number = 15 }, 10, dynNumber);

            var nullNotAnObject = !(null is object);
            if (nullNotAnObject)
            {
                Console.WriteLine("null is not an object");
            }


            int Sum(dynamic i, dynamic y, int z)
            {
                if (i is string)
                {
                    Console.WriteLine("i is string");
                }
                return i.number + y + z;
            }

            // This can be useful, but you open yourself to run-time errors
            Sum("this has no number property", null, 0);
        }
    }
}
