using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using mobisolProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

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
        public LoginData loginData { get; set; }

        public IList<Customer> customerList {get; set;}


        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            var customers = from c in _context.Customer select c; 
            if (ModelState.IsValid)
            {   
                customers = customers.Where(c => c.Username == loginData.Username && c.Password == loginData.Password);
                customerList = await customers.ToListAsync();

                var isValid = customerList.Count != 0;
                Console.WriteLine(customerList[0].Username);
                if (!isValid)
                {
                ModelState.AddModelError("", "username or password is invalid");
                return Page();
                }
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginData.Username));
                identity.AddClaim(new Claim(ClaimTypes.Name, loginData.Username));
                // Authenticate using the identity
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = loginData.RememberMe });
                Console.WriteLine(customerList[0].Password);
                return RedirectToPage("./LoggedIn", customerList[0]);
            }
            else
            {
            ModelState.AddModelError("", "username or password is blank");
            return Page();
            }
            
            }

        public class LoginData
        {
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        }

        }


        


}
