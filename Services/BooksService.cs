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
    public class BooksService : LibraryService<Book>
    {
        private readonly ILibraryRepository<Book> _repository;
        public BooksService(ILibraryRepository<Book> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Book?> GetAsync(int id)
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
