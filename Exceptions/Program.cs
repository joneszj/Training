using System;

namespace Exceptions
{
    class Program
    {
        /// <summary>
        /// Areas of Focus: exceptions, exception handling
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region Exceptions
            Console.WriteLine("Hello World! Lets explore exceptions");
            // an exception is an unexpected error that occurs in your application
            // we can try/catch exceptions to prevent the application from stopping or log the exception etc.
            // in general, exceptions should not be used in place of validation.
            // Excpetions are meant to be unexpected. Validation errors should be managed by engineers (using tools such as TryParse)
            // Exception handling gives us a means of catch exceptions, and gracefully handling them.
            // So, instead of an application crash, we can let the user know that something went wrong, log our exceptions, etc.

            // numbers cannot be divided by 0, if we try to, an exception will be thrown (DivideByZeroException)
            // (keyboard try + tab + tab)
            try
            {
                var number = 10;
                var exception = number / 0;
            }
            catch (Exception ex)
            {
                // the variable ex here is an instance of Exception (we can name it whatever we like. It has properties such as Message, and InnerException
                Console.WriteLine(ex.Message);
                // throw; // throw, throws the exception and stops our application. We can comment it out or remove it to allow the application to continue
            }

            try
            {
                // we can throw instances of exceptions .net provides us
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                // throw;
            }

            try
            {
                // we can even use the basic exception class constructor and pass our own message
                // the constructor is the () after the class name, we will cover these in detail later
                throw new Exception("I made this.");
            }
            catch (Exception)
            {
                // throw;
            }
            #endregion

            #region Validation vs Exception Handling
            // A
            try
            {
                // exceptions should not be used to branch our code
                // they really should be used for handling the exception only
                var number = 10;
                var exception = number / 0;
            }
            catch (Exception)
            {
                // this is bad... exceptions are expensive to create.
                // instead of using expection handling try/catch logic, we should use validation instead (see B)
                var number = 10;
                var exception = number / 1;
            }

            // B
            try
            {
                var number1 = 10;
                var number2 = 0;
                if (number1 > 0 && number2 > 0)
                {
                    var result = number1 / number2;
                }
                else
                {
                    // we know number1 or number2 is 0 so we can do something about it such as ask the user for a new number
                    Console.WriteLine("0 is not a valid number");
                }
            }
            catch (Exception ex)
            {
                // DivideByZeroException will not be thrown, so this try/catch will function to catch anything else that could go wrong
                Console.WriteLine($"Uh Oh! Something went wrong! {ex.Message}");
                throw; // we can allow our expception to throw
                // anything that called our code will also throw the exception as well unless it is wrapped in a try/catch
                // because this is the 'top' of our application, the exception throw will be uncaught and the application will crash/close
            }

            // finally, exceptions in general should be closest to the output of your application
            // the deeper exception handling is, the harder your code is to maintain and your code become prone to try/catch logic 'code smell'
            #endregion
        }
    }
}
