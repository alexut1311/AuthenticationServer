using AuthenticationServer.BL.Interfaces;
using AuthenticationServer.DAL.Repositories.Interfaces;
using AuthenticationServer.TL.DTOs;

namespace AuthenticationServer.BL.Classes
{
   public class RoleLogic : IRoleLogic
   {
      private readonly IRoleRepository _roleRepository;

      public RoleLogic(IRoleRepository roleRepository)
      {
         _roleRepository = roleRepository;
      }

      public ApplicationRoleDTO GetRoleByName(string roleName)
      {
         return _roleRepository.GetRoleByName(roleName);
      }
   }
}
