using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class FinanceDbContext : DbContext
    {

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;Database=FinancetDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
                }
            }

            public DbSet<User> Users { get; set; }
            public DbSet<Transaction> Transactions { get; set; }
            public DbSet<Account> Accounts { get; set; }
            public DbSet<Transfer> Transfers { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                // Additional configurations if needed
            }
        }
}
