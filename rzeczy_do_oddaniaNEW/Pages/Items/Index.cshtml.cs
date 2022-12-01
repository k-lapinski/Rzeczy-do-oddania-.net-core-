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
        public List<Category> Category { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ItemCategory { get; set; }


       
        public async Task OnGetAsync()
        {
           

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Item
                                            orderby m.Category.CategoryName
                                            select m.Category.CategoryName;

            var items = from m in _context.Item
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                items = items.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ItemCategory))
            {
                items = items.Where(x => x.Category.CategoryName == ItemCategory);

            }
            Categories = new SelectList(await genreQuery.Distinct().ToListAsync());
            
            Item = await items.ToListAsync();

            foreach (var item in Item)
            {
                this.Category = (from c in _context.Categories where c.CategoryId == item.CategoryFk select c).ToList();
                item.Category = Category[0];
                Category.Remove(Category[0]);
            }

        }


        public async Task OnPostAsync(int valuebtn)
        {

            Item = await _context.Item.ToListAsync();

           


            foreach (Item c in Item)
            {

                if (c.ItemId == valuebtn)
                {
                    c.Reservation = User.FindFirstValue(ClaimTypes.Email);
                }
                await _context.SaveChangesAsync();
            }

          
        }

    }
}
