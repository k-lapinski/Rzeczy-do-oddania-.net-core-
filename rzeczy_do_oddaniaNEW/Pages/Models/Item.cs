using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace rzeczy_do_oddaniaNEW.Pages.Models
{
    public class Item
    {   [Key]
        public int ID { get; set; }
        [Display(Name = "Title")]
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Display(Name = "Description")]
        [Required]
        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Address")]
        [Required]
        [MaxLength(300)]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "End day")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Category")]
        public string Category { get; set; } = string.Empty;
        [Display(Name = "Photo")]
        [MaxLength(300)]
        public string Image { get; set; } = string.Empty;

        public string userID { get; set; } = string.Empty;

        public string Reservation { get; set; } = string.Empty; 

    }
}
