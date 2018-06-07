using CashflowCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashflowCalculator
{
    public class Calculator
    {
        private static decimal MonthlyPayment(decimal amount, int duration, decimal r) 
        {
            double numerator = Convert.ToDouble(amount * (r / 1200));
            double denominator = (1 - Math.Pow(Convert.ToDouble(1 + r / 1200), -duration));
            return Convert.ToDecimal(numerator / denominator);
        }
        private static decimal InterestCalc(decimal r, decimal remainBal)
        {
            decimal InterestPayment = remainBal * r / 1200;
            return InterestPayment;
        }
        private static decimal PrincipalPay(decimal MonthlyPay, decimal InterestPayment)
        {
            decimal PrincipalPay = MonthlyPay - InterestPayment;
            return PrincipalPay;
        }

        public static List<CashflowRow> CalculateCashflow(Loan loan)
        {
            List<CashflowRow> flowList = new List<CashflowRow>();
            
            decimal monthlyPay = MonthlyPayment(loan.Amount, loan.Duration, loan.Rate);
            Console.WriteLine(monthlyPay);          
            decimal RemainingBalance = loan.Amount;

            for (int month = 1; month <= loan.Duration; month++)
            {
                CashflowRow flowRow = new CashflowRow();

                flowRow.RemainingBalance = RemainingBalance;

                flowRow.Month = month;
                flowRow.InterestPayment = InterestCalc(loan.Rate, flowRow.RemainingBalance);
                flowRow.PrincipalPayment = PrincipalPay(monthlyPay, flowRow.InterestPayment);
                flowRow.RemainingBalance = flowRow.RemainingBalance - flowRow.PrincipalPayment;
                flowList.Add(flowRow);

                RemainingBalance = flowRow.RemainingBalance;
            }
            return flowList; 
        }

    }
}
