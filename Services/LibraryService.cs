using EI_Task.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Services
{
    public class LibraryService<T> : ILibraryService<T> where T : class
    {

        private readonly ILibraryRepository<T> _repository;

        public LibraryService(ILibraryRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateAsync(T entity)
        {
            if (_repository.IsNull)
            {
                return false;
            }

            _repository.Add(entity);
            await _repository.SaveAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (_repository.IsNull)
            {
                return false;
            }

            var entity = await _repository.FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            _repository.Remove(entity);
            await _repository.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            if (_repository.IsNull)
            {
                return null;
            }
            return await _repository.GetAllAsync();
        }

        public async Task<T?> GetAsync(int id)
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

        public async Task<bool> UpdateAsync(int id, T entity)
        {
            _repository.Update(entity);

            try
            {
                await _repository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EntityExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private async Task<bool> EntityExists(int id)
        {
            return (await _repository.FindAsync(id)) != null;
        }


    }
}










