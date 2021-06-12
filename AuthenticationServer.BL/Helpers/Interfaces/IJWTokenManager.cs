using AuthenticationServer.TL.DTOs;

namespace AuthenticationServer.BL.Helpers.Interfaces
{
   public interface IJWTokenManager
   {
      string GenerateJWToken(ApplicationUserDTO userDTO);
   }
}
