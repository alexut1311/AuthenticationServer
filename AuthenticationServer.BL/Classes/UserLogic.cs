using AuthenticationServer.BL.Helpers.Interfaces;
using AuthenticationServer.BL.Interfaces;
using AuthenticationServer.DAL.Repositories.Interfaces;
using AuthenticationServer.TL.DTOs;
using AuthenticationServer.TL.Helper;
using AuthenticationServer.TL.Helper.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthenticationServer.BL.Classes
{
   public class UserLogic : IUserLogic
   {
      private readonly IUserRepository _userRepository;
      private readonly IJWTokenManager _jWTokenManager;

      public UserLogic(IUserRepository userRepository, IJWTokenManager jWTokenManager)
      {
         _userRepository = userRepository;
         _jWTokenManager = jWTokenManager;
      }

      public ApplicationUserDTO GetUserByUsername(string username)
      {
         return _userRepository.GetUserByUsername(username);
      }

      public ApplicationResult AuthenticateUser(ApplicationUserDTO applicationUserDTO, string password)
      {
         if (applicationUserDTO == null)
         {
            return new ApplicationResult
            {
               IsCompletedSuccesfully = false,
               StatusCode = 404,
               Message = "User not found.",
            };
         }

         if (applicationUserDTO.Password != password)
         {
            return new ApplicationResult
            {
               IsCompletedSuccesfully = false,
               StatusCode = 401,
               Message = "Incorrect username or password.",
            };
         }

         applicationUserDTO.RefreshToken = Guid.NewGuid().ToString();
         DateTime expirationDate = DateTime.Now.AddDays(1);
         _userRepository.SaveUserRefreshToken(applicationUserDTO.UserId, applicationUserDTO.RefreshToken, expirationDate);

         return new ApplicationResult
         {
            IsCompletedSuccesfully = true,
            StatusCode = 200,
            Message = _jWTokenManager.GenerateJWToken(applicationUserDTO),
         };
      }

      public ApplicationUserDTO GetUserByEmail(string email)
      {
         return _userRepository.GetUserByEmail(email);
      }

      public void AddUser(ApplicationUserDTO applicationUserDTO)
      {
         _userRepository.AddUser(applicationUserDTO);
      }

      public ApplicationUserDTO GetUserByRefreshToken(string refreshToken)
      {
         ApplicationUserDTO userDto = _userRepository.GetUserByRefreshToken(refreshToken);
         if (userDto == null)
         {
            return null;
         }

         if (!ClassHelper.CheckValidDate(userDto.Tokens.FirstOrDefault(x => x.RefreshToken == refreshToken).ExpirationDate))
         {
            return null;
         }

         return userDto;
      }

      public void ValidateUserRefreshTokens()
      {
         List<UserRefreshTokenDTO> userRefreshTokens = _userRepository.GetAllUserRefreshTokens();
         foreach (UserRefreshTokenDTO token in userRefreshTokens)
         {
            if (!ClassHelper.CheckValidDate(token.ExpirationDate))
            {
               _userRepository.RemoveUserRefreshToken(token);
            }
         }
      }
   }
}
