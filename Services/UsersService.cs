using EI_Task.Data.Repositories;
using EI_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Services
{
    public class UsersService : LibraryService<User>
    {

        private readonly ILibraryRepository<User> _repository;
        public UsersService(ILibraryRepository<User> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<User?> GetAsync(int id)
        {
            if (_repository.IsNull)
            {
                return null;
            }

            var entity = await _repository.FindAsync(id);
            if (entity == null)
            {

                return null;
            }

            return entity;
        }


    }
}
