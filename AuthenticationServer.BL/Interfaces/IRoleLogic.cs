using AuthenticationServer.TL.DTOs;

namespace AuthenticationServer.BL.Interfaces
{
   public interface IRoleLogic
   {
      ApplicationRoleDTO GetRoleByName(string roleName);
   }
}
