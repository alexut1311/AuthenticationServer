using AuthenticationServer.TL.DTOs;

namespace AuthenticationServer.DAL.Repositories.Interfaces
{
   public interface IRoleRepository
   {
      ApplicationRoleDTO GetRoleByName(string roleName);
   }
}
