using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mobisolProject.Models;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace mobisolProject.Pages
{
    public class LoggedInModel : PageModel
    {
        private readonly mobisolProject.Models.MobiDBContext _context;

        public LoggedInModel(mobisolProject.Models.MobiDBContext context)
        {
            _context = context;
        }
        
        public Customer Customers {get; set;}

        public async Task OnGetAsync(Customer customer)
        {  
            Console.WriteLine(customer.Username);
            Customers = customer;
        }

        public async Task<IActionResult> OnPostAsync()
        {
        await HttpContext.SignOutAsync();
        return RedirectToPage("./Login");
        }

    }
}