using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Utils;

namespace MiniTravelingExplorer.Filters
{
    public class Authentication
    {
        public static string GenerateJwtAuthentication(string email, string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtHeaderParameterNames.Jku, email),
                new Claim(JwtHeaderParameterNames.Kid, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, userName)
            };


            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Convert.ToString(ConfigurationManager.AppSettings[Constant.JWT_KEY])));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            DateTime expiryDate = DateTime.UtcNow.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings[Constant.COOKIE_EXPIRATION_TIME_KEY]));

            JwtSecurityToken token = new JwtSecurityToken(
                Convert.ToString(ConfigurationManager.AppSettings[Constant.JWT_ISSUER_KEY]),
                Convert.ToString(ConfigurationManager.AppSettings[Constant.JWT_AUDIENCE_KEY]),
                claims,
                expires: expiryDate,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static User ValidateToken(string token)
        {
            User user = new User();

            if (token != null)
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] jwtKey = Encoding.ASCII.GetBytes(Convert.ToString(ConfigurationManager.AppSettings[Constant.JWT_KEY]));

                try
                {
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    // Corrected access to the validatedToken
                    JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
                    user.Email = jwtToken.Claims.First(claim => string.Compare(claim.Type, ClaimTypes.Email) == 0).Value;
                    user.FullName = jwtToken.Claims.First(claim => string.Compare(claim.Type, ClaimTypes.Name) == 0).Value;
                    user.ExpiryDate = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(jwtToken.Claims.FirstOrDefault(t => t.Type == "exp").Value)).DateTime;
                }
                catch
                {
                    return user;
                }
            }

            return user;
        }
    }
}