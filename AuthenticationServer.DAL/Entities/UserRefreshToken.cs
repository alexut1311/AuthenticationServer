using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationServer.DAL.Entities
{
   public class UserRefreshToken
   {
      [Key]
      public int Id { get; set; }
      [Required]
      public string RefreshToken { get; set; }
      [ForeignKey("ApplicationUser")]
      public int UserId { get; set; }
      public ApplicationUser ApplicationUser { get; set; }
      [Required]
      public DateTime ExpirationDate { get; set; }
   }
}
