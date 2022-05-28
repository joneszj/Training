try
{
    string userInputItem;
    var exit = false;
    List<string> toDoList = new();
    Console.WriteLine("This is your ToDo List!");
    do
    {
        Console.WriteLine("\nTo add a new item, press 'a'.\nTo remove an item, press 'r'.\nTo exit, press 'x'.");
        var userInputKey = Console.ReadKey(true).Key;
        switch (userInputKey)
        {
            case ConsoleKey.A:
                do
                {
                    Console.Write("\nPlease enter the item you would like to add: ");
                    userInputItem = Console.ReadLine() ?? string.Empty;
                } while (string.IsNullOrWhiteSpace(userInputItem));

                // Add the item to the list
                toDoList.Add(userInputItem);
                break;
            case ConsoleKey.R:
                do
                {
                    Console.Write("\nPlease enter the item, or index of the item you would like to remove: ");
                    userInputItem = Console.ReadLine() ?? string.Empty;
                } while (string.IsNullOrWhiteSpace(userInputItem));

                var isIndex = int.TryParse(userInputItem, out var index);
                if (isIndex)
                {
                    if (index < 1 || index > toDoList.Count)
                    {
                        Console.WriteLine($"{index + 1} is invalid");
                        break;
                    }
                    toDoList.RemoveAt(index - 1);
                }
                else
                {
                    var isRemoved = toDoList.Remove(userInputItem);
                    if (!isRemoved)
                    {
                        Console.WriteLine($"\n{userInputItem} was not found in the ToDo List.");
                    }
                }
                break;
            case ConsoleKey.X:
                Console.WriteLine("\nExiting...");
                exit = true;
                break;
            default:
                Console.WriteLine($"\n{userInputKey} is not a valid selection.");
                break;
        }

        Console.WriteLine($"ToDo List total: {toDoList.Count}\n");
        for (int i = 0; i < toDoList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {toDoList[i]}");
        }
    } while (!exit);
}
catch (Exception ex)
{
    Console.WriteLine($"Something went wrong :( {ex.Message}");
    throw;
}
