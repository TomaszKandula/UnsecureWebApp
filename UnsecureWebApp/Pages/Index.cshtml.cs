using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UnsecureWebApp.Model.Database;
using UnsecureWebApp.Model.FormData;

namespace UnsecureWebApp.Pages
{

    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> FLogger;
        private readonly DbModel FDataBase;

        [BindProperty]
        public UserData Form { get; set; }

        public IndexModel(ILogger<IndexModel> ALogger, DbModel ADataBase)
        {
            FLogger   = ALogger;
            FDataBase = ADataBase;
        }

        public IActionResult OnGet()
        {

            ViewData["Info"] = "Please provide credentials.";

            return Page();

        }

        public IActionResult OnPost(UserData Form) 
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

            var Result = FDataBase.Users.FromSqlRaw("SELECT Id FROM dbo.Users WHERE EmailAddress = '" + AEmail + "' AND HashedPassword = '" + APassword + "'");

            if (Result.Any())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }

}
