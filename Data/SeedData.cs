using EI_Task.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EI_Task.Data
{
    public class SeedData
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<LibraryDbContext>();

            if (context.Accounts.Any())
            {
                context.Accounts.RemoveRange(context.Accounts);
                context.Books.RemoveRange(context.Books);
                context.Branches.RemoveRange(context.Branches);
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

            }
            #region Adding_Accounts_And_Users
            var account1 = new Account();
            account1.Email = "1";
            account1.Password = "1";

            var user1 = new Models.User();
            user1.Address = "UserAddress1";
            user1.Name = "Testing User1";
            user1.Email = account1.Email;
            user1.DateOfBirth = new DateTime(2011, 12, 09);

            var account2 = new Account();
            account2.Email = "testing2@testing.com";
            account2.Password = "password";

            var user2 = new Models.User();
            user2.Address = "UserAddress2";
            user2.Name = "Testing User2";
            user2.Email = account2.Email;
            user2.DateOfBirth = new DateTime(2012, 11, 09);

            var account3 = new Account();
            account3.Email = "testing3@testing.com";
            account3.Password = "password";

            var user3 = new Models.User();
            user3.Address = "UserAddress3";
            user3.Name = "Testing User3";
            user3.Email = account3.Email;
            user3.DateOfBirth = new DateTime(2013, 10, 09);


            context.Accounts.AddRange(account1, account2, account3);
            context.Users.AddRange(user1, user2, user3);

            context.SaveChanges();

            user1.AccountId = account1.AccountId;
            account1.UserId = user1.UserId;

            user2.AccountId = account2.AccountId;
            account2.UserId = user2.UserId;

            user3.AccountId = account3.AccountId;
            account3.UserId = user3.UserId;

            context.SaveChanges();

            #endregion

            #region Adding_Branches

            var listOfbranches = new List<Branch>
            {
                new Branch
                {
                    BranchName = "Testing1",
                    Address = "TestingAddress1",
                    NumberOfActiveUsers = 0,
                    NumberOfAvailableBooks = 0,
                    OpeningHours = "09:00 to 22:00"
                },
                new Branch
                {
                    BranchName = "Testing2",
                    Address = "TestingAddress2",
                    NumberOfActiveUsers = 0,
                    NumberOfAvailableBooks = 0,
                    OpeningHours = "09:30 to 22:30"
                },
                new Branch
                {
                    BranchName = "Testing3",
                    Address = "TestingAddress3",
                    NumberOfActiveUsers = 0,
                    NumberOfAvailableBooks = 0,
                    OpeningHours = "09:30 to 22:30"
                }
            };


            context.Branches.AddRange(listOfbranches);
            context.SaveChanges();

            #endregion

            #region Adding_Books
            var ListOfBooks = new List<Book>
            {
                new Book
                {
                    Name = "BookName1",
                    PublishedYear = 2020,
                    Availability = true,
                    BranchId = listOfbranches[0].BranchId
                },
                new Book
                {
                    Name = "BookName2",
                    PublishedYear = 2018,
                    Availability = false,
                    BranchId = listOfbranches[1].BranchId
                },
                new Book
                {
                    Name = "BookName3",
                    PublishedYear = 2022,
                    Availability = true,
                    BranchId = listOfbranches[2].BranchId
                },
                new Book
                {
                    Name = "BookName4",
                    PublishedYear = 2015,
                    Availability = true,
                    BranchId = listOfbranches[0].BranchId
                },
                new Book
                {
                    Name = "BookName5",
                    PublishedYear = 2019,
                    Availability = false,
                    BranchId = listOfbranches[1].BranchId
                },
                new Book
                {
                    Name = "BookName6",
                    PublishedYear = 2021,
                    Availability = true,
                    BranchId = listOfbranches[2].BranchId
                },
                new Book
                {
                    Name = "BookName7",
                    PublishedYear = 2017,
                    Availability = true,
                    BranchId = listOfbranches[0].BranchId
                },
                new Book
                {
                    Name = "BookName8",
                    PublishedYear = 2023,
                    Availability = true,
                    BranchId = listOfbranches[1].BranchId
                },
                new Book
                {
                    Name = "BookName9",
                    PublishedYear = 2016,
                    Availability = false,
                    BranchId = listOfbranches[2].BranchId
                },
                new Book
                {
                    Name = "BookName10",
                    PublishedYear = 2020,
                    Availability = true,
                    BranchId = listOfbranches[0].BranchId
                }
            };

            context.Books.AddRange(ListOfBooks);
            context.SaveChanges();

            #endregion
        }


    }
}
