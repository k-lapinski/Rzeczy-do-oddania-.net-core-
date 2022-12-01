using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using rzeczy_do_oddaniaNEW.Data;
using rzeczy_do_oddaniaNEW.Pages.Models;

namespace rzeczy_do_oddaniaNEW.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly rzeczy_do_oddaniaNEW.Data.ApplicationDbContext _context;

        public CreateModel(rzeczy_do_oddaniaNEW.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; } = default!;
        [BindProperty]
        public Category Category { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if ( _context.Item == null || Item == null || _context.Categories == null || Category == null)
            {
                return Page();
            }

     
            _context.Categories.Add(Category);
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
            Item.userID = userId;
            Item.Category = Category;
            _context.Item.Add(Item);
           

        
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


       

    }
}
