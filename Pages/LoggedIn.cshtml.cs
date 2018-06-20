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
    public class LoggedInModel : PageModel
    {
        private readonly mobisolProject.Models.MobiDBContext _context;

        public LoggedInModel(mobisolProject.Models.MobiDBContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers {get; set;}

        public async Task OnGetAsync(string username, string password)
        {
            // var  items = _context.Customer.Where(t => t.Username == username);
            Customers = await _context.Customer.ToListAsync();
            // return Page();
        }


        

        // public async Task<IActionResult> OnPostAsync(string username, string password)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }
        //     var  items = _context.Customer.Where(t => t.Username == username);
        //     Customers = await items.ToListAsync();
        //     await _context.SaveChangesAsync();

        //     return RedirectToPage("./LoggedIn");
        // }


    }
}