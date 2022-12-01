using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rzeczy_do_oddaniaNEW.Pages.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }
       
      
        public ICollection<Item> Items { get; set; }
    }
}
