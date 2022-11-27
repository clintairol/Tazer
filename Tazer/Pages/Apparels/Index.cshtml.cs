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
    public class IndexModel : PageModel
    {
        private readonly Tazer.Data.TazerContext _context;

        public IndexModel(Tazer.Data.TazerContext context)
        {
            _context = context;
        }

        public IList<Tees> Tees { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tees != null)
            {
                Tees = await _context.Tees.ToListAsync();
            }
        }
    }
}
