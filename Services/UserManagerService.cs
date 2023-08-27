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
        private readonly ILibraryService<User> _userService;
        private readonly ILibraryService<Account> _accountService;
        private readonly ILibraryService<Branch> _branchService;

        public UserManagerService(ILogger<IUserManagerService> logger, ILibraryService<User> userService, ILibraryService<Account> accountService, ILibraryService<Branch> branchService)
        {
            _logger = logger;
            _userService = userService;
            _accountService = accountService;
            _branchService = branchService;
        }

        public async Task<bool> CreateUserAndAccount(string name, DateTime DOB, string email, string Address, int PMBId, string password)
        {
            try
            {

                Account account = await createAccountAsync(email, password);
                User user = await createUserAsync(name, DOB, email, Address, PMBId);

               bool updateAcctAndUserIdResult = await updateAcctAndUserId(user, account);
               bool updateBranchUser = await this.updateBranchUser(PMBId);

                if(updateAcctAndUserIdResult && updateBranchUser)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex}");

                return false;

            }
        }


        private async Task<Account> createAccountAsync(string email, string password)
        {
            Account account = new Account();
            account.Email = email;
            account.Password = password;

            await _accountService.CreateAsync(account);

            return account;
        }

        private async Task<User> createUserAsync(string name, DateTime DOB, string email, string Address, int PMBId)
        {
            User user = new User();
            user.Address = Address;
            user.Name = name;
            user.Email = email;
            user.DateOfBirth = DOB;
            user.BranchId = PMBId;

            await _userService.CreateAsync(user);

            return user;
        }

        private async Task<bool> updateAcctAndUserId(User user, Account account)
        {
            try
            {
                user.AccountId = account.AccountId;
                account.UserId = user.UserId;

                await _accountService.UpdateAsync(account.AccountId, account);
                await _userService.UpdateAsync(user.UserId, user);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex}");

                return false;
            }

        }
        public async Task<Dictionary<string, int>> GetBranchNameAndId()
        {
            IEnumerable<Branch> branches = await _branchService.GetAllAsync();

            Dictionary<string, int> branchIdDictionary = branches.ToDictionary(branch => branch.BranchName, branch => branch.BranchId);

            return branchIdDictionary;
        }

        private async Task<bool> updateBranchUser(int PMBId)
        {
            var updateBranch = await _branchService.GetAsync(PMBId);
            if(updateBranch != null) {
                updateBranch.NumberOfActiveUsers++;
                await _branchService.UpdateAsync(PMBId, updateBranch);
                return true;
            }

            return false;

        }

        public async Task<bool> hasDuplicateEmail(string email)
        {
            var accounts = await _accountService.GetAllAsync();

            bool isDuplicate = accounts.Any(account => account.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            return isDuplicate;
        }

    }
}
