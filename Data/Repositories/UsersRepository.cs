using EI_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Data.Repositories
{
    public class UsersRepository : LibraryRepository<User>
    {
        public UsersRepository(LibraryDbContext context) : base(context)
        {

        }



    }
}
