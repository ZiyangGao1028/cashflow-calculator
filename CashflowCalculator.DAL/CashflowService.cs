using CashflowCalculator.Models;
using CashflowCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace CashflowCalculator.DAL.Service
{
    public static class CashflowService
    {
        public static List<UnitFlow> GetCashFlows()
        {
            try
            {
                using (var context = new LoanContext())
                {
                    var loans = context.Loans.ToList();

                    List<UnitFlow> cashflowsUnits = new List<UnitFlow>();
                    foreach (var loan in loans)
                    {
                        cashflowsUnits.Add(Calculator.CalculateCashflow(loan));
                    }
                    cashflowsUnits.Add(Calculator.CalculatePoolCashflow(cashflowsUnits));
                    return cashflowsUnits;
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }
    }
}