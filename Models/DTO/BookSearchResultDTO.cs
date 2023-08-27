using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Models.DTO
{
    public class BookSearchResultDTO
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int PublishedYear { get; set; }
        public bool Availability { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchLocation { get; set; }
        public string OpeningHours { get; set; }
    }
}
