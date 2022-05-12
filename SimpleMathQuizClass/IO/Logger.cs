using SimpleMathQuizClass.Interfaces;
using System;

namespace SimpleMathQuizClass.IO
{
    /// <summary>
    /// Basic IO using the Console
    /// Implements ICanLogRead
    /// </summary>
    class Logger : ICanLogRead
    {
        public string GetInputString()
        {
            return Console.ReadLine();
        }

        public char GetInputChar(bool asLower)
        {
            if (asLower)
            {
                return char.ToLower(Console.ReadKey(true).KeyChar);
            }
            return Console.ReadKey(true).KeyChar;
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
