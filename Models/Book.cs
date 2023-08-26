using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool Availability { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
    }
}