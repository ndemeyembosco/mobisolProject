using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mobisolProject.Models;

namespace mobisolProject.Pages
{
    public class LoginModel : PageModel
    {
        private readonly mobisolProject.Models.MobiDBContext _context;

        public LoginModel(mobisolProject.Models.MobiDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IList<Customer> Customers {get; set;}

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var customers = from i in _context.Customer select i;
            Console.WriteLine(String.IsNullOrEmpty(password));
            Console.WriteLine(username);
            if (!String.IsNullOrEmpty(password))
            {
                customers = customers.Where(s => s.Password.Equals(password));
            
            }

            Customers = await customers.ToListAsync();
            if (Customers.Count != 0) 
            {
                Console.Write("Customers is not empty");
                Console.Write(username);
                Console.Write(Customer);
                return RedirectToPage("./LoggedIn");
            }else 
            {
                Console.WriteLine("Customers is empty");
                return Page();
            }
            
            }
        }


}
