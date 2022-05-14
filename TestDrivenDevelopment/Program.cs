namespace TestDrivenDevelopment
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Test Driven Development (TDD) is one of the best tool we have to ensure our code works the way we expect
            // Tests a automated, small and repeatable methods that assert results of our functionality

            // Generally, tests follow an Assemble, Act, and Assert pattern
            // Assemble is where we assemble any data or dependency that our test will require
            // Act is performing a method or other functionality
            // Assert is testing if the result of our test is what we expect

            // Also, .net has a separate project type for tests
            // Tests are also provided a test menu to easily run and debug our tests via the Test Explorer

            // Idealy, before we even start writing code, we start with a test
            // Finally, tests generally are concerned with the code we write, we don't bother testing third party or
            // framework provided code

            // From now on, all of the code we write will be tested at minimum, and TDD'd at best
        }

        // ex code we want to test, is referenced in teh Tests project
        // a project reference is required and this class needs to be mad public
        public static int TestAdd(int i, int y)
        {
            return i + y;
        }
    }
}
