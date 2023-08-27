using EI_Task.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Services
{
    public class BookManagerService : IBookManagerService
    {
        private readonly ILogger _logger;
        private readonly ILibraryService<Book> _bookService;
        private readonly ILibraryService<Branch> _branchService;

        public BookManagerService(ILogger<IUserManagerService> logger, ILibraryService<Book> bookService, ILibraryService<Branch> branchService)
        {
            _logger = logger;
            _bookService = bookService;
            _branchService = branchService;
        }

        public async Task<bool> CreateBookAsync(string name, int publishedYear, bool availability, int branchId)
        {
            bool createBookInDbAsyncResult =  await createBookInDbAsync(name, publishedYear, availability, branchId);
            if (availability)
            {
            return await updateBranchBook(branchId);
            }
            return createBookInDbAsyncResult;

        }

        private async Task<bool> updateBranchBook(int branchId)
        {
            var updateBranch = await _branchService.GetAsync(branchId);
            if (updateBranch != null)
            {
                updateBranch.NumberOfAvailableBooks++;
                await _branchService.UpdateAsync(branchId, updateBranch);
                return true;
            }

            return false;

        }
        private async Task<bool> createBookInDbAsync(string name, int publishedYear, bool availability, int branchId)
        {
            try { 
            var book = new Book();
            book.Name = name;
            book.PublishedYear = publishedYear;
            book.Availability = availability;
            book.BranchId = branchId;
            
            await _bookService.CreateAsync(book);
            return true;
            } 
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex}");
                return false;
            }

        }

        public async Task<Dictionary<string, int>> GetBranchNameAndIdAsync()
        {
            IEnumerable<Branch> branches = await _branchService.GetAllAsync();

            Dictionary<string, int> branchIdDictionary = branches.ToDictionary(branch => branch.BranchName, branch => branch.BranchId);

            return branchIdDictionary;
        }
    }
}
