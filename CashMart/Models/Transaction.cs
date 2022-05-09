using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMart.Models
{
    class Transaction
    {
        public Transaction(Item item, TransactionType transactionType)
        {
            Item = item;
            transactionType = TransactionType;
        }

        public Item Item { get; set; }
        public TransactionType TransactionType { get; set; }
    }

    enum TransactionType
    {
        Sold,
        Returned
    }
}
