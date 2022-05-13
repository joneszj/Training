using System;
using System.Collections.Generic;
using System.Linq;

namespace CashMart.Models
{
    class Market
    {
        public Market(string name, string address, Action<string> log)
        {
            Name = name;
            Address = address;
            Log = log;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public Action<string> Log { get; }
        public int Reserve { get; set; } = 500;
        public bool Bankrupt { get; set; }
        public ICollection<CashRegister> CashRegisters { get; set; } = new HashSet<CashRegister>();
        public IEnumerable<Item> Items { get; set; }
        public void AddReserve(int cash)
        {
            Reserve += cash;
        }
        public int? RemoveReseve(int cash)
        {
            if (Reserve - cash <= 0)
            {
                Bankrupt = true;
                return null;
            }
            Reserve -= cash;
            return cash;
        }
        public void AddRegisters(int count)
        {
            for (int i = 0; i < count; i++)
            {
                CashRegisters.Add(new CashRegister(this, i, Log));
            }
        }
        public int AllCahRegistersTotal()
        {
            return CashRegisters.Sum(e => e.CurrentCash);
        }
        public void SetItems(IEnumerable<Item> items)
        {
            Items = items;
        }
        public CashRegister GetRegister(Random rng)
        {
            return CashRegisters.Where(e => e.Active).Skip(rng.Next(0, CashRegisters.Count(e => e.Active)))?.FirstOrDefault();
        }
        public void ReplenishRegisters()
        {
            var inactiveRegisters = CashRegisters.Where(e => !e.Active);
            int reactivatedCount = 0;
            foreach (var inactive in inactiveRegisters)
            {
                inactive.TurnsToReplenish--;
                if (inactive.TurnsToReplenish == 0)
                {
                    inactive.Active = true;
                    reactivatedCount++;
                    Log.Invoke($"Register {inactive.Id} has been reactivated.");
                }
            }
            if (reactivatedCount > 0)
            {
                Log.Invoke($"{reactivatedCount} register(s) have been reactivated.");
            }
        }
    }
}
