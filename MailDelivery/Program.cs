using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MailDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            try
            {
                // You are a mail delivery employee. You have a series of packages to deliver, and need to check off on a list whenever a package has been delievered
                // we will use an array of Guids to represent the packages we need to deliver. 
                // A Guid is a (virtually) universally unique identifier: https://docs.microsoft.com/en-us/dotnet/api/system.guid?view=net-6.0
                // develope an algorithm that will use a level of undeliverability for each package
                // when a package is undeliverable, try again at a later time
                // after retrying once for each undelivered package, output a report of delivered and undelivered packages
                // (when we get to classes we will do a similar excercise where we have actual addresses and signatures to capture)

                Random random = new();

                // create packages, random value between 1 and 100
                int packagesCount = random.Next(1, 100);

                // total packages to deliver array
                Guid[] packages = new Guid[packagesCount];

                // create package Ids
                for (int i = 0; i < packagesCount; i++)
                {
                    // new package identified as a Guid
                    packages[i] = Guid.NewGuid();
                }

                // deliveredPackages tracks delivered packages
                List<Guid> deliveredPackages = new List<Guid>();

                // undeliveredPackages tracks undelivered packages
                List<Guid> undeliveredPackages = new List<Guid>();

                // control bool variable to terminate loop from user input
                var continueDelivery = false;
                do
                {
                    // if looped, use different output conditioned on undelivered total
                    if (undeliveredPackages.Count > 0)
                    {
                        Console.WriteLine($"Attempting to redeliver undelivered packages. Total: {undeliveredPackages.Count}.");

                        // reset undeliveredPackages so that we can reuse it
                        undeliveredPackages = new List<Guid>();
                    }
                    else
                    {
                        Console.WriteLine($"We have {packagesCount} package{(packagesCount > 1 ? "s" : string.Empty)} to deliver.");
                    }

                    int count = 0;
                    // from our packages, only process the packages not already delivered (found in deliveredPackages)
                    foreach (var package in packages.Where(e => !deliveredPackages.Contains(e)))
                    {
                        // delivery attempt, if random double is greater than or equal to 0.5, success otherwise, failed
                        var delivered = random.NextDouble() >= 0.5;

                        // sleep/pause thread to simulate delivery time
                        Thread.Sleep(random.Next(10, 1000));

                        switch (delivered)
                        {
                            case true:
                                // delivered
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{++count}. Package Id: {package} delivered.");
                                deliveredPackages.Add(package);
                                break;
                            case false:
                                // undeliverable
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"{++count}. Package Id: {package} not delivered.");
                                undeliveredPackages.Add(package);
                                break;
                        }
                    }

                    // report
                    Console.ResetColor();
                    Console.WriteLine($"We have delivered {deliveredPackages.Count} package{(packagesCount > 1 ? "s" : string.Empty)}.");
                    Console.WriteLine($"{undeliveredPackages.Count} package{(packagesCount > 1 ? "s" : string.Empty)} were not delivered.");

                    // continue?
                    if (undeliveredPackages.Count > 0)
                    {
                        Console.WriteLine($"Would you like to attempt to deliver the remaining undelivered packages? Count: {undeliveredPackages.Count}");
                        continueDelivery = Console.ReadKey(true).Key == ConsoleKey.Y;
                    }
                    else
                    {
                        // terminate
                        continueDelivery = false;
                        Console.WriteLine("Congradulations! We have delivered every package!");
                    }
                } while (continueDelivery);

                if (undeliveredPackages.Count > 0)
                {
                    Console.WriteLine("The following packages will not be delivered...");
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (var undeliveredPackage in undeliveredPackages)
                    {
                        Console.WriteLine($"Package Id: {undeliveredPackage}");
                    }
                }

                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong :( {ex.Message}");
                throw;
            }
        }
    }
}