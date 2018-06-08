using CashflowCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashflowCalculator.DAL
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var ctx = new LoanContext())
            {
                var loan = new Loan() { Amount = 2300 };

                ctx.Loans.Add(loan);
                ctx.SaveChanges();
            }
        }
    }

}
