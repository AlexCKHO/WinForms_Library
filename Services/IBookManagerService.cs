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
    }
}
