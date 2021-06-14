using AuthenticationServer.BL.Helpers.Interfaces;
using AuthenticationServer.TL.DTOs;
using AuthenticationServer.TL.Helper.Classes;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AuthenticationServer.BL.Helpers.Classes
{
   public class JWTokenManager : IJWTokenManager
   {
      public string GenerateJWToken(ApplicationUserDTO userDTO)
      {
         Dictionary<string, object> userClaims = new Dictionary<string, object>
         {
            { "UserId", userDTO.UserId },
            { "FirstName", userDTO.FirstName },
            { "LastName", userDTO.LastName },
            { "Username", userDTO.Username },
            { "Email", userDTO.Email },
            { "RefreshToken", userDTO.RefreshToken },
         };

         JWTokenDTO jwtokenDTO = ConfigurationHelper.GetJWTokenSettings();

         jwtokenDTO.UserClaims = userClaims;

         string token = CreateToken(jwtokenDTO);

         return token;
      }

      private string CreateToken(JWTokenDTO jwtokenDTO)
      {
         try
         {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddMinutes(jwtokenDTO.ExpirationMinutes);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SymmetricSecurityKey signingSecurityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(jwtokenDTO.SigningKey));
            SymmetricSecurityKey encryptyingSecurityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(jwtokenDTO.EncryptyingSecurityKey));

            SigningCredentials signingCredentials = new SigningCredentials(signingSecurityKey, SecurityAlgorithms.HmacSha512);
            EncryptingCredentials encryptingCredentials = new EncryptingCredentials(encryptyingSecurityKey, JwtConstants.DirectKeyUseAlg, SecurityAlgorithms.Aes256CbcHmacSha512);

            JwtSecurityToken token =

                tokenHandler.CreateJwtSecurityToken(
                   subject: null,
                   issuedAt: DateTime.Now,
                   encryptingCredentials: encryptingCredentials,
                   issuer: jwtokenDTO.Issuer,
                   audience: jwtokenDTO.Audience,
                   claimCollection: jwtokenDTO.UserClaims,
                   notBefore: issuedAt,
                   expires: expires,
                   signingCredentials: signingCredentials);

            return tokenHandler.WriteToken(token);
         }
         catch
         {
            return null;
         }
      }
   }
}
