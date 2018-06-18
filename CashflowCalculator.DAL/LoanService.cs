using CashflowCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashflowCalculator.DAL.Service
{
    public class LoanService

    {
        public static int AddLoan(Loan loan)
        {
            try
            {
                using (var context = new LoanContext())
                {
                    context.Loans.Add(loan);
                    context.SaveChanges();
                    return loan.Id;
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                return -1;
            }
        }

        public static List<Loan> GetLoans()

        {
            try
            {
                using (var context = new LoanContext())
                {
                    return context.Loans.ToList();
                }
            }

            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }

        }

        public static int deleteLoans(List<int> ids)

        {
            try
            {
                using (var context = new LoanContext())

                {
                    var loans = context.Loans.Where(x => ids.Contains(x.Id));
                    foreach (var loan in loans)
                    {
                        context.Loans.Remove(loan);
                    }
                    context.SaveChanges();
                    return 1;
                }
            }

            catch (Exception e)

            {
                Console.Write(e);
                return -1;
            }
        }
    }
}
