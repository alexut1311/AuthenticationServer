using AuthenticationServer.BL.Interfaces;
using AuthenticationServer.Helpers.ControllerHelpers.Interfaces;
using AuthenticationServer.TL.DTOs;
using AuthenticationServer.TL.Helper;
using System.Text.RegularExpressions;

namespace AuthenticationServer.Helpers.ControllerHelpers.Classes
{
   public class AuthenticationControllerHelper : IAuthenticationControllerHelper
   {
      private readonly IRoleLogic _roleLogic;
      private readonly IUserLogic _userLogic;

      public AuthenticationControllerHelper(IRoleLogic roleLogic, IUserLogic userLogic)
      {
         _roleLogic = roleLogic;
         _userLogic = userLogic;
      }

      public ApplicationResult ValidateDTO(ref ApplicationUserDTO applicationUserDTO)
      {

         if (string.IsNullOrWhiteSpace(applicationUserDTO.FirstName))
         {
            return new ApplicationResult { IsCompletedSuccesfully = false, Message = "Invalid first name." };
         }

         if (string.IsNullOrWhiteSpace(applicationUserDTO.LastName))
         {
            return new ApplicationResult { IsCompletedSuccesfully = false, Message = "Invalid last name." };
         }

         if (string.IsNullOrWhiteSpace(applicationUserDTO.Username))
         {
            return new ApplicationResult { IsCompletedSuccesfully = false, Message = "Invalid username." };
         }
         else
         {
            ApplicationUserDTO userFromDb = _userLogic.GetUserByUsername(applicationUserDTO.Username);
            if (userFromDb != null)
            {
               return new ApplicationResult { IsCompletedSuccesfully = false, Message = "A user with the same username already exists." };
            }
         }

         if (string.IsNullOrWhiteSpace(applicationUserDTO.Password))
         {
            return new ApplicationResult { IsCompletedSuccesfully = false, Message = "Invalid password." };
         }

         if (string.IsNullOrWhiteSpace(applicationUserDTO.Email))
         {
            return new ApplicationResult { IsCompletedSuccesfully = false, Message = "Invalid email." };
         }
         else
         {
            bool isEmail = Regex.IsMatch(applicationUserDTO.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
               return new ApplicationResult { IsCompletedSuccesfully = false, Message = "Incorrect format for email." };
            }
            else
            {
               ApplicationUserDTO userFromDb = _userLogic.GetUserByEmail(applicationUserDTO.Email);
               if (userFromDb != null)
               {
                  return new ApplicationResult { IsCompletedSuccesfully = false, Message = "A user with the same email already exists." };
               }
            }
         }

         if (string.IsNullOrWhiteSpace(applicationUserDTO.RoleName))
         {
            return new ApplicationResult { IsCompletedSuccesfully = false, Message = "Invalid rolename." };
         }
         else
         {
            ApplicationRoleDTO roleFromDb = _roleLogic.GetRoleByName(applicationUserDTO.RoleName);
            if (roleFromDb == null)
            {
               return new ApplicationResult { IsCompletedSuccesfully = false, Message = "Role does not exists." };
            }
            else
            {
               applicationUserDTO.RoleId = roleFromDb.RoleId;
               applicationUserDTO.RoleName = roleFromDb.RoleName;
            }
         }

         return new ApplicationResult { IsCompletedSuccesfully = true, Message = "Success." };
      }
   }
}
