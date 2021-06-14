using AuthenticationServer.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AuthenticationServer.Middlewares
{
   public class ValidateRefreshTokenMiddleware
   {
      private readonly RequestDelegate _next;

      public ValidateRefreshTokenMiddleware(RequestDelegate next)
      {
         _next = next;
      }

      // IMyScopedService is injected into Invoke
      public async Task Invoke(HttpContext httpContext, IUserLogic _userLogic)
      {
         _userLogic.ValidateUserRefreshTokens();
         await _next(httpContext);
      }
   }
}
