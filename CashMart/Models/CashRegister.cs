using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMart.Models
{
    class CashRegister
    {
        public CashRegister(Market market)
        {
            Market = market;
        }
        public Market Market { get; }
        public int Id { get; set; }
        public bool Active { get; set; }
        public int CurrentCash { get; set; } = 50;
        public int TotalCashStorage { get; } = 100;
        public void AddCash(int cash)
        {
            if (CurrentCash + cash >= TotalCashStorage)
            {
                // transfer cash to market
                Active = false;
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
                Market.RemoveResever(100);
                AddCash(cash + 100);
                Active = false;
            }
            else
            {
                CurrentCash -= cash;
            }
        }
    }
}
