using SimpleMathQuizClass.Data;
using SimpleMathQuizClass.Interfaces;

namespace SimpleMathQuizClass.IO
{
    /// <summary>
    /// Manages ICanLogRead for MathQueizService
    /// </summary>
    class MathQuizMessagingService
    {
        private ICanLogRead _logger;
        public MathQuizMessagingService(ICanLogRead logger)
        {
            _logger = logger;
        }

        public void WriteQuestion(Question question)
        {
            _logger.Log($"{question.First} {Question.GetMathOperatorAsString(question.MathOperator)} {question.Second}?");
        }
        public void Report(int correct, int total)
        {
            _logger.Log($"You got {correct}/{total} correct!");
        }
        public int TryGetAnswer(Question quesiton)
        {
            var successParse = int.TryParse(_logger.GetInputString(), out var userAsnwer);
            while (!successParse)
            {
                _logger.Log($"{userAsnwer} is an invalid answer. Please try again...");
                WriteQuestion(quesiton);
                successParse = int.TryParse(_logger.GetInputString(), out userAsnwer);
            }

            return userAsnwer;
        }
        public void FeedBack(string message)
        {
            _logger.Log(message);
        }
        public bool ConfirmRetry(char confirmChar)
        {
            _logger.Log("Do you wish to try again?");
            return _logger.GetInputChar(true) == confirmChar;
        }
    }
}