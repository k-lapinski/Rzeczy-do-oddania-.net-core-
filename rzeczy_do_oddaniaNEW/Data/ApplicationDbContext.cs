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
    }
}