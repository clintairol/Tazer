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
    public class IndexModel : PageModel
    {
        private readonly Tazer.Data.TazerContext _context;

        public IndexModel(Tazer.Data.TazerContext context)
        {
            _context = context;
        }
        public IList<Tees> Tees { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Brand { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ApparelBrand { get; set; }


        public async Task OnGetAsync()
        {
            var apparels = from t in _context.Tees select t;

            if (!string.IsNullOrEmpty(SearchString))
            {
                apparels = apparels.Where(b => b.Brand.Contains(SearchString));
            }
            Tees = await apparels.ToListAsync();

        }
    }
}
