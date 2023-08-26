using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }

        [ForeignKey("Branch")]
        [Display(Name = "PrimaryMembershipBranchId")]
        public int BranchId { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

    }
}
