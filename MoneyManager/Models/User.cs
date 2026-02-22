using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Models
{
    public class User
    {
        public int Id { get; set; } // PK
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public ICollection<Account> Accounts { get; set; } = [];
    }
}
