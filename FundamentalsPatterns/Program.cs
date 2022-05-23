// patterns I have implemented so far for referrence:

#region exception handling
// wrapping highest execution blocks with try/catch
try
{
    // wrapped code
}
catch (Exception ex)
{
    // some helpful message, or perhaps even logging of what happened
    Console.WriteLine($"Something went wrong :( {ex.Message}");
    throw; // <- thow again to crash the app, or remove throw to allow the code to continue to process
}
#endregion

// the 'auto-rerun' & 'rety' patterns will not be used mcuh, if at all, once we move away from the Console application for user IO
#region auto-rerun
// wrap main application code in a doWhile with a control variable the user can use to terminate the app
bool exit; // <- control variable, bool defaults to false
do
{
    Console.WriteLine("Exit?");
    exit = Console.ReadKey().Key == ConsoleKey.Y;
} while (!exit);
#endregion

#region simple retry
// use a doWhile loop to force the user to retry input if the current passed input is invalid
bool isValid;
do
{
    Console.Write("Please enter your name: ");
    var userInputMustBeValid = Console.ReadLine();
    isValid = string.IsNullOrWhiteSpace(userInputMustBeValid);
} while (!isValid);
#endregion

#region slightly more complex retry
// use a while loop when we want to provide slightly different output/validation than the original request
Console.WriteLine("What is 5 + 5?");
var answerAsString = Console.ReadLine();
var isInt = int.TryParse(answerAsString, out var answerAsInt);
while (!isInt)
{
    Console.WriteLine($"{answerAsString} is not an integer. Please try again...");
    Console.WriteLine("What is 5 + 5?");
    answerAsString = Console.ReadLine();
    isInt = int.TryParse(answerAsString, out answerAsInt);
}

if (answerAsInt == 5 + 5)
{
    Console.WriteLine("You are correct!");
}
else
{
    Console.WriteLine($"{answerAsInt} is incorrect. {5 + 5} is the correct answer.");
}

#endregion

#region slightly slightly more complex retry
// same as above, but less repeating of code, but also harder to read
bool isNotAnInt = false;
string answerAsString2 = string.Empty;
do
{
    if (isNotAnInt)
    {
        Console.WriteLine($"{answerAsString2} is not an integer. Please try again...");
    }
    Console.WriteLine("What is 10 + 10?");
    answerAsString2 = Console.ReadLine() ?? string.Empty;
    isNotAnInt = int.TryParse(answerAsString2, out var answerAsInt2);
} while (true);

if (answerAsInt == 10 + 10)
{
    Console.WriteLine("You are correct!");
}
else
{
    Console.WriteLine($"{answerAsInt} is incorrect. {10 + 10} is the correct answer.");
} 
#endregion