﻿using EI_Task.Models;
using EI_Task.Models.DTO;
using Microsoft.Extensions.Logging;


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
            bool createBookInDbAsyncResult = await createBookInDbAsync(name, publishedYear, availability, branchId);
            if (availability)
            {
                return await addBranchAvailableBook(branchId);
            }
            return createBookInDbAsyncResult;

        }

        private async Task<bool> addBranchAvailableBook(int branchId)
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

        private async Task<bool> minusBranchAvailableBook(int branchId)
        {
            var updateBranch = await _branchService.GetAsync(branchId);
            if (updateBranch != null)
            {
                updateBranch.NumberOfAvailableBooks--;
                await _branchService.UpdateAsync(branchId, updateBranch);
                return true;
            }

            return false;
        }
        private async Task<bool> createBookInDbAsync(string name, int publishedYear, bool availability, int branchId)
        {
            try
            {
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

        public async Task<List<Book>> GetListOfBookAsync()
        {

           return (await _bookService.GetAllAsync()).ToList();

        }
        public async Task DeleteBookAsync(int id)
        {
            var book = await GetBookByIdAsync(id);

            if (book.Availability)
            {
               await minusBranchAvailableBook(book.BranchId);
            }

           await _bookService.DeleteAsync(id);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            try
            {  
                return await _bookService.GetAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Failed to get book by ID {id}: {ex}");
                return null;
            }
        }

        private async Task<bool> UpdateBookName(int bookId, string newBookName)
        {
            try
            {

                var originalBook = await GetBookByIdAsync(bookId);


                if (originalBook == null)
                {
                    _logger.LogWarning($"Failed to find book with ID {bookId}.");
                    return false;
                }


                originalBook.Name = newBookName.Trim();


                await _bookService.UpdateAsync(bookId, originalBook);
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogWarning($"Failed to update book name with ID {bookId}: {ex}");
                return false;
            }
        }

        private async Task<bool> UpdateBookYear(int bookId, int newBookYear)
        {
            try
            {

                var originalBook = await GetBookByIdAsync(bookId);


                if (originalBook == null)
                {
                    _logger.LogWarning($"Failed to find book with ID {bookId}.");
                    return false;
                }


                originalBook.PublishedYear = newBookYear;


                await _bookService.UpdateAsync(bookId, originalBook);
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogWarning($"Failed to update book name with ID {bookId}: {ex}");
                return false;
            }
        }

        private async Task<bool> UpdateAvailable(int bookId, bool available)
        {


            try
            {
                var originalBook = await GetBookByIdAsync(bookId);

                if (originalBook == null)
                {
                    _logger.LogWarning($"Failed to find book with ID {bookId}.");
                    return false;
                }

                if (available)
                {
                  await addBranchAvailableBook(originalBook.BranchId);
                } else
                {
                  await minusBranchAvailableBook(originalBook.BranchId);
                }

                // Update the book's name
                originalBook.Availability = available;

                // Update the book in the database
                await _bookService.UpdateAsync(bookId, originalBook);
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception and return false
                _logger.LogWarning($"Failed to update book name with ID {bookId}: {ex}");
                return false;
            }
        }


        public async Task<List<BookSearchResultDTO>> GetListOfBookSearchResultDTO()
        {
            List<BookSearchResultDTO> resultList = new List<BookSearchResultDTO>();

            var books = await _bookService.GetAllAsync();
            var branches = await _branchService.GetAllAsync();

            Dictionary<int, Branch> branchDictionary = branches.ToDictionary(branch => branch.BranchId, branch => branch);

            foreach (var book in books)
            {
                if (branchDictionary.ContainsKey(book.BranchId))
                {
                    var branch = branchDictionary[book.BranchId];
                    var dto = Utiles.CreateBookSearchResultDTO(book, branch);
                    resultList.Add(dto);
                }
                else
                {
                    _logger.LogWarning($"Branch not found for book with ID {book.BookId}");
                }
            }

            return resultList;
        }

        public async Task<List<BookSearchResultDTO>> GetListOfBookSearchResultDTO(string bookName)
        {
            List<BookSearchResultDTO> resultList = new List<BookSearchResultDTO>();

            // Filter books based on the input book name
            var books = (await _bookService.GetAllAsync()).Where(book => book.Name.Contains(bookName, StringComparison.OrdinalIgnoreCase)).ToList();
            var branches = await _branchService.GetAllAsync();

            Dictionary<int, Branch> branchDictionary = branches.ToDictionary(branch => branch.BranchId, branch => branch);

            foreach (var book in books)
            {
                if (branchDictionary.ContainsKey(book.BranchId))
                {
                    var branch = branchDictionary[book.BranchId];
                    var dto = Utiles.CreateBookSearchResultDTO(book, branch);
                    resultList.Add(dto);
                }
                else
                {
                    _logger.LogWarning($"Branch not found for book with ID {book.BookId}");
                }
            }

            return resultList;
        }


        // Add these methods to your BookManagerService class
        public async Task<bool> UpdateBookPropertyAsync(int bookId, string propertyName, object newValue)
        {


            if (propertyName == "Name")
            {
                return await UpdateBookName(bookId, newValue.ToString());
            }
            else if (propertyName == "PublishedYear")
            {
                return await UpdateBookYear(bookId, Convert.ToInt32(newValue));
            }
            else if (propertyName == "Availability")
            {
                return await UpdateAvailable(bookId, Convert.ToBoolean(newValue));
            }
            return false;
        }




    }
}
