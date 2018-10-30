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
            if (!_Service.CheckCorrectPassword(user, model))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = _Service.GenerateToken(user)
            });
        }


    }



}
