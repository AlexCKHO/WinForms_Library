using EI_Task.Data.Repositories;
using EI_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Services
{
    public class LoginService :  ILoginService
    {
        private readonly ILibraryRepository<User> _repository;

        public LoginService(ILibraryRepository<User> repository) 
        {
            _repository = repository;
        }


        public async Task<int> LoginAsync(string email, string password)
        {
            List<User?> ListOfUsers = new List<User?>(await _repository.GetAllAsync());
                
            if(ListOfUsers.Count != 0)
            {
                var user = ListOfUsers.FirstOrDefault(u => u?.Email == email && u?.Password == password);
                if (user != null)
                {
                    return user.UserId;
                }
            }

            return -1;
        }
    }
}
