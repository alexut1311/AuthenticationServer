using AuthenticationServer.BL.Helpers.Interfaces;
using AuthenticationServer.BL.Interfaces;
using AuthenticationServer.DAL.Repositories.Interfaces;
using AuthenticationServer.TL.DTOs;
using AuthenticationServer.TL.Helper;

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
               StatusCode = 404,
               Message = "User not found.",
            };
         }

         if (applicationUserDTO.Password != password)
         {
            return new ApplicationResult
            {
               StatusCode = 401,
               Message = "Incorrect username or password.",
            };
         }

         return new ApplicationResult
         {
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
   }
}
