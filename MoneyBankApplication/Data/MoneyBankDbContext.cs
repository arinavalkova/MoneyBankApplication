using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MoneyBankApplication.Models;

namespace MoneyBankApplication.Data
{
    public class MoneyBankDbContext : DbContext
    {
        public int Key { get; set; }
        public MoneyBankDbContext(DbContextOptions<MoneyBankDbContext> options) : base(options)
        {
            Key = 100;
            Database.EnsureCreated();
        }
        
        public DbSet<User?> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(GetUsers());
            base.OnModelCreating(modelBuilder);
        }
        private IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new() {Id = 1, Login = "arina", Password = "123", Name = "Arina", PhoneNumber = "89134678907"}
            };
        }
    }
}