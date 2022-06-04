using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rzeczy_do_oddaniaNEW.Pages.Models;

namespace rzeczy_do_oddaniaNEW.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {   
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<rzeczy_do_oddaniaNEW.Pages.Models.Item>? Item { get; set; }
        public DbSet<rzeczy_do_oddaniaNEW.Pages.Models.ApplicationUser>? applicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //dodajemy parę kluczy do tabeli pośredniczącej do relacjimany to many

            builder.Entity<Reservation>()
            .HasKey(pg => new { pg.ItemId, pg.UsersID });
            //w tabeli posredniczacej PersonGroup
            builder.Entity<Reservation>()
            .HasOne<Item>(pg => pg.Item) // dla jednej osoby
            .WithMany(p => p.Reservations) // jest wiele PersonGroups
            .HasForeignKey(p => p.ItemId); // a powizanie jestrealizowane przez klucz obcy PersonId

            //w tabeli posredniczacej PersonGroup
            builder.Entity<Reservation>()
            .HasOne<ApplicationUser>(pg => pg.User) // dla jednej grupy
            .WithMany(g => g.Reservations) // jest wiele PersonGroups
            .HasForeignKey(g => g.UsersID); // a powizanie jestrealizowane przez klucz obcy GroupId

        }
        public DbSet<rzeczy_do_oddaniaNEW.Pages.Models.Reservation>? Reservation { get; set; }




    }
}