using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnsecureWebApp.Models;
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

            if (string.IsNullOrEmpty(Brand)) 
                return Page();
            
            var LLaptops = await ReturnLaptopsAsync(Brand);                              
                
            foreach (var LLaptopData in LLaptops.Select(ALaptop => new Laptop
            {
                Brand    = ALaptop.Brand,
                SerialNo = ALaptop.SerialNo,
                Userid   = ALaptop.UserId
            }))
            {
                Form.Add(LLaptopData);
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
            var LData = await FDataBase.Laptops
                .FromSqlRaw($"SELECT Id, Brand, SerialNo, UserId FROM Laptops WHERE Brand = '{ABrand}'")
                .ToListAsync();
            return LData;
        }
    }
}
