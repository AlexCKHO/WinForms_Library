﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Data.Repositories
{
    public class LibraryRepository<T> : ILibraryRepository<T> where T : class
    {

        private readonly LibraryDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public LibraryRepository(LibraryDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public bool IsNull => _dbSet == null;

        public void Add(T entity)
        {

            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual async Task<T?> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return  await _dbSet.ToListAsync();
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
