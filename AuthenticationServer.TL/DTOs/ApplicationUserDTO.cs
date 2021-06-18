using System.Collections.Generic;

namespace AuthenticationServer.TL.DTOs
{
   public class ApplicationUserDTO
   {
      public int UserId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Username { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
      public int RoleId { get; set; }
      public string RoleName { get; set; }
      public string RefreshToken { get; set; }
      public string UserBucketName { get; set; }
      public IEnumerable<UserRefreshTokenDTO> Tokens { get; set; }

   }
}
