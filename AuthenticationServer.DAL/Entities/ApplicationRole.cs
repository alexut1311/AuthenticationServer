using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationServer.DAL.Entities
{
   public class ApplicationRole
   {
      [Key]
      public int Id { get; set; }
      [Required]
      public string RoleName { get; set; }
      public virtual ICollection<ApplicationUser> Users { get; set; }
   }
}
