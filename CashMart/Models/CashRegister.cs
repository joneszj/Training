using System;

namespace CashMart.Models
{
    class CashRegister
    {
        public CashRegister(Market market, int id, Action<string> log)
        {
            Market = market;
            Id = id;
            Log = log;
        }
        public Market Market { get; }
        public int Id { get; set; }
        public Action<string> Log { get; }
        public bool Active { get; set; } = true;
        public int TurnsToReplenish { get; set; }
        public int CurrentCash { get; set; } = 50;
        public int TotalCashStorage { get; } = 100;
        public void Sell(Item item)
        {
            if (CurrentCash + item.Price >= TotalCashStorage)
            {
                // transfer cash to market
                MakeInactive();
                CurrentCash -= 80;
                Market.AddReserve(80);
            }
            else
            {
                CurrentCash += item.Price;
            }
            Log.Invoke($"{item.Name} was sold for {item.Price}!");
        }
        public void Buyback(Item item)
        {
            if (CurrentCash - item.Price < 0)
            {
                // transfer cash from market
                Sell(item);
                Market.RemoveReseve(100);
                Sell(new Item("Transfer from Market", 100));
                MakeInactive();
            }
            else
            {
                CurrentCash -= item.Price;
            }
            Log.Invoke($"{item.Name} was returned for {item.Price}!");
        }
        private void MakeInactive()
        {
            Log($"Register {Id} will be offline until transaction with market is complete");
            Active = false;
            TurnsToReplenish = 2;
        }
    }
}
