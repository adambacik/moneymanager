using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Services
{
    internal class AuthService : IAuthService
    {
        public Models.User? CurrentUser { get; set; }
        public Data.AppDbContext AppDbContext { get; set; }

        public AuthService(Data.AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        async Task<bool> IAuthService.RegisterAsync(string username, string email, string password)
        {
            bool emailExists = await AppDbContext.Users.AnyAsync(u => u.Email == email); // if email already used
            if (emailExists)
                return false;

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password); // GetHashCode hash

            var newUser = new Models.User // create new user
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash
            };

            AppDbContext.Users.Add(newUser); // add new user

            CurrentUser = newUser;

            return true;
        }

        async Task<bool> IAuthService.LoginAsync(string email, string password)
        {
            var user = await AppDbContext.Users.FirstOrDefaultAsync(u => u.Email == email); // find user
            if (user == null)
                return false;

            bool verify = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash); // verify his password
            if (!verify)
                return false;

            return true;
        }

        void IAuthService.Logout()
        {
            CurrentUser = null;
        }
    }
}
