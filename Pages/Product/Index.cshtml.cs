using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mobisolProject.Models;

namespace mobisolProject.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly mobisolProject.Models.MobiDBContext _context;

        public IndexModel(mobisolProject.Models.MobiDBContext context)
        {
            _context = context;
        }

        public IList<Products> Products { get;set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }
    }
}
