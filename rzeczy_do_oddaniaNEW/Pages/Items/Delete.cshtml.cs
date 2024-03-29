﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rzeczy_do_oddaniaNEW.Data;
using rzeczy_do_oddaniaNEW.Pages.Models;

namespace rzeczy_do_oddaniaNEW.Pages.Items
{
    public class DeleteModel : PageModel
    {
        private readonly rzeczy_do_oddaniaNEW.Data.ApplicationDbContext _context;

        public DeleteModel(rzeczy_do_oddaniaNEW.Data.ApplicationDbContext context)
        {
            _context = context;
        }
       
        [BindProperty]
      public Item Item { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FirstOrDefaultAsync(m => m.ItemId == id);

            if (item == null)
            {
                return NotFound();
            }
            else 
            {
                Item = item;
            }
            return Page();
        }

    
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var OwnerID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);



            if (id == null || _context.Item == null)
            {
                return NotFound();
            }
            var item = await _context.Item.FindAsync(id);

            if (item != null)
            {
                Item = item;

                if (OwnerID == Item.userID) { 

                _context.Item.Remove(Item);
                }

                else { return NotFound(); }

                await _context.SaveChangesAsync();
            }

           
            return RedirectToPage("./Index");
        }
    }
}
