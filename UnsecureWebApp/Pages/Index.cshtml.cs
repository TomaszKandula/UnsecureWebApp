using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnsecureWebApp.Models;
using UnsecureWebApp.Infrastructure.Database;

namespace UnsecureWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> FLogger;
        private readonly DatabaseContext FDataBase;

        [BindProperty]
        public User Form { get; set; }

        public IndexModel(ILogger<IndexModel> ALogger, DatabaseContext ADataBase)
        {
            FLogger   = ALogger;
            FDataBase = ADataBase;
        }

        public IActionResult OnGet()
        {
            ViewData["Info"] = "Please provide credentials.";
            return Page();
        }

        public IActionResult OnPost(User Form) 
        {
            if (ModelState.IsValid)
            {
                if (IsUserAuthenticated(Form.UserEmail, Form.UserPassword))
                {
                    ViewData["Info"] = "Validated.";
                }
                else
                {
                    ViewData["Info"] = "Incorrect login/password.";
                }
            }
            else
            {
                ViewData["Info"] = "Model is invalid.";
            }

            return Page();
        }

        /// <summary>
        /// Example of SQL Injection vulnerability. Never use such code!
        /// </summary>
        /// <param name="AEmail"></param>
        /// <param name="APassword"></param>
        /// <returns></returns>
        private bool IsUserAuthenticated(string AEmail, string APassword) 
        {
            var Result = FDataBase.Users
                .FromSqlRaw("SELECT Id FROM dbo.Users WHERE EmailAddress = '" + AEmail + "' AND HashedPassword = '" + APassword + "'");

            return Result.Any();
        }
    }
}
