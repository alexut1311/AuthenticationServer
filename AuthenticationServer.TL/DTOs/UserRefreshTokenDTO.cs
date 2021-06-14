using System;

namespace AuthenticationServer.TL.DTOs
{
   public class UserRefreshTokenDTO
   {
      public int Id { get; set; }
      public string RefreshToken { get; set; }
      public int UserId { get; set; }
      public DateTime ExpirationDate { get; set; }
   }
}
