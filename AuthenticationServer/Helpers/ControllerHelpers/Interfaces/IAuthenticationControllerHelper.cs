using AuthenticationServer.TL.DTOs;
using AuthenticationServer.TL.Helper;

namespace AuthenticationServer.Helpers.ControllerHelpers.Interfaces
{
   public interface IAuthenticationControllerHelper
   {
      ApplicationResult ValidateDTO(ref ApplicationUserDTO applicationUserDTO);
   }
}
