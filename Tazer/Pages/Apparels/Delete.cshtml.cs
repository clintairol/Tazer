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
    public class DeleteModel : PageModel
    {
        private readonly Tazer.Data.TazerContext _context;

        public DeleteModel(Tazer.Data.TazerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tees == null)
            {
                return NotFound();
            }
            var tees = await _context.Tees.FindAsync(id);

            if (tees != null)
            {
                Tees = tees;
                _context.Tees.Remove(Tees);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
