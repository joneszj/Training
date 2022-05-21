using System;

namespace SimpleMathQuiz
{
    class Program
    {
        /// <summary>
        /// Areas of focus: arrays, comparison, exception handling, iteration, variables
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Take this simple math quiz.\nA count of questions you anwer correctly will be presented at the end.");
            try
            {
                bool again = true;
                do
                {
                    var questions = new string[] { "5 + 5?", "10 + 10?", "10 / 1", "20 * 4", "10 * 13" };
                    var answers = new int[] { 5 + 5, 10 + 10, 10 / 1, 20 * 4, 10 * 13 };
                    int correct = 0;
                    for (int i = 0; i < questions.Length; i++)
                    {
                        Console.WriteLine(questions[i]);
                        var successParse = int.TryParse(Console.ReadLine(), out var userAsnwer);
                        while (!successParse)
                        {
                            Console.WriteLine($"{userAsnwer} is an invalid answer. Please try again...");
                            Console.WriteLine(questions[i]);
                            successParse = int.TryParse(Console.ReadLine(), out userAsnwer);
                        }
                        if (userAsnwer == answers[i]) correct++;
                    }
                    Console.WriteLine($"You got {correct}/{questions.Length} correct!");
                    Console.WriteLine("Would you like to try again?");
                    again = Console.ReadKey().Key == ConsoleKey.Y;
                } while (again);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong :( {ex.Message}");
                throw;
            }
        }
    }
}
