using EI_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Data.Repositories
{
    public class BooksRepository : LibraryRepository<Book>
    {
        public BooksRepository(LibraryDbContext context) : base(context)
        {

        }
        public override async Task<Book?> FindAsync(int id)
        {

            return await _dbSet
                .Where(s => s.BookId == id)
                .FirstOrDefaultAsync();
        }


    }
}
