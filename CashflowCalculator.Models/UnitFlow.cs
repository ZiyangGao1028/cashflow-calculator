using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashflowCalculator.Models
{
    public class UnitFlow
    {
        public virtual List<CashflowRow> Unit { get; set; }
        public UnitFlow()
        {
            Unit = new List<CashflowRow>();
        }
    }
}
