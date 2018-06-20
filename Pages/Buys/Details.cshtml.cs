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
    public class DetailsModel : PageModel
    {
        private readonly mobisolProject.Models.MobiDBContext _context;

        public DetailsModel(mobisolProject.Models.MobiDBContext context)
        {
            _context = context;
        }

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
    }
}
