using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQInDepth
{
    class Program
    {
        static void Main(string[] args)
        {
            // Now that we have an understanding of interfaces, delegates, and generics, we can revisit and really understand LinQ
            // The only other topics we need to discuss is the yield statement (https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/yield)
            // And Extension Methods (https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)

            #region Yield
            // yield will return to the calling iteration a single instance of a collection, while maintaining the state of the iteration
            // when the iteration continues, yield will remember where it left off and repeat
            // it maintains a state machine that manages the iteration state without needing to construct a separate class to maintain this state

            // for example, lets suppose we have a collection of ints that we want to square each of them and return the squared results in a new collection
            var ints = new int[] { 1, 2, 3, 4, 5, 6 };
            var squares = new int[ints.Length];
            for (int i = 0; i < ints.Length - 1; i++)
            {
                squares[i] = ints[i] * ints[i];
            }
            // notice that we have to maintain our own squares array

            // using yield
            // we can construct an iteration context that yields items from a collection
            IEnumerable<int> square(IEnumerable<int> ints)
            {
                foreach (var number in ints)
                {
                    yield return number * number;
                }
            };

            var yieldedSquares = square(ints);
            // this example is trivial but demonstrates how to implement yield, lets dive into the why
            // source: https://stackoverflow.com/questions/410026/proper-use-of-yield-return
            // lets imagine we have a really large colection that we need to perform expensive operations on each item
            var largeCollection = Enumerable.Range(0, 50);
            foreach (var item in largeCollection)
            {
                // some expensive operation
                // in this use case, the entire largeCollection must complete and return before we can begin operating against it
            }

            // now lets use the yield keyword. YieldRange, accepts a start and end int
            IEnumerable<int> YieldRange(int start, int end)
            {
                for (int i = start; i < end; i++)
                {
                    yield return i;
                }
            }

            foreach (var item in YieldRange(0, 50))
            {
                // this loop will run for each yielded item, even though the YieldRange is mid operation
            }
            #endregion

            #region Yield with Delegates
            // instead of having the yielded item implementation iterated outside the YieldRange, we can insteac pass the implementation as a delegate
            IEnumerable<int> YieldRangeDelegate(int start, int end, PerformCalculation performCalculation)
            {
                for (int i = start; i < end; i++)
                {
                    yield return performCalculation.Invoke(10);
                }
            }

            PerformCalculation myDelegate = (int i) => i * i;
            var completed = YieldRangeDelegate(0, 50, myDelegate);
            // now, are the YieldRangeDelegate iterates, it will run our delegate for each yield
            // the value yield is that we can work on items in a collection, without having to wait for the entire collection for finish populating
            // you can think of calling an api or database that yields each result for us to work on. Instead of waiting for the entire set,
            // we can work on each while it set is iterating/generating new results. Streams are analogous here as well
            // the delegate simply allows the caller to determine the implementation

            // as long as the signature and return type of our method is valid (type-safe), we can reuse out yield expression without creating a new expression
            // for every possible implementaiton method needed, nor do we need to perform som strategy pattern. 
            // Again, why depend on an interface when we can have the callee determine the implementation
            var completed2 = YieldRangeDelegate(100, 1000, (int i) => i * 100);

            // Func and Action allow us to accept a delegate, without needing to create one
            // Func requires a return type, Action cannot have a return type
            IEnumerable<int> YieldRangeFunc(int start, int end, Func<int, int> performCalculation)
            {
                // becareful of closures, i here is the same name passed from the callee, so it will be the same value
                for (int i = start; i < end; i++)
                {
                    yield return performCalculation.Invoke(10);
                }
            }
            var completed3 = YieldRangeFunc(100, 1000, (int i) => i * 100);

            // RAM
            // If you are working with large collection operations, yield can save RAM. Instead of having the maintain multiple collections per collection operation
            // yield will allow you to instead iterate of the collection just once regardless of any subsequent or nestsed yields.
            // This is essentially what LinQ does
            #endregion

            // LinQ In Depth
            // Now we should have an idea of what LinQ is doing. LinQ is a set of generic extension methods on collection types
            // IEnumerable, IQueryable, etc.
            // The extension methods require a delegate Func<T, TResult> and yields the results of the delegate
            // T is the generic type to be operated on, TResult is the generic return type
            // In the case of IQueriable, the items are not yielded until the collection is projected to an IEnumerable (.ToList for example)

            Enumerable.Range(1, 10).Select(e =>
            {
                Console.WriteLine("***start");
                Console.WriteLine("select: 1 value:" + e);
                return e;
            }).Select(e =>
            {
                Console.WriteLine("select: 2 value:" + e);
                return e;
            }).Where(e => e % 2 == 0)
            .Select(e =>
            {
                Console.WriteLine("even" + e);
                return e;
            }).Select((e, i) =>
            {
                Console.WriteLine("select: 3 value:" + e);
                return e;
            }).ToList();
            // the above will not work in Linq-to-Entities as the lambda expression cannot be converted into SQL for the SQL provider
            // but I suspect the same flow would occur except that the data source is called once
            // to the db call happens (deferred execution), setting the IEnumerable source, and then the iteration yielding happens
            // https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/query-execution
            // https://www.dotnetcurry.com/csharp/1481/linq-query-execution-performance
        }

        delegate int PerformCalculation(int x);
    }
}
