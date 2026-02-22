using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Services
{
    public interface IAuthService
    {
        Models.User? CurrentUser { get; set; }

        Task<bool> RegisterAsync(string username, string email, string password);

        Task<bool> LoginAsync(string email, string password);

        void Logout();
    }
}
