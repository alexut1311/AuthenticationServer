using AuthenticationServer.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer.DAL
{
   public class ApplicationDBContext : DbContext
   {
      public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
      {
      }

      public DbSet<ApplicationUser> Users { get; set; }
      public DbSet<ApplicationRole> Roles { get; set; }
   }
}
