using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // It is difficult to bring up collections without mentioning Language Integrated Query (LinQ)
            // LinQ provides a common, elegant, and performant means to working with collections
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
            // https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/working-with-linq
            // Need to filter, order, group, join, select (project/transform/map)? https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations

            var groceryList = new List<string> { "Carrot", "Meat", "Potato", "Milk", "Water", "Apple" };

            var firstInstance = groceryList.FirstOrDefault(e => e == "Milk");
            // Mild
            var firstInstanceNotFound = groceryList.FirstOrDefault(e => e == "Pancake");
            // null
            var conatinsLetterO = groceryList.Where(e => e.Contains('o'));
            // new list of string { Carrot, Potato }
            var projection = groceryList.Select(e =>  "Red " + e);
            // new list of string where all values are prepended with "Red "
            var ordered = groceryList.OrderBy(e => e);
            var orderedDescending = groceryList.OrderByDescending(e => e);
            
            groceryList.ForEach(e => { 
                // will run for each item in the collection, and pass the item into the variable we called e
            });

            var addedList = groceryList.Concat(new List<string> { "Orange", "Pinapple" });

            // https://github.com/dotnet/try-samples/tree/main/101-linq-samples


            // exelent read:
            // https://docs.microsoft.com/en-us/dotnet/csharp/linq/linq-in-csharp

            // most everyone uses method syntax: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq

            // Func<T..> is a lambda
            // LinQ-to-Objects typically expects a lambda an returns an IEnumberable
            // Entity Frameworks LinQ-to-SQL methods are not lambdas explicitly, they are expression bodies of lambdas: Expression<Func<T..>>
            // LinQ-to-SQL typically expects an expression body and returns an IQueryable
            // Difference is that a lambda will run on the server, and expression tree lambdas are converted into sql and ran on the database
            // This leads to some developer confusion expecting lamba like features that fail to run on LinQ-to-SQL
            // https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/linq/
            // All of this will be covered much later on
        }
    }
}
