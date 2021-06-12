using AuthenticationServer.TL.DTOs;
using AuthenticationServer.TL.Helper;

namespace AuthenticationServer.BL.Interfaces
{
   public interface IUserLogic
   {
      ApplicationUserDTO GetUserByUsername(string username);
      ApplicationResult AuthenticateUser(ApplicationUserDTO applicationUserDTO, string password);
      ApplicationUserDTO GetUserByEmail(string email);
      void AddUser(ApplicationUserDTO applicationUserDTO);
   }
}
