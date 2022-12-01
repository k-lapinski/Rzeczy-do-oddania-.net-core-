using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rzeczy_do_oddaniaNEW.Data;
using rzeczy_do_oddaniaNEW.Pages.Models;

namespace rzeczy_do_oddaniaNEW.Pages.Owner
{
    public class IndexModel : PageModel
    {
        private readonly rzeczy_do_oddaniaNEW.Data.ApplicationDbContext _context;

        public IndexModel(rzeczy_do_oddaniaNEW.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; } = default!;
        public List<Category> Category { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Item != null)
            {
                

                Item = await _context.Item.ToListAsync();
               
                foreach (var item in Item)
                {
                    this.Category = (from c in _context.Categories where c.CategoryId == item.CategoryFk select c).ToList();
                    item.Category = Category[0];
                    Category.Remove(Category[0]);
                }
            }
        }
    }
}
