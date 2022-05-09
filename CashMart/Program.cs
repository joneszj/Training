using CashMart.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CashMart
{
    class Program
    {
        static void Main(string[] args)
        {
            // We are tasked with designing cach registers at the local market. Using classes, create a Market, and a CashRegister. 
            // The Market should have a name, address, a reserve of $500, and multiple CashRegisters
            // The CashRegister should have an Id, an active/inactive indicator, current cash amount, a total cash storage space of $100. and methods to add and remove cash
            // You will need to keep track of all active CashRegisters, and the total current cash amount sum of all CashRegisters
            // consider a static property, a method on Market is composed in CashRegister, or a method on Market
            // If a CashRegister exeeds its maximum storage, it must transfer $80 of its money to the Market reserves and is inactive for the next turn
            // No item in the market is > $20, there is no catalog of items to choose from, the user supplies the item after choosing a CashRegister to checkout at
            // A user may return an item (cash withdraw from register)
            // Users cannot use an inactive CashRegister
            // For ever 'turn' print a report of the Markets reserves, each CashRegisters money stored, active state, and the total cash in all CashRegisters

            try
            {
                var rng = new Random();
                var market = new Market("SuperDuper Mart", "123 Main St.", (log) => Console.WriteLine(log));
                market.AddRegisters(10);
                market.SetItems(new Item[] {
                    new Item("Milk", 5),
                    new Item("Steak", 8),
                    new Item("Water", 3),
                    new Item("Eggs", 4),
                    new Item("Ice Cream", 10),
                    new Item("Apple", 1),
                    new Item("Orange", 1),
                    new Item("Soda", 5),
                    new Item("Yogurt", 3),
                    new Item("Chips", 3),
                    new Item("Chocolate", 4)
                });
                int makertTotalPreviousTurn = market.Reserve;

                do
                {
                    Console.WriteLine($"Welcome to {market.Name}");
                    IEnumerable<Shopper> shoppers = Shopper.CreateShoppers(rng.Next(0, 10))
                        .Select(e => e.GoShopping(rng, market));

                    // Notice: CreateShoppers and GoShopping execution is deferred until we start enumerating
                    foreach (var shopper in shoppers)
                    {
                        var register = market.GetRegister(rng);
                        if (register == null)
                        {
                            do
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("Emergency, all registers are offline. Please hold...");
                                market.ReplenishRegisters();
                                register = market.GetRegister(rng);
                                Console.ResetColor();
                            } while (register == null);
                        }
                        Console.WriteLine("A customer has started checkout...");
                        shopper.CheckOut(register);
                        Console.WriteLine("A customer has completed checkout...");
                    }

                    Console.WriteLine("\n\n*** Report ***");
                    Console.WriteLine("Market Reserves: " + market.Reserve);
                    Console.WriteLine("Cash in registers: " + market.AllCahRegistersTotal());
                    Console.WriteLine("Total difference: " + (market.Reserve - makertTotalPreviousTurn));
                    makertTotalPreviousTurn = market.Reserve;

                    market.ReplenishRegisters();
                    Console.WriteLine();
                    // end turn
                    Console.ReadKey(true);
                } while (!market.Bankrupt);
                Console.WriteLine("The market has gone bankrupt!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong :( {ex.Message}");
                throw;
            }
        }


    }
}
