using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace rzeczy_do_oddaniaNEW.Pages.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public ICollection<Reservation>? Reservations { get; set; }

    }
}
