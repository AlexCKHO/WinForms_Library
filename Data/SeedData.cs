using EI_Task.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Data
{
    public class SeedData
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<LibraryDbContext>();
            var userManager = serviceProvider.GetRequiredService<IUserManagerService>();

            if (context.Accounts.Any())
            {
                context.Accounts.RemoveRange(context.Accounts);
                context.Books.RemoveRange(context.Books);
                context.Branches.RemoveRange(context.Branches);
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

            }




        }


        }
}
