using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashflowCalculator.Models
{
    public class Loan
    {
        //private int _duration;
        //public int GetDuration() { return _duration; }
        //public void SetDuration (int duration ) { _duration = duration; }
        //The code above gets generated at compile time from the code below.
        public int Id { get; set; }

        public int Duration { get; set; }

        public decimal Amount { get; set; }

        public decimal Rate { get; set; }
    }
}
