using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tazer.Data;
using Tazer.Models;

namespace Tazer.Pages.Apparels
{
    public class CreateModel : PageModel
    {
        private readonly Tazer.Data.TazerContext _context;

        public CreateModel(Tazer.Data.TazerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tees Tees { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tees.Add(Tees);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
