using System;
using System.Collections;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is very technical, and not super relavent for modern C# development
            // Noone uses the non-generic collections anymore (System.Collections namespace)
            // But to understand generic collections (System.Collections.Generic namespace) we need to understand the non-generic collections

            // Collections is a term I use to describe any data structute that may have multiple independant values that can be iterated or enumerated over
            // But others user other terms: series, sequence, etc.
            // There are many forms of collections in .Net, but here we will cover just a few

            #region Arrays
            // The Array structure is strange. It implements the non-generic and generic implementations of IEnumerable, ICollection, and IList
            // It injects IEnumerable<T>, ICollection<T>, and IList<T> at build-time
            // https://stackoverflow.com/questions/14324987/why-isnt-array-a-generic-type

            // The Array class (System namespace) is akin to the String class (System namespace) for string, but the Array class is abstract, and cannot be derived
            // Nor does it have a public default constructor or any other public constructor
            // https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0#remarks
            // The Array class is the base class for language implementations that support arrays.
            // However, only the system and compilers can derive explicitly from the Array class. Users should employ the array constructs provided by the language.

            // not allowed as Array is has no public constructors
            // Array myArray = new Array();

            // As a result, if you want a non-generic array, you must use the Array.CreateInstance method
            // https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist?view=net-6.0#remarks

            var objectArray = Array.CreateInstance(typeof(object), 10);

            // because objectArray is a non-generic object Array, nothing prevents us from adding non-ints or other types to this Array
            // this will compile and not throw at runtime
            objectArray.SetValue("123", 0);
            objectArray.SetValue(true, 1);

            // we can however restrict the types of values an Array can accept, but this is not checked at build-time
            var intArray = Array.CreateInstance(typeof(int), 10);

            // Non-generic arrays are not build-time type safe. this will build and pass compile checks, but will fail at runtime
            try
            {
                intArray.SetValue("123", 0);
                intArray.SetValue(true, 1);
            }
            catch (Exception) { }

            // Arrays may be accessed index (via GetValue), cannot use the typical [index] syntax
            for (int i = 0; i < objectArray.Length; i++)
            {
                Console.WriteLine($"{i}. {objectArray.GetValue(i)}");
            }

            // Array index values are mutable
            var stringArray = Array.CreateInstance(typeof(string), 10);
            for (int i = 0; i < stringArray.Length; i++)
            {
                stringArray.SetValue("changed " + i, i);
                Console.WriteLine(stringArray.GetValue(i));
            }

            // All arrays implement IEnumerable, so we can enumerate as well
            foreach (var item in stringArray)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region System.Collections
            // System.Collections provides classes that use Array instances likely using the Array.CreateInstance(typeof(object), ~)
            // where ~ may be the istantiated values length if provided

            // ArrayList is an abstraction that allows us to add/remove from an Array
            // ArrayList is heterogeneous, meaning the values types may not be consistent
            ArrayList nonGenericArray = new ArrayList() { "word", 'l', 1, 1.5, null };
            // But all that is happening is that it is creating a new Array and replacing the old Array
            nonGenericArray.Add("new item!");

            Queue nonGenericQueue = new Queue();
            nonGenericQueue.Enqueue("word");
            nonGenericQueue.Enqueue('o');
            nonGenericQueue.Enqueue(1);
            nonGenericQueue.Enqueue(1.5);
            nonGenericQueue.Enqueue(null);

            Stack nonGenericStack = new Stack();
            nonGenericStack.Push("word");
            nonGenericStack.Push('o');
            nonGenericStack.Push(1);
            nonGenericStack.Push(1.5);
            nonGenericStack.Push(null);

            Hashtable nonGenericHashTable = new Hashtable();
            nonGenericHashTable.Add(0, "word");
            nonGenericHashTable.Add(1, 'o');
            nonGenericHashTable.Add(2, 1);
            nonGenericHashTable.Add(3, 1.5);
            nonGenericHashTable.Add(4, null);

            // You can see the issue with using non-generics: there is no garuntee that the values in the collections are of any type 
            // You have no compile time type checking
            #endregion

            #region Array Regrets
            // I think that when C# 1.0 was designed, there was the idea that an IList could be fixed in size, or could expand/contract but ICollection could not
            // Array implements IList, there therefor non-generic Arrays of IList have the IsFixedSize property as well as Add/Remove etc. nut will throw on Array as it is fixed in size
            var isFixed = objectArray.IsFixedSize;
            // If the IList type IsFixedSize == true, you could anticipate it and code accordingly, so you could check IsFixedSize before calling Add/Remove to prevent a throw
            // This makes sense, though I think it would have been better to separate the interface into an IFixedList and an IList
            // But is IFixedList was a thing, we may have had multipe array types... As Lists use arrays under their implementation
            // https://stackoverflow.com/questions/16387286/is-listt-really-an-undercover-array-in-c

            // When C# implemented generics in 2.0, it does some compiler trickery to inject the generic IList<T>, as well as ICollection<T> and IEnumerable<T>
            // It is unfortunate that the non-generic and generic collection interfaces share the same name as they have different contracts

            // IList https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0#constructors
            // has IsFixedSize, IsReadOnly, Add
            // IList<T> https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist?view=net-6.0#properties
            // does not have IsFixedSize, IsReadOnly, but does have Add (and many other methods)
            // we can only access IsFixedSize, IsReadOnly by accessing the IList on IList<T>
            // I assume the IList<T>.Add hides the IList.Add

            // https://docs.microsoft.com/en-us/dotnet/api/system.collections.icollection?view=net-6.0#properties
            // Does not have Add, just has a CopyTo and GetEnumerator
            // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1?view=net-6.0#properties
            // Does have Add/Remove/Clear/Contains as well as CopyTo and GetEnumerator

            // IList<T> does not have IsFixedSize, but because all IList<T> also implements IList, we can do (arr as IList).IsFixedSize to get this property
            // or we can cast it ((System.Collections.IList)arr).IsFixedSize

            // Breakdown:
            // ICollection is simply an extension of IEnumerable that provides copy and synchronization features
            // It does not have Add/Remove functionality
            // All System.Collection classes implement ICollection
            // IList extend ICollection with fixed/readonly checking as well as Add/Remove/Insert/Clear functionality and access via indexing
            // IDictionary extend ICollection with fixed/readonly checking, Add/Remove functionality around key/value pair types of DictionaryEntry

            // ICollection<T> is an extension of IEnumerable<T> that provides Add/Remove/Insert/Clear/Contains/CopyTo
            // Because of this, any type that implements ICollection<T> will have an Add/Remove etc., even typed arrays, though they will throw if called (via compiler trickery)
            // All System.Collection.Generic classes implement ICollection<T>
            // IList<T> extends ICollection<T> with Instert/RemoveAt and indexing
            // IDictionary<T> extends ICollection<T> with Add(TKey, TValue), ContainsKey(TKey), TryGetValue(TKey, TValue)

            // Rule of thumb:
            // If you are in control of the type, and do not need more than simple enumeration on a mutable, fixed-size collection, an array is adequate
            // If you need any functionality beyond that, it is best to avoid arrays and to use a construct from the System.Collections.Generic namespace
            #endregion
        }
    }
}
