using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoneyManager.Models
{
    public enum CategoryType
    {
        Income,
        Expense,
    }

    public class Category
    {
        public int Id { get; set; } // PK
        public string Name { get; set; } = "";
        public string Icon { get; set; } = "";
        public string Color { get; set; } = ""; // #______
        public CategoryType Type { get; set; }
        public Collection<Transaction> Transactions { get; set; } = [];
        public Collection<Budget> Budgets { get; set; } = [];
    }
}
