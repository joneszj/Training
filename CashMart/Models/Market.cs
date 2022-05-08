using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMart.Models
{
    class Market
    {
        public Market(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Reserve { get; set; } = 500;
        public bool Bankrupt { get; set; }
        public ICollection<CashRegister> CashRegisters { get; set; } = new HashSet<CashRegister>();
        public IEnumerable<Item> Items { get; set; }
        public void AddReserve(int cash)
        {
            Reserve += cash;
        }
        public int? RemoveResever(int cash)
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
                CashRegisters.Add(new CashRegister(this));
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
    }
}
