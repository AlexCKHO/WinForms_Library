using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Services
{
    public interface IUserManagerService
    {
        Task<bool> CreateUserAndAccount(string name, DateTime DOB, string email, string Address, int PMBId, string password);
        Task<Dictionary<string, int>> GetBranchNameAndId();
        Task<bool> hasDuplicateEmail(string email);
    }
}
