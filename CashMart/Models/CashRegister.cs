using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void AddCash(int cash)
        {
            if (CurrentCash + cash >= TotalCashStorage)
            {
                // transfer cash to market
                MakeInactive();
                CurrentCash -= 80;
                Market.AddReserve(80);
            }
            else
            {
                CurrentCash += cash;
            }
        }
        public void RemoveCash(int cash)
        {
            if (CurrentCash - cash < 0)
            {
                // transfer cash from market
                Market.RemoveReseve(100);
                AddCash(cash + 100);
                MakeInactive();
            }
            else
            {
                CurrentCash -= cash;
            }
        }
        private void MakeInactive()
        {
            Log($"Register {Id} will be offline until transaction with market is complete");
            Active = false;
            TurnsToReplenish = 2;
        }
    }
}
