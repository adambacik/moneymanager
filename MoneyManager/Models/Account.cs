using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoneyManager.Models
{
    internal class Account
    {
        public int Id { get; set; } // PK
        public int UserId { get; set; } // FK
        public User? User { get; set; }
        public string Name { get; set; } = "";
        public decimal InitialBalance { get; set; }
        public DateTime CreatedAt {  get; set; }
        public Collection<Transaction> Transactions { get; set; } = [];
    }
}
