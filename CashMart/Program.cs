using System;

namespace CashMart
{
    class Program
    {
        static void Main(string[] args)
        {
            // We are tasked with designing cach registers at the local market. Using classes, create a Market, and a CashRegister. 
            // The Market should have a name, address, a reserve of $500, and multiple CashRegisters
            // The CashRegister should have an Id, an active/inactive indicator, current cash amount, a total cash storage space of $100. and methods to add and remove cash
            // The CashRegister class should keep track of all active CashRegisters, and the total current cash amount sum of all CashRegisters
            // If a CashRegister exeeds its maximum storage, it must transfer $80 of its money to the Market reserves
            // No item in the market is > $20, there is no catalog of items to choose from, the user supplies the item after choosing a CashRegister to checkout at
            // Users cannot use an inactive CashRegister
            // For ever 'turn' print a report of the Markets reserves, each CashRegisters money stored, active state, and the total cash in all CashRegisters
        }
    }
}
