using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnsecureWebApp.ViewModel;
using UnsecureWebApp.Infrastructure.Database;
using UnsecureWebApp.Infrastructure.Domain.Entities;

namespace UnsecureWebApp.Pages
{
    public class LaptopsModel : PageModel
    {
        private readonly ILogger<LaptopsModel> FLogger;
        private readonly DatabaseContext FDataBase;

        [BindProperty]
        public List<Laptop> Form { get; set; }

        public LaptopsModel(ILogger<LaptopsModel> ALogger, DatabaseContext ADataBase)
        {
            FLogger   = ALogger;
            FDataBase = ADataBase;
        }

        public async Task<IActionResult> OnGetAsync(string Brand)
        {
            Form = new List<Laptop>();

            if (!string.IsNullOrEmpty(Brand))
            {
                var Laptops = await ReturnLaptopsAsync(Brand);                              
                
                foreach (var Laptop in Laptops) 
                {
                    var LaptopData = new Laptop()
                    {
                        Brand    = Laptop.Brand,
                        SerialNo = Laptop.SerialNo,
                        Userid   = Laptop.UserId
                    };

                    Form.Add(LaptopData);              
                }           
            }

            return Page();
        }

        /// <summary>
        /// Example of SQL Injection vulnerability. Never use such code!
        /// </summary>
        /// <param name="ABrand"></param>
        /// <returns></returns>
        private async Task<List<Laptops>> ReturnLaptopsAsync(string ABrand) 
        {
            var Data = await FDataBase.Laptops
                .FromSqlRaw("SELECT Id, Brand, SerialNo, UserId FROM Laptops WHERE Brand = '" + ABrand + "'")
                .ToListAsync();
            return Data;
        }
    }
}
