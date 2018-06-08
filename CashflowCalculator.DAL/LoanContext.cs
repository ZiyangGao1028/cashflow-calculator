using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CashflowCalculator.Models;

namespace CashflowCalculator.DAL
{
    public class LoanContext : DbContext
    {
        public LoanContext() : base("name=LoanDBConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LoanContext, CashflowCalculator.DAL.Migrations.Configuration>());

        }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
