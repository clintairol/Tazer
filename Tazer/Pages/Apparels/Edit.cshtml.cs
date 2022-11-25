using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tazer.Data;
using Tazer.Models;

namespace Tazer.Pages.Apparels
{
    public class EditModel : PageModel
    {
        private readonly Tazer.Data.TazerContext _context;

        public EditModel(Tazer.Data.TazerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tees Tees { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tees == null)
            {
                return NotFound();
            }

            var tees =  await _context.Tees.FirstOrDefaultAsync(m => m.ID == id);
            if (tees == null)
            {
                return NotFound();
            }
            Tees = tees;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeesExists(Tees.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TeesExists(int id)
        {
          return _context.Tees.Any(e => e.ID == id);
        }
    }
}
