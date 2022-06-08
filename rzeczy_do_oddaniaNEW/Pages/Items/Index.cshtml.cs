using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rzeczy_do_oddaniaNEW.Data;
using rzeczy_do_oddaniaNEW.Pages.Models;

namespace rzeczy_do_oddaniaNEW.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly rzeczy_do_oddaniaNEW.Data.ApplicationDbContext _context;

        public IndexModel(rzeczy_do_oddaniaNEW.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ItemCategory { get; set; }


       
        public async Task OnGetAsync()
        {
           

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Item
                                            orderby m.Category
                                            select m.Category;

            var items = from m in _context.Item
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                items = items.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ItemCategory))
            {
                items = items.Where(x => x.Category == ItemCategory);

            }
            Categories = new SelectList(await genreQuery.Distinct().ToListAsync());
            
            Item = await items.ToListAsync();
        }


        public async Task OnPostAsync(int id)
        {
            
            Item = await _context.Item.ToListAsync();



            foreach (var item in Item)
            {

                // if (item.ID == id) { 
                item.Reservation = User.FindFirstValue(ClaimTypes.Email);
                //  }
               

            }

            await _context.SaveChangesAsync();
        }

    }
}
