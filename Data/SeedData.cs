using EI_Task.Models;
using EI_Task.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

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

            var account1 = new Account();
            account1.Email = "testing1@testing.com";
            account1.Password = "password";

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


            context.Accounts.AddRange(account1,account2,account3);
            context.Users.AddRange(user1, user2, user3);

            context.SaveChanges();

            user1.AccountId = account1.AccountId;
            account1.UserId = user1.UserId;

            user2.AccountId = account2.AccountId;
            account2.UserId = user2.UserId;

            user3.AccountId = account3.AccountId;
            account3.UserId = user3.UserId;

            context.SaveChanges();
        }


        }
}
