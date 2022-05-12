using SimpleMathQuizClass.Data;
using SimpleMathQuizClass.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMathQuizClass
{
    /// <summary>
    /// Faciliatates the quiz questions and score tracking
    /// </summary>
    class MathQuizService
    {
        #region ctor & privates
        private static readonly char _yes = 'y';
        private IEnumerable<Question> _questions;
        private int _correctAnswers;
        private MathQuizMessagingService _messenger;

        public MathQuizService(MathQuizMessagingService messenger)
        {
            _messenger = messenger;
        }
        public MathQuizService(MathQuizMessagingService messenger, IEnumerable<Question> questions) : this(messenger)
        {
            _questions = questions;
        } 
        #endregion
        public MathQuizService AddQuestions(IEnumerable<Question> questions)
        {
            if (questions == null)
            {
                throw new ArgumentNullException(nameof(questions));
            }
            _questions = questions;
            return this;
        }
        public void Run()
        {
            do
            {
                RunQuiz();
            } while (_messenger.ConfirmRetry(_yes));
        }
        #region helpers
        private void RunQuiz()
        {
            _correctAnswers = 0;
            foreach (var quesiton in _questions)
            {
                RunQuestion(quesiton);
            }
            _messenger.Report(_correctAnswers, _questions.Count());
        }
        private void RunQuestion(Question quesiton)
        {
            _messenger.WriteQuestion(quesiton);
            var correctAnswer = quesiton.GetAnswer();
            if (_messenger.TryGetAnswer(quesiton) == correctAnswer)
            {
                _messenger.FeedBack("Correct!");
                _correctAnswers++;
            }
            else
            {
                _messenger.FeedBack($"Incorrect! The correct answer is {correctAnswer}.");
            }
        }
        #endregion
    }
}
