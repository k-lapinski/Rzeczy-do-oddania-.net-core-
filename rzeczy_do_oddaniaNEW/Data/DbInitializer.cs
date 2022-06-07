using rzeczy_do_oddaniaNEW.Pages.Models;

namespace rzeczy_do_oddaniaNEW.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Item.Any())
            {
                return;   // DB has been seeded
            }

            var items = new Item[] 
            {   
                new Item() {Title = "spodnie bojówki", Description = "fajne spodnie", Address = "test11", ReleaseDate=DateTime.Parse("2022-09-01"), Category = "test11", Image = "1.jpg"},
                new Item() {Title = "miecz dobrze naostrzony", Description = "naprawdę ostry miecz", Address = "test22", ReleaseDate=DateTime.Parse("2022-09-01"), Category = "test22", Image = "2.jpg"},
                new Item() {Title = "długie buty", Description = "długie buty dobre na zime", Address = "test33", ReleaseDate=DateTime.Parse("2022-09-01"), Category = "test33", Image = "3.jpg" },
                new Item() {Title = "konto metin2", Description = "woj body oddam za darmo, nie gram już xD", Address = "test44", ReleaseDate=DateTime.Parse("2022-09-01"), Category = "test44", Image = "4.jpg" },
                new Item() {Title = "kosiarka", Description = "kosiarka spalinowa za darmo, odbiór osobisty", Address = "test55", ReleaseDate=DateTime.Parse("2022-09-01"), Category = "test55", Image = "5.jpg" },
                new Item() {Title = "regał", Description = "fajny regał na książki z ikea", Address = "test66", ReleaseDate=DateTime.Parse("2022-09-01"), Category = "test66", Image = "6.jpg" },

            };
            foreach (Item s in items)
            {
                context.Item.Add(s);
            }
            context.SaveChanges();

        }
    }
}
