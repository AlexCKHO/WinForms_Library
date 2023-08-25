using EI_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Data.Repositories
{
    public class AccountsRepository : LibraryRepository<Account>
    {
        public AccountsRepository(LibraryDbContext context) : base(context)
        {

        }


    }
}
