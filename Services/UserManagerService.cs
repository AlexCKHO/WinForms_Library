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
        private readonly ILibraryRepository<User> _UserRepository;
        private readonly ILibraryRepository<Account> _AccountRepository;

        public UserManagerService(ILogger<IUserManagerService> logger, ILibraryRepository<User> UserRepository, ILibraryRepository<Account> AccountRepository)
        {
            _logger = logger;
            _UserRepository = UserRepository;
            _AccountRepository = AccountRepository;

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

            _AccountRepository.Add(account);
            _UserRepository.Add(user);
            await _UserRepository.SaveAsync();

            user.AccountId = account.AccountId;
            account.UserId = user.UserId;

            await _UserRepository.SaveAsync();
            return true;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex}");

                return false;

            }
        }
    }
}
