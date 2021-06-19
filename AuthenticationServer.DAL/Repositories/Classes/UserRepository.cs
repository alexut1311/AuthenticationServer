using AuthenticationServer.DAL.Entities;
using AuthenticationServer.DAL.Repositories.Interfaces;
using AuthenticationServer.TL.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            UserBucketName = applicationUserDTO.UserBucketName,
         };
         _applicationDBContext.Users.Add(newUser);
         _applicationDBContext.SaveChanges();
      }

      public List<UserRefreshTokenDTO> GetAllUserRefreshTokens()
      {
         List<UserRefreshTokenDTO> userRefreshTokens = _applicationDBContext.RefreshTokens.Select(token => new UserRefreshTokenDTO
         {
            Id = token.Id,
            RefreshToken = token.RefreshToken,
            ExpirationDate = token.ExpirationDate,
            UserId = token.UserId,
         }).ToList();
         return userRefreshTokens;
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

      public ApplicationUserDTO GetUserByRefreshToken(string refreshToken)
      {
         UserRefreshToken userRefreshTokenDb = _applicationDBContext.RefreshTokens.Include(x => x.ApplicationUser).FirstOrDefault(x => x.RefreshToken == refreshToken);
         if (userRefreshTokenDb == null)
         {
            return null;
         }

         if (userRefreshTokenDb.ApplicationUser == null)
         {
            return null;
         }
         ApplicationUserDTO userDto = new ApplicationUserDTO
         {
            UserId = userRefreshTokenDb.ApplicationUser.UserId,
            FirstName = userRefreshTokenDb.ApplicationUser.FirstName,
            LastName = userRefreshTokenDb.ApplicationUser.LastName,
            Username = userRefreshTokenDb.ApplicationUser.Username,
            Email = userRefreshTokenDb.ApplicationUser.Email,
            Password = userRefreshTokenDb.ApplicationUser.Password,
            RoleId = userRefreshTokenDb.ApplicationUser.RoleId,
            UserBucketName = userRefreshTokenDb.ApplicationUser.UserBucketName,
            RoleName = _applicationDBContext.Roles.FirstOrDefault(x => x.Id == userRefreshTokenDb.ApplicationUser.RoleId).RoleName
         };
         UserRefreshTokenDTO userRefreshTokenDto = new UserRefreshTokenDTO
         {
            RefreshToken = userRefreshTokenDb.RefreshToken,
            ExpirationDate = userRefreshTokenDb.ExpirationDate,
            UserId = userRefreshTokenDb.UserId,
            Id = userRefreshTokenDb.Id
         };
         userDto.Tokens = new List<UserRefreshTokenDTO> {
            userRefreshTokenDto
         };
         RemoveUserRefreshToken(userRefreshTokenDto);
         return userDto;
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
            UserBucketName = userFromDb.UserBucketName,
            RoleName = userFromDb.ApplicationRole.RoleName
         };
      }

      public void RemoveUserRefreshToken(UserRefreshTokenDTO token)
      {
         UserRefreshToken userRefreshTokenDb = _applicationDBContext.RefreshTokens.FirstOrDefault(x => x.Id == token.Id);
         if (userRefreshTokenDb != null)
         {
            _applicationDBContext.RefreshTokens.Remove(userRefreshTokenDb);
            _applicationDBContext.SaveChanges();
         }
      }

      public void SaveUserRefreshToken(int userId, string refreshToken, DateTime expirationDate)
      {
         UserRefreshToken newRefreshToken = new UserRefreshToken
         {
            UserId = userId,
            RefreshToken = refreshToken,
            ExpirationDate = expirationDate,
         };
         _applicationDBContext.RefreshTokens.Add(newRefreshToken);
         _applicationDBContext.SaveChanges();
      }
   }
}
