using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Models
{
    enum TransactionType
    {
        Income,
        Expense,
    }

    internal class Transaction
    {
        public int Id { get; set; } // PK
        public int CategoryId { get; set; } // FK
        public int AccountId { get; set; } // FK
        public Account? Account { get; set; }
        public Category? Category { get; set; }
        public decimal Amount { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; }
    }
}
