
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using WMS.Models;

namespace WMS.security
{
    public static class TokenGenretor
    {
        public static string CreateAccessToken(user user, DateTime ExpireTime)
        {
            try
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.username));
                foreach (var item in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item.Title));
                }

                var mySecret = "3WgHrbw+cuZZ++Wd9aRhTNhn0YkfA4NGOWJ4PPvPpwYpNxVlC5hrZTjR6x7pWIT+";
                var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));
                var cerds = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature);
                var tokenDes = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = ExpireTime,
                    SigningCredentials = cerds,
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDes);
                return tokenHandler.WriteToken(token);
            }
            catch
            {
                return string.Empty;
            }



        }

        public static string GenerateToken(int userId)
        {
            var mySecret = "3WgHrbw+cuZZ++Wd9aRhTNhn0YkfA4NGOWJ4PPvPpwYpNxVlC5hrZTjR6x7pWIT+";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var myIssuer = "http://mysite.com";
            var myAudience = "http://myaudience.com";

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static bool TokenIsValid(string token)
        {
            JwtSecurityToken jwtSecurityToken;
            try
            {
                jwtSecurityToken = new JwtSecurityToken(token);
            }
            catch (Exception)
            {
                return false;
            }
            return jwtSecurityToken.ValidTo > DateTime.UtcNow;
        }

        public static List<string> GetRole(string token)
        {
            var role = new List<string>();
            JwtSecurityToken jwtSecurityToken;
            try
            {
                jwtSecurityToken = new JwtSecurityToken(token);
                foreach (var item in jwtSecurityToken.Claims)
                {
                    if (item.Type.ToLower() == "role")
                    {
                        role.Add(item.Value);
                    }
                }
                return role;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string GetUsername(string token)
        {
            JwtSecurityToken jwtSecurityToken;
            try
            {
                jwtSecurityToken = new JwtSecurityToken(token);
                foreach (var item in jwtSecurityToken.Claims)
                {
                    if (item.Type.ToLower() == "nameid")
                        return item.Value;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}