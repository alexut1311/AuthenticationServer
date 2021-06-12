using AuthenticationServer.DAL.Entities;
using AuthenticationServer.DAL.Repositories.Interfaces;
using AuthenticationServer.TL.DTOs;
using System.Linq;

namespace AuthenticationServer.DAL.Repositories.Classes
{
   public class RoleRepository : IRoleRepository
   {
      private readonly ApplicationDBContext _applicationDBContext;
      public RoleRepository(ApplicationDBContext applicationDBContext)
      {
         _applicationDBContext = applicationDBContext;
      }

      public ApplicationRoleDTO GetRoleByName(string roleName)
      {
         ApplicationRole roleFromDb = _applicationDBContext.Roles.FirstOrDefault(x => x.RoleName == roleName);
         if (roleFromDb == null)
         {
            return null;
         }
         return new ApplicationRoleDTO
         {
            RoleId = roleFromDb.Id,
            RoleName = roleFromDb.RoleName,
         };
      }

   }
}
