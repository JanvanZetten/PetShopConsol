using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;
using Microsoft.IdentityModel.Tokens;

namespace EASV.PetShopConsol.Core.Application.Impl
{
    public class UserService: IUserService
    {
        private IUserRepositorie _Repository;

        public UserService(IUserRepositorie repository)
        {
            _Repository = repository;
        }

        public bool CheckCorrectPassword(User user, LoginInputModel model)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(model.Password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i]) return false;
                }
            }
            return true;
        }

        public User GetWhereUsername(string username)
        {
            return _Repository.GetAll().FirstOrDefault(u => u.Username.Equals(username));
        }

        // This method generates and returns a JWT token for a user.
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            if (user.IsAdmin)
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    JwtSecurityKey.Key,
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null, // issuer - not needed (ValidateIssuer = false)
                               null, // audience - not needed (ValidateAudience = false)
                               claims.ToArray(),
                               DateTime.Now,               // notBefore
                               DateTime.Now.AddDays(1)));  // expires

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
