using System;

namespace SimpleMathQuizClass.Data
{
    class Question
    {
        public Question(int first, int second, MathOperator mathOperator)
        {
            First = first;
            Second = second;
            MathOperator = mathOperator;
        }
        public int First { get; set; }
        public int Second { get; set; }
        public MathOperator MathOperator { get; set; }
        public static Question GenerateRandomQuestion(Random random)
        {
            var first = random.Next(1, 10);
            var second = random.Next(1, 10);
            var mathOperator = (MathOperator)random.Next(0, Enum.GetNames(typeof(MathOperator)).Length);
            // ensure non-floating point answers
            if (mathOperator == MathOperator.Divide)
            {
                while (first % second != 0)
                {
                    first = random.Next(1, 10);
                    second = random.Next(1, 10);
                }
            }
            return new Question(first, second, mathOperator);
        }

        public static string GetMathOperatorAsString(MathOperator mathOperator)
        {
            return mathOperator switch
            {
                MathOperator.Plus => "+",
                MathOperator.Subtract => "-",
                MathOperator.Multiply => "*",
                MathOperator.Divide => "/",
                _ => throw new InvalidOperationException(),
            };
        }
        public int GetAnswer()
        {
            return MathOperator switch
            {
                MathOperator.Plus => First + Second,
                MathOperator.Subtract => First - Second,
                MathOperator.Multiply => First * Second,
                MathOperator.Divide => First / Second,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
