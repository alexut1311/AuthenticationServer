using AuthenticationServer.DAL.Entities;
using AuthenticationServer.DAL.Repositories.Interfaces;
using AuthenticationServer.TL.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AuthenticationServer.DAL.Repositories.Classes
{
   public class UserRepository : IUserRepository
   {
      private readonly ApplicationDBContext _applicationDBContext;
      public UserRepository(ApplicationDBContext applicationDBContext)
      {
         _applicationDBContext = applicationDBContext;
      }

      public void AddUser(ApplicationUserDTO applicationUserDTO)
      {
         ApplicationUser newUser = new ApplicationUser
         {
            FirstName = applicationUserDTO.FirstName,
            LastName = applicationUserDTO.LastName,
            Username = applicationUserDTO.Username,
            Email = applicationUserDTO.Email,
            Password = applicationUserDTO.Password,
            RoleId = applicationUserDTO.RoleId,
         };
         _applicationDBContext.Users.Add(newUser);
         _applicationDBContext.SaveChanges();
      }

      public ApplicationUserDTO GetUserByEmail(string email)
      {
         ApplicationUser userFromDb = _applicationDBContext.Users.Include(x => x.ApplicationRole).FirstOrDefault(x => x.Email == email);
         if (userFromDb == null)
         {
            return null;
         }
         return new ApplicationUserDTO
         {
            UserId = userFromDb.UserId,
            FirstName = userFromDb.FirstName,
            LastName = userFromDb.LastName,
            Username = userFromDb.Username,
            Email = userFromDb.Email,
            Password = userFromDb.Password,
            RoleId = userFromDb.RoleId,
            RoleName = userFromDb.ApplicationRole.RoleName
         };
      }

      public ApplicationUserDTO GetUserByUsername(string username)
      {
         ApplicationUser userFromDb = _applicationDBContext.Users.Include(x => x.ApplicationRole).FirstOrDefault(x => x.Username == username);
         if (userFromDb == null)
         {
            return null;
         }
         return new ApplicationUserDTO
         {
            UserId = userFromDb.UserId,
            FirstName = userFromDb.FirstName,
            LastName = userFromDb.LastName,
            Username = userFromDb.Username,
            Email = userFromDb.Email,
            Password = userFromDb.Password,
            RoleId = userFromDb.RoleId,
            RoleName = userFromDb.ApplicationRole.RoleName
         };
      }
   }
}
