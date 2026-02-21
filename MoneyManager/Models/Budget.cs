using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Models
{
    internal class Budget
    {
        public int Id { get; set; } // PK
        public int CategoryId { get; set; } // FK
        public Category? Category { get; set; }
        public int LimitAmount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
