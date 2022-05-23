using System.ComponentModel.DataAnnotations;

namespace rzeczy_do_oddaniaNEW.Pages.Models
{
    public class Item
    {   [Key]
        public int ID { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; } = string.Empty;
        [Display(Name = "Opis")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Adres")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Data zakończenia")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Kategoria")]
        public string Category { get; set; } = string.Empty;
        [Display(Name = "Zdjęcie")]
        public string Image { get; set; } = string.Empty;

        public string userID { get; set; } = string.Empty;
    }
}
