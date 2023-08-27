﻿using EI_Task.Models;
using EI_Task.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Services
{
    public  interface IBookManagerService
    {
        Task<bool> CreateBookAsync(string name, int publishedYear, bool availability, int branchId);
        Task<Dictionary<string, int>> GetBranchNameAndIdAsync();
        Task<List<Book>> GetListOfBookAsync();
        Task<List<BookSearchResultDTO>> GetListOfBookSearchResultDTO();
        Task<List<BookSearchResultDTO>> GetListOfBookSearchResultDTO(string bookName);
        Task DeleteBookAsync(int id);
        Task<Book> GetBookByIdAsync(int id);
        Task<bool> UpdateBookName(int bookId, string newBookName);
        Task<bool> UpdateBookYear(int bookId, int newBookYear);
        Task<bool> UpdateAvailable(int bookId, bool available);
    }
}
