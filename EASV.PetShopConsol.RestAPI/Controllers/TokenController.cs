using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EASV.PetShopConsol.Core.Application;
using EASV.PetShopConsol.Core.Entity;
using EASV.PetShopConsol.Core.Application.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EASV.PetShopConsol.RestAPI.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {


        private readonly IUserService _Service;

        public TokenController(IUserService service)
        {
            _Service = service;
        }


        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var user = _Service.GetWhereUsername(model.Username);


            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!model.Password.Equals(user.Password))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = GenerateToken(user)
            });
        }

        // This method generates and returns a JWT token for a user.
        private string GenerateToken(User user)
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
