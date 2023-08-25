using EI_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EI_Task.Data.Repositories
{
    public class BranchesRepository : LibraryRepository<Branch>
    {
        public BranchesRepository(LibraryDbContext context) : base(context)
        {

        }


    }
}
