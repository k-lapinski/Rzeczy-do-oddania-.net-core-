using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using rzeczy_do_oddaniaNEW.Data;
using rzeczy_do_oddaniaNEW.Pages.Models;

namespace rzeczy_do_oddaniaNEW.Pages.Items
{
    public class DetailsModel : PageModel
    {
        private readonly rzeczy_do_oddaniaNEW.Data.ApplicationDbContext _context;

        public DetailsModel(rzeczy_do_oddaniaNEW.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Item Item { get; set; } = default!;
        public List<Category> Category { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }


           


            var item = await _context.Item.FirstOrDefaultAsync(m => m.ItemId == id);
            this.Category = (from c in _context.Categories where c.CategoryId == item.CategoryFk select c).ToList();
            if (item == null)
            {
                return NotFound();
            }
            else 
            {   
                Item = item;
                Item.Category = Category[0];
             
              
            }
            return Page();
        }
    }
}
