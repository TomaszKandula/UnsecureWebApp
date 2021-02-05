using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnsecureWebApp.Model.Database;
using UnsecureWebApp.Model.FormData;

namespace UnsecureWebApp.Pages
{
    public class LaptopsModel : PageModel
    {
        private readonly ILogger<LaptopsModel> FLogger;
        private readonly DbModel FDataBase;

        [BindProperty]
        public List<LaptopData> Form { get; set; }

        public LaptopsModel(ILogger<LaptopsModel> ALogger, DbModel ADataBase)
        {
            FLogger   = ALogger;
            FDataBase = ADataBase;
        }

        public async Task<IActionResult> OnGetAsync(string Brand)
        {
            Form = new List<LaptopData>();

            if (!string.IsNullOrEmpty(Brand))
            {
                var Laptops = await ReturnLaptopsAsync(Brand);                              
                
                foreach (var Laptop in Laptops) 
                {
                    var LaptopData = new LaptopData()
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
            var Data = await FDataBase.Laptops.FromSqlRaw("SELECT Id, Brand, SerialNo, UserId FROM Laptops WHERE Brand = '" + ABrand + "'").ToListAsync();
            return Data;
        }
    }
}
