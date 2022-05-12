using SimpleMathQuizClass.Data;
using SimpleMathQuizClass.Interfaces;
using SimpleMathQuizClass.IO;
using System;
using System.Linq;

namespace SimpleMathQuizClass
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Random random = new();
                ICanLogRead loggerReader = new Logger();
                MathQuizMessagingService mathQuizMessagingService = new MathQuizMessagingService(loggerReader);

                var questions = Enumerable.Range(1, 10).Select(e => Question.GenerateRandomQuestion(random));
                new MathQuizService(mathQuizMessagingService)
                    .AddQuestions(questions)
                    .Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong :( {ex.Message}");
                throw;
            }
        }
    }
}
