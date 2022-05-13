using System;
using System.Collections.Generic;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Collections is a term I use to describe any data structute that may have multiple independant values that can be iterated or enumerated over
            // But others user other terms: series, sequence, etc.
            // There are many forms of collections in .Net, but here we will cover just a few

            // Don't confuse the collection classes in System.Collections vs System.Collections.Generic
            // System.Collections is non-generic, and superceded by the generic classes and interfaces
            // Honestly, System.Collections could be hidden from us (or removed altogether), but is left available for backwards compatability from C# 1.0

            #region Collections vs Collections.Generic
            // https://docs.microsoft.com/en-us/dotnet/api/system.collections?view=net-6.0
            // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-6.0
            #endregion

            #region Typed Arrays (or just arrays)
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/

            // Arrays are data structures where you can store many values inside of it
            // The Array class is abstract, meaning you cannot create an instance of the Array type (ex new Array())
            // Type arrays are created using the array indexer syntax type[length] where type is the tyle of the values in teh array and length is the size of the array
            var myStringArray = new string[10];

            // Arrays are fixed in size, they cannot increase or decrease their indexed positions
            // myStringArray can only have 10 values
            // Each index will have a value or be null, but once set, the array size is fixed, and cannot change

            // Alternatively, you can create an array with values set in the arrat
            var myStringArray2 = new string[2] { "Hello", "Goodbye" };

            // Arrays created this way do not need the length set, as the compiler will do this for you
            var myIntArray = new int[] { 1, 2, 3, 4, 5 };

            // Typed arrays require a type declaration, which indicates the type of the values in the array
            // Like variables, you cannot mix not change the type once it is declared

            // Arrays are 0 indexed, meaning the first position of the array is 0, the next is 1, next is 2, and so on.
            // We can read values from an array using it index
            // We simply pass the index as an int into the array indexer syntax ([])
            var intIndex4 = myIntArray[4];
            // index position 4 is value 5, so intPoition5 is 5

            // Arrays have instances and static behavior/state
            // Very common property on array instances is .Length, with will return the number of indexes in the array
            // .Length is not 0 based. A length of 0 means there are no indexes in the array
            var length = myIntArray.Length;
            Console.WriteLine($"myInitializedArray.Length: {myIntArray.Length}");
            Console.WriteLine($"intIndex4 hav value {intIndex4}");

            // A static member is .Sort
            Array.Sort(myIntArray);

            // The Array class has some other helpful static methods as well
            // If instead of getting an item by index, we wanted to get an index from an item, we can call Array.IndexOf(array, item)
            var index = Array.IndexOf(myStringArray2, "Goodbye");
            Console.WriteLine($"The index position of Goodbye on myStringArray2 is {index}");

            // since for loops provide an index, they make iterating over an array trivial
            // left to right, we start at index 0, terminate when i is equal to or greater than out array.Length, after each iteration, increment i by 1
            var groceryList = new string[] { "Carrot", "Water", "Potato", "Chicken" };
            Console.WriteLine("groceryList");
            for (int i = 0; i < groceryList.Length; i++)
            {
                Console.WriteLine($"{i}. {groceryList}");
            }

            // we can do the same in reverse
            // this will iterate last to first, right to left of our array
            Console.WriteLine("\ngroceryList reversed");
            for (int i = groceryList.Length - 1; i >= 0; i--)
            {
                Console.WriteLine($"{i}. {groceryList}");
            }

            // Just because we can't add or remove indexes from the array, doesn't mean we can assign existing positions new values
            // Example: we can create an int array with 20 index position, but they are not yet filled
            // So, an array is mutable but fixed
            var crazyIntArray = new int[20];
            // Now we can provide values for each index
            for (int i = 0; i < crazyIntArray.Length; i++)
            {
                crazyIntArray[i] = i * i;
                Console.WriteLine(crazyIntArray[i]);
            }

            // We can even reassign those values. We simply cant add or remove indexes
            for (int i = 0; i < crazyIntArray.Length; i++)
            {
                crazyIntArray[i] = crazyIntArray[i] * 10;
                Console.WriteLine(crazyIntArray[i]);
            }

            // An array can be single-dimensional, multidimensional or jagged.
            // I have never needed to use multidimensional or jagged arrays, so I will leave those as deep dive topics
            // TODO: consider excersizes on multidimensional or jagged arrays

            // If we ever need to add or remove from an array, we can't. Instead, we would need to create a new array
            // This makes arrays limited in use for many real life scenarios.
            // For a more flexible collection data structure we can use a List which has built in Add/Remove/Clear etc.

            // arrays implement the IEnumerable interface as well, so we can use the forEach enumeration construct
            // we cover enumeration and forEach below
            foreach (var theItem in crazyIntArray)
            {
                Console.WriteLine(theItem);
            }

            // Arrays very are common data structures. Example, JS has an array that you can add (push) and remove (pop) on.
            // All collection types are build with arrays
            #endregion

            #region IEnumerable, Enumeration and ForEach
            // IEnumerable is an interface (we will cover interfaces later)
            // All it signifies is that whatever implements (or is) an IEnumerable, we can enumerate on it
            // To enumerate is to iterate over a collection of things, one by one

            #region ForEach
            // ForEach is an enumeration construct, and it will work for any IEnumerable type instance
            // While iteration and enumeration are similar concepts, enumeration can only occur on a collection of things while an iteration is universal
            // ex: while/doWhile/for loops do not require a collection to iterate, or forEach does

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

            // ForEach iteration loops are very simple and powerful
            // If you have no need to maintain an index value, ForEach is likely the way to go when iterating on collections

            // This may help you identify which loop fits best in your scenario:
            // If I have a enumerable collection, I use the LinQ .ForEach(), or the construct ForEach
            // If I need an index, or am concerned about performance, a for/forr may be used
            // If the loop termination is not determined, a while loop can be used
            // If I need the while loop to occur at least once, I will use the doWhile

            // Most of the time, especially in web development, the go to iteation construct is ForEach and the LinQ .ForEach()
            // As wed development typically is handling enumerable types pass from/to the server

            // Whenever working with an IEnumerable, try to use the foreach enumeration instead of the for iteration
            // as to use the for, you will need to reference the .Count() on the IEnumerable, which will count every item each iteration
            // Or, convert the IEnumerable to an array before doing the for loop if you need to
            #endregion

            #region Iterators
            // https://docs.microsoft.com/en-us/dotnet/csharp/iterators
            #endregion

            #endregion

            #region System.Collection.Generic
            // For a list of all generic collections: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-6.0

            #region Generic Lists
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections
            // Lists are functionally superior to arrays, but they have an added performance cost. With modern hardware, this performance cost is often safely ignored
            // But it is worth noting that if you have really large collections to manipulate, arrays will perform better, especially if the size of the collection is constant
            // It is also worth renoting that Lists and all collections use arrays under the hood

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
            // Notice we can add an array, or a list for AddRange, this is because both arrays and lists implement an interface call IEnumerable
            // We will cover interfaces later, but for now, we can say that arrays and lists are collections that implement IEnumberable
            // List has no static members. All state/behavior exists on instances of List
            #endregion

            #region Generic Dictionaries
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

            // there are other forms of generic collections. see here for a list: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-6.0

            #region Generic Collection Interfaces
            // IEnumerable<T>: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0#remarks
            // ICollection<T>: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1?view=net-6.0#remarks
            // IDictionary<T>: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2?view=net-6.0#remarks
            // IList<T>: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1?view=net-6.0#remarks
            // https://medium.com/developers-arena/ienumerable-vs-icollection-vs-ilist-vs-iqueryable-in-c-2101351453db

            // ICollection<T> is an extension of IEnumerable<T> that provides Add/Remove/Insert/Clear/Contains/CopyTo
            // Because of this, any type that implements ICollection<T> will have an Add/Remove etc., even typed arrays (via compiler trickery), though they will throw if called 
            // All System.Collection.Generic classes implement ICollection<T>
            // IList<T> extends ICollection<T> with Instert/RemoveAt and indexing
            // IDictionary<T> extends ICollection<T> with Add(TKey, TValue), ContainsKey(TKey), TryGetValue(TKey, TValue)

            // Rule of thumb:
            // If you are in control of the type, and do not need more than simple enumeration on a mutable, fixed-size collection, an array is adequate
            // If you need any functionality beyond that, it is best to avoid arrays and to use a construct from the System.Collections.Generic namespace
            #endregion
            #endregion

            #region Deep Dive
            // Performance considerations: https://stackoverflow.com/questions/365615/in-net-which-loop-runs-faster-for-or-foreach/365658#365658
            #endregion

            #region Array Regrets
            // see 06_Collections
            #endregion
        }
    }
}
