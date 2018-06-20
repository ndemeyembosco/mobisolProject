using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mobisolProject.Models;

namespace mobisolProject.Pages.Buys
{
    public class DeleteModel : PageModel
    {
        private readonly mobisolProject.Models.MobiDBContext _context;

        public DeleteModel(mobisolProject.Models.MobiDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Buy Buy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Buy = await _context.Buy.SingleOrDefaultAsync(m => m.ID == id);

            if (Buy == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Buy = await _context.Buy.FindAsync(id);

            if (Buy != null)
            {
                _context.Buy.Remove(Buy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
