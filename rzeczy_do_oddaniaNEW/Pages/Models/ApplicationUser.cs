using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace rzeczy_do_oddaniaNEW.Pages.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }

    }
}
