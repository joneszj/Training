using System;

namespace SimpleCalc
{
    class Program
    {
        /// <summary>
        /// Areas of focus: arithmatic, branching, comparison, iteration, parsing, variables, nullable types
        /// Secondary: comments, enums, interpolation, readability, static classes/methods
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("A simple calculater! Enter a number, then an operator (+-*/).");
            float? result = null;
            do
            {
                // get first number: use previous result or get input from user
                float number1;
                if (result.HasValue) number1 = result.Value;
                else
                {
                    bool isFloat1;
                    do
                    {
                        isFloat1 = float.TryParse(Console.ReadLine(), out number1);
                        if (!isFloat1) Console.WriteLine("Invalid number. Try again.");
                    } while (isFloat1);
                }

                // get operator
                var operatorKey = Console.ReadKey().Key;
                Console.WriteLine();

                // get second number
                bool isFloat2;
                float number2;
                do
                {
                    isFloat2 = float.TryParse(Console.ReadLine(), out number2);
                    if (!isFloat2) Console.WriteLine("Invalid number. Try again.");
                } while (isFloat2);

                // calculate
                switch (operatorKey)
                {
                    case ConsoleKey.OemPlus:
                    case ConsoleKey.Add:
                        result = number1 + number2;
                        break;
                    case ConsoleKey.OemMinus:
                    case ConsoleKey.Subtract:
                        result = number1 - number2;
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.Multiply:
                        result = number1 * number2;
                        break;
                    case ConsoleKey.Oem2:
                    case ConsoleKey.Divide:
                        result = number1 / number2;
                        break;
                    default:
                        Console.WriteLine($"Invalid operator {operatorKey}. Current value is {result}");
                        break;
                }

                // output result
                Console.WriteLine(result);
            } while (true);
        }
    }
}
