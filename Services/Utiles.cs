using EI_Task.Models.DTO;
using EI_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Services
{
    public class Utiles
    {
        public static BookSearchResultDTO CreateBookSearchResultDTO(Book book, Branch branch)
        {
            return new BookSearchResultDTO
            {
                BookId = book.BookId,
                BookName = book.Name,
                PublishedYear = book.PublishedYear,
                Availability = book.Availability,
                BranchId = branch.BranchId,
                BranchName = branch.BranchName,
                BranchLocation = branch.Address,
                OpeningHours = branch.OpeningHours
            };
        }


    }
}
