using AuthenticationServer.TL.DTOs;
using System;
using System.Collections.Generic;

namespace AuthenticationServer.DAL.Repositories.Interfaces
{
   public interface IUserRepository
   {
      ApplicationUserDTO GetUserByUsername(string username);
      ApplicationUserDTO GetUserByEmail(string email);
      void AddUser(ApplicationUserDTO applicationUserDTO);
      void SaveUserRefreshToken(int userId, string refreshToken, DateTime expirationDate);
      ApplicationUserDTO GetUserByRefreshToken(string refreshToken);
      List<UserRefreshTokenDTO> GetAllUserRefreshTokens();
      void RemoveUserRefreshToken(UserRefreshTokenDTO token);
   }
}
