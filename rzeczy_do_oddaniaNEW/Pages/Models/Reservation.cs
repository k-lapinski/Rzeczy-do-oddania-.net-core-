using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace rzeczy_do_oddaniaNEW.Pages.Models
{
    public class Reservation
    {

        public int ItemId { get; set; } //klucz obcy do Person
        public Item Item { get; set; }

    
        public string UsersID { get; set; } //klucz obcy do Group
        public ApplicationUser User { get; set; }

    }
}
