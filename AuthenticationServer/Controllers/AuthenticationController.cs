using AuthenticationServer.BL.Interfaces;
using AuthenticationServer.Helpers.ControllerHelpers.Interfaces;
using AuthenticationServer.TL.DTOs;
using AuthenticationServer.TL.Helper;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServer.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class AuthenticationController : ControllerBase
   {
      private readonly IUserLogic _userLogic;
      private readonly IAuthenticationControllerHelper _authenticationControllerHelper;

      public AuthenticationController(IUserLogic userLogic, IAuthenticationControllerHelper authenticationControllerHelper)
      {
         _userLogic = userLogic;
         _authenticationControllerHelper = authenticationControllerHelper;
      }

      [HttpGet]
      [Route("Login")]
      public ActionResult UserLogin(string username, string password)
      {
         if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
         {
            return BadRequest("Provide a username or password.");
         }

         ApplicationUserDTO userDTO = _userLogic.GetUserByUsername(username);
         ApplicationResult result = _userLogic.AuthenticateUser(userDTO, password);

         if (result.IsCompletedSuccesfully)
         {
            return Ok(result);
         }

         return StatusCode(result.StatusCode, result.Message);
      }

      [HttpGet]
      [Route("RefreshLogin")]
      public ActionResult UserRefreshLogin(string refreshToken)
      {
         if (string.IsNullOrEmpty(refreshToken))
         {
            return BadRequest("Provide a refresh token.");
         }

         ApplicationUserDTO userDTO = _userLogic.GetUserByRefreshToken(refreshToken);
         if (userDTO == null)
         {
            return BadRequest("No user found.");
         }
         ApplicationResult result = _userLogic.AuthenticateUser(userDTO, userDTO.Password);

         if (result.IsCompletedSuccesfully)
         {
            return Ok(result);
         }

         return StatusCode(result.StatusCode, result.Message);
      }

      [HttpPost]
      [Route("Register")]
      public ActionResult UserRegister([FromBody] ApplicationUserDTO applicationUserDTO)
      {
         ApplicationResult validateDTO = _authenticationControllerHelper.ValidateDTO(ref applicationUserDTO);
         if (!validateDTO.IsCompletedSuccesfully)
         {
            return BadRequest(validateDTO.Message);
         }

         _userLogic.AddUser(applicationUserDTO);

         return Ok(validateDTO.Message);
      }
   }
}
