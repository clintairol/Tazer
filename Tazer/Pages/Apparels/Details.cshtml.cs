using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tazer.Data;
using Tazer.Models;

namespace Tazer.Pages.Apparels
{
    public class DetailsModel : PageModel
    {
        private readonly Tazer.Data.TazerContext _context;

        public DetailsModel(Tazer.Data.TazerContext context)
        {
            _context = context;
        }

      public Tees Tees { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tees == null)
            {
                return NotFound();
            }

            var tees = await _context.Tees.FirstOrDefaultAsync(m => m.ID == id);
            if (tees == null)
            {
                return NotFound();
            }
            else 
            {
                Tees = tees;
            }
            return Page();
        }
    }
}
