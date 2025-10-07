using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Action
    {
        Pay = 0,
        Finish = 1, // After paind and used
        Cancel = 2, // Can never be paid     
        Refound = 3,// Paid then refound
        Reopen = 4  // Canceled
    }
}
