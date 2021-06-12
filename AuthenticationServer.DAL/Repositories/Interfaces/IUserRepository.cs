using AuthenticationServer.TL.DTOs;

namespace AuthenticationServer.DAL.Repositories.Interfaces
{
   public interface IUserRepository
   {
      ApplicationUserDTO GetUserByUsername(string username);
      ApplicationUserDTO GetUserByEmail(string email);
      void AddUser(ApplicationUserDTO applicationUserDTO);
   }
}
