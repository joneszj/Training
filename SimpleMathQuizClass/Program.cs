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
                Logger loggerReader = new();
                MathQuizMessagingService mathQuizMessagingService = new(loggerReader);

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
