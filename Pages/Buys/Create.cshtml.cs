using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using mobisolProject.Models;

namespace mobisolProject.Pages.Buys
{
    public class CreateModel : PageModel
    {
        private readonly mobisolProject.Models.MobiDBContext _context;

        public CreateModel(mobisolProject.Models.MobiDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Buy Buy { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Buy.Add(Buy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}