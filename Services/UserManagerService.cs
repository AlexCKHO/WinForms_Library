using EI_Task.Data.Repositories;
using EI_Task.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly ILogger _logger;
        private readonly ILibraryRepository<User> _userRepository;
        private readonly ILibraryRepository<Account> _accountRepository;
        private readonly ILibraryRepository<Branch> _branchRepository;

        public UserManagerService(ILogger<IUserManagerService> logger, ILibraryRepository<User> userRepository, ILibraryRepository<Account> accountRepository, ILibraryRepository<Branch> branchRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _branchRepository = branchRepository;
        }

        public async Task<bool> CreateUserAndAccount(string name, DateTime DOB, string email, string Address, int PMBId, string password)
        {
            try { 
            Account account = new Account();
            account.Email = email;
            account.Password = password;

            User user = new User();
            user.Address = Address;
            user.Name = name;
            user.Email = email;
            user.DateOfBirth = DOB;
            user.BranchId = PMBId;

            _accountRepository.Add(account);
            _userRepository.Add(user);
            await _userRepository.SaveAsync();

            user.AccountId = account.AccountId;
            account.UserId = user.UserId;

            await _userRepository.SaveAsync();
            return true;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex}");

                return false;

            }
        }

        public async Task<Dictionary<string,int>> GetBranchNameAndId()
        {
            IEnumerable<Branch> branches = await _branchRepository.GetAllAsync();

            Dictionary<string, int> branchIdDictionary = branches.ToDictionary(branch => branch.BranchName, branch => branch.BranchId);

            return branchIdDictionary;
        }

    }
}
