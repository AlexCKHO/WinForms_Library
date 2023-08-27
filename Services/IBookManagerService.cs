using EI_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Services
{
    public  interface IBookManagerService
    {
        Task<bool> CreateBookAsync(string name, int publishedYear, bool availability, int branchId);
        Task<Dictionary<string, int>> GetBranchNameAndIdAsync();
        Task<List<Book>> GetListOfBookAsync();
        Task DeleteBookAsync(int id);
        Task<Book> GetBookByIdAsync(int id);
        Task<bool> UpdateBookByIdAsync(int id, Book updatedBook);
    }
}
