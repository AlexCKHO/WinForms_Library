using EI_Task.Data.Repositories;
using EI_Task.Models;


namespace EI_Task.Services
{
    public class AccountsService :  IAccountService
    {
        private readonly ILibraryRepository<Account> _repository;

        public AccountsService(ILibraryRepository<Account> repository) 
        {
            _repository = repository;
        }


        public async Task<int> LoginAsync(string email, string password)
        {
            List<Account?> ListOfAccounts = new List<Account?>(await _repository.GetAllAsync());
                
            if(ListOfAccounts.Count != 0)
            {
                var ac = ListOfAccounts.FirstOrDefault(u => u?.Email == email.ToLower() && u?.Password == password);
                if (ac != null)
                {
                    return ac.UserId;
                }
            }

            return -1;
        }
    }
}
