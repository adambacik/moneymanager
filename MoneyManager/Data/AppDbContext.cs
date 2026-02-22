using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Account> Accounts { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Transaction> Transactions { get; set; }
        public DbSet<Models.Budget> Budgets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string source = Path.Combine(FileSystem.AppDataDirectory, "moneymanager.db");
                optionsBuilder.UseSqlite($"Data Source = {source}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // todo
        }
    }
}
