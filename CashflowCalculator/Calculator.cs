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

        public static UnitFlow CalculateCashflow(Loan loan)
        {
            UnitFlow unitflow = new UnitFlow();
            
            decimal monthlyPay = MonthlyPayment(loan.Amount, loan.Duration, loan.Rate);          
            decimal RemainingBalance = loan.Amount;

            for (int month = 1; month <= loan.Duration; month++)
            {
                CashflowRow flowRow = new CashflowRow();

                flowRow.RemainingBalance = RemainingBalance;

                flowRow.Month = month;
                flowRow.InterestPayment = InterestCalc(loan.Rate, flowRow.RemainingBalance);
                flowRow.PrincipalPayment = PrincipalPay(monthlyPay, flowRow.InterestPayment);
                flowRow.RemainingBalance = flowRow.RemainingBalance - flowRow.PrincipalPayment;
                unitflow.Unit.Add(flowRow);

                RemainingBalance = flowRow.RemainingBalance;
            }
            return unitflow; 
        }

        public static UnitFlow CalculatePoolCashflow(List<UnitFlow> unitflows)
        {
            List<CashflowRow> pool = new List<CashflowRow>();
            foreach (var cashflow in unitflows)
            {
                int x = 0;
                foreach (var CashflowRow in cashflow.Unit)
                {
                    if (x >= pool.Count)
                    {
                        pool.Add(new CashflowRow()
                        {
                            InterestPayment = CashflowRow.InterestPayment,
                            PrincipalPayment = CashflowRow.PrincipalPayment,
                            RemainingBalance = CashflowRow.RemainingBalance,
                            Month = CashflowRow.Month
                        });

                    }
                    else
                    {
                        pool[x].InterestPayment += CashflowRow.InterestPayment;
                        pool[x].PrincipalPayment += CashflowRow.PrincipalPayment;
                        pool[x].RemainingBalance += CashflowRow.RemainingBalance;
                    }
                    x++;
                }
            }
            return new UnitFlow() { Unit = pool };
        }

    }
}
