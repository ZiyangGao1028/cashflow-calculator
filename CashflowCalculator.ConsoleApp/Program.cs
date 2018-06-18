using CashflowCalculator.Models;
using CashflowCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using CashflowCalculator.DAL.Service;


namespace CashflowCalculator.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            int indication = 1;
            List<UnitFlow> fullList = new List<UnitFlow>();
            Loan loan = new Loan();

            while (indication > 0)
            {
                
                Console.Write("Please enter in your loan amount: ");
                string amount1 = Console.ReadLine();
                loan.Amount = decimal.Parse(amount1);

                Console.Write("Please enter in your loan duration: ");
                string duration1 = Console.ReadLine();
                loan.Duration = Int32.Parse(duration1);

                Console.Write("Please enter in your interest rate: ");
                string r1 = Console.ReadLine();
                loan.Rate = decimal.Parse(r1);

                LoanService.AddLoan(loan);

                UnitFlow unitFlow = Calculator.CalculateCashflow(loan);
                fullList.Add(unitFlow); 
                
            
                Console.WriteLine("Month\t\tInterest\tPrincipal\tRemaining Balance");
                foreach (var row in unitFlow.Unit)
                {
                    Console.WriteLine(row.Month + "\t\t" + Math.Round(row.InterestPayment, 2) + "\t\t" +
                        Math.Round(row.PrincipalPayment, 2) + "\t\t" + Math.Round(row.RemainingBalance, 2));
                }

                Console.Write("Would you want to enter another one? yes(1)/no(0)");
                indication = int.Parse(Console.ReadLine());

               
            }

            UnitFlow pool = new UnitFlow();

            pool = Calculator.CalculatePoolCashflow(fullList);

            Console.WriteLine("Month\t\tInterest\tPrincipal\tRemaining Balance");
            foreach (var row in pool.Unit)
            {
                Console.WriteLine(row.Month + "\t\t" + Math.Round(row.InterestPayment, 2) + "\t\t" +
                    Math.Round(row.PrincipalPayment, 2) + "\t\t" + Math.Round(row.RemainingBalance, 2));
            }

        }
    }
}
