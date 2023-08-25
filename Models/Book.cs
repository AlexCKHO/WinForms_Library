using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int PublishedYear { get; set; }
        public int BranchLocationId { get; set; }
        public bool Availability { get; set; }

    }
}
