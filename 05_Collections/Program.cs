using System;
using System.Collections.Generic;

namespace _05_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Collections is a term I use to describe any data structute that may have multiple independant values
            // But others user other terms: series, sequence, etc.
            // There are many forms of collections in .Net, but here we will cover just a few

            #region Arrays
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
            // Arrays are data structures where you can store many values inside of it
            // The Array class is abstract, meaning you cannot create an instance of the Array type (ex new Array())
            // Arrays require a type declaration, which indicates the type of the values in the array
            // Like variables, you cannot mix ot change the type once it is declared
            var myStringArray = new string[] { };
            // ^ is a empty string array. You may also create one like this
            string[] myOtherStringArray = new string[] { };
            // You can also initialize an array
            var myInitializedArray = new int[] { 0, 1, 2, 3, 5, 8, 13, 21 };
            // myInitializedArray has the values 0, 1, 2, 3, 5, 8, 13, 21

            // Arrays are 0 index, meaning the first position of the array is 0, the next is 1, next is 2, and so on.
            // We can read values from an array using it index
            // We simply pass the index as an int into the array indexer syntax ([])
            var intPoition4 = myInitializedArray[4];
            // intPoition4 = index position 4 is value 5, so intPoition2 is 5

            // Arrays are fixed in size, so you cannot increase nor decrease the number of items in the array
            // Arrays have instances and static behavior/state
            // Very common property on array instances is .Length, with will return the number of items in the array
            // .Length is not 0 based. A length of 0 means there are no items in the array
            var length = myInitializedArray.Length;
            Console.WriteLine($"myInitializedArray.Length: {myInitializedArray.Length}");
            Console.WriteLine($"intPoition4: {intPoition4}");

            // since for loops provide an index, they make iterating over an array trivial
            // left to right, we start at index 0, terminate when i is equal to or greater than out array.Length, after each iteration, increment i by 1
            var groceryList = new string[] { "Carrot", "Water", "Potato", "Chicken" };
            for (int i = 0; i < groceryList.Length; i++)
            {
                Console.WriteLine($"{i}. {groceryList}");
            }

            Console.WriteLine();

            // we can do the same in revers 
            // this will iterate last to first, right to left of our array
            for (int i = groceryList.Length - 1; i >= 0; i--)
            {
                Console.WriteLine($"{i}. {groceryList}");
            }

            // Just because we can't add or remove positions from the array, doesn't mean we can assign existing positions values
            // Example: we can create an int array with 20 index position, but they are not yet filled
            var crazyIntArray = new int[20];
            // Now we can provide values for each index
            for (int i = 0; i < crazyIntArray.Length; i++)
            {
                crazyIntArray[i] = i * i;
                Console.WriteLine(crazyIntArray[i]);
            }

            // We can even reassign those values. We simply caot add or remove indexed positions
            for (int i = 0; i < crazyIntArray.Length; i++)
            {
                crazyIntArray[i] = crazyIntArray[i] * 10;
                Console.WriteLine(crazyIntArray[i]);
            }

            // An array can be single-dimensional, multidimensional or jagged.
            // I have never needed to use multidimensional or jagged arrays, so I will leave those as deep dive topics
            // TODO: consider excersizes on multidimensional or jagged arrays

            // If we ever need to add or remove from an array, we can't. Instead, we would need to create a new array
            // This makes arrays limited in use for many real life scenarios. For a more flexible collection data structure we can use a List

            // Arrays very are common data structures. Example, JS has an array that you can add (push) and remove (pop) on.

            // The Array class has some helpful static methods as well
            // If instead of getting an item by index, we wanted to get an index from an item, we can call Array.IndexOf(array, item)
            var index = Array.IndexOf(groceryList, "Potato");
            Console.WriteLine($"The index position of Potato on groceryList is {index}");

            #endregion

            #region Generic Lists
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections
            // Lists are functionally superior to arrays, but they have an added performance cost. With modern hardware, this performance cost is often safely ignored
            // But it is work noting that if you have really large collections to manipulate, arrays will perform better, especially if the size of the collection is constant

            // A Generic List is a typed collection, so you will need to declare the type
            // The List class is in the System.Generics.Collection namespace, so you will need to reference that in a using statement at the top of the file
            List<string> myStringList = new List<string>();
            // using var
            var myIntList = new List<int>();
            // initializing a List
            var daysOfTheWeek = new List<string> { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            // we can easily add new values to a list
            daysOfTheWeek.Add("Saturday");
            // we can remove easily as well
            daysOfTheWeek.Remove("Monday");
            // sorting is also easy with base data types
            daysOfTheWeek.Sort();

            var months = new List<string> { };
            // We can even add many values to a list at once
            months.AddRange(new string[] { "Jan", "Feb", "Mar", "Apr", "Jun" });
            months.AddRange(new List<string> { "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" });
            // Notice we can add an array, and a list for AddRange, this is because both arrays and lists implement an interface call IEnumerable
            // We will cover interfaces later, but for now, we can say that arrays and lists are collections that implement IEnumberable
            // List has no static members. All state/behavior exists on instances

            #endregion

            #region Dictionaries
            // Dictionaries are simply typed key-value pairs
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            // The left type parameter is the key, the right is the value
            myDictionary.Add("Noon", 12);
            myDictionary.Add("Midnight", 24);

            // You can get a value by passing a key into the Dictionaries indexr
            var item = myDictionary["Noon"];

            // You can find, add, remove, etc. on Dictionaries, but the keys must always be unique
            // Like Lists, Dictionaries have no static methods, only instanced methods

            #endregion

            #region IEnumerable
            // TODO: this will be covered in a later lesson, but these links provide a lot of technical context on various types of collections
            // IEnumerable: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0#remarks
            // ICollection: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1?view=net-6.0#remarks
            // IDictionary: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2?view=net-6.0#remarks
            // IList: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1?view=net-6.0#remarks

            // For a list of all generic collections: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-6.0
            #endregion

            #region ForEach
            // ForEach is by far the most commonly used iteration constuct, and it will work for any IEnumerable type instance
            var statements = new string[] { "hello", "bye bye", "have a nice day", "nice to meet you" };
            // (keyboard foreach tab + tab)
            // foreach (var itemInIteration in collectionToIterate)
            // each item in the collection will automatically be passed into the var declared in the foeach expression
            foreach (var statement in statements)
            {
                Console.WriteLine(statement);
            }

            var questions = new List<string> { "how are you?", "What did you do today?", "how is your family" };
            foreach (var question in questions)
            {
                Console.WriteLine(question);
            }

            foreach (var dictionaryItem in myDictionary)
            {
                Console.WriteLine($"{dictionaryItem.Key} = {dictionaryItem.Value}");
            }

            // ForEach iteration loops are very simple and powerful
            // If you have no need to maintain an index value, ForEach is likely the way to go when iterating on collections

            // This may help you identify which loop fits best in your scenario:
            // If I cannot use the LinQ .ForEach(), I will use the construct ForEach
            // If I need an index, or am concerned about performance, a for/forr may be used
            // If the loop termination is not determined, a while loop can be used
            // If I need the while loop to occur at least once, I will use the doWhile

            // 90%+ of the time, especially in web development, the go to iteation construct is ForEach and the LinQ .ForEach()
            #endregion

            #region Deep Dive
            // Performance considerations: https://stackoverflow.com/questions/365615/in-net-which-loop-runs-faster-for-or-foreach/365658#365658
            #endregion
        }
    }
}
