using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public int NumberOfActiveUsers { get; set; }
        public int NumberOfAvailableBooks { get; set; }
        public string OpeningHours { get; set; }
    }
}
