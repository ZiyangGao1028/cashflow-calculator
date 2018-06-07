using CashflowCalculator.Models;
using CashflowCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashflowCalculator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int indication = 1;
            List<List<CashflowRow>> fullList = new List<List<CashflowRow>>();
            
            while (indication > 0)
            {
                Loan loan = new Loan();
                Console.Write("Please enter in your loan amount: ");
                string amount1 = Console.ReadLine();
                loan.Amount = decimal.Parse(amount1);

                Console.Write("Please enter in your loan duration: ");
                string duration1 = Console.ReadLine();
                loan.Duration = Int32.Parse(duration1);

                Console.Write("Please enter in your interest rate: ");
                string r1 = Console.ReadLine();
                loan.Rate = decimal.Parse(r1);

                List<CashflowRow> flowList = Calculator.CalculateCashflow(loan);
                fullList.Add(flowList);
                
                int length = flowList.Count;
                Console.WriteLine("Month\t\tInterest\tPrincipal\tRemaining Balance");
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine(flowList[i].Month + "\t\t" + Math.Round(flowList[i].InterestPayment, 2) + "\t\t" +
                        Math.Round(flowList[i].PrincipalPayment, 2) + "\t\t" + Math.Round(flowList[i].RemainingBalance, 2));
                }

                Console.Write("Would you want to enter anoother one? yes(1)/no(0)");
                indication = int.Parse(Console.ReadLine());
            }

            int maxMonth = fullList.Max(x => x.Count);
            List<CashflowRow> pool = new List<CashflowRow>();
            for (var i = 0; i < maxMonth; ++i)
            {
                CashflowRow cashflowRow = new CashflowRow();
                cashflowRow.Month = i + 1;
                foreach (var cashflow in fullList)
                {
                    int cashflowMonths = cashflow.Count;
                    cashflowRow.InterestPayment += cashflowMonths > i ? cashflow[i].InterestPayment : 0;
                    cashflowRow.PrincipalPayment += cashflowMonths > i ? cashflow[i].PrincipalPayment : 0;
                    cashflowRow.RemainingBalance += cashflowMonths > i ? cashflow[i].RemainingBalance : 0;
                }
                pool.Add(cashflowRow);
            }
            Console.WriteLine("Month\t\tInterest\tPrincipal\tRemaining Balance");
            for (int i = 0; i < pool.Count; i++)
            {
                Console.WriteLine(pool[i].Month + "\t\t" + Math.Round(pool[i].InterestPayment, 2) + "\t\t" +
                    Math.Round(pool[i].PrincipalPayment, 2) + "\t\t" + Math.Round(pool[i].RemainingBalance, 2));
            }

        }
    }
}
