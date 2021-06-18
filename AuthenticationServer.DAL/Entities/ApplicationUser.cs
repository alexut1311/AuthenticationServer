using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationServer.DAL.Entities
{
   public class ApplicationUser
   {
      [Key]
      public int UserId { get; set; }
      [Required]
      public string FirstName { get; set; }
      [Required]
      public string LastName { get; set; }
      [Required]
      public string Username { get; set; }
      [Required]
      public string Email { get; set; }
      [Required]
      public string Password { get; set; }
      [Required]
      public string UserBucketName { get; set; }
      [ForeignKey("ApplicationRole")]
      public int RoleId { get; set; }
      public ApplicationRole ApplicationRole { get; set; }
      public virtual ICollection<UserRefreshToken> Tokens { get; set; }
   }
}
