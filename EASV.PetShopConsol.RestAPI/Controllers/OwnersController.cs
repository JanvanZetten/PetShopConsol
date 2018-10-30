using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EASV.PetShopConsol.Core.Application;
using EASV.PetShopConsol.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EASV.PetShopConsol.RestAPI.Controllers
{
    [Route("api/[controller]")]
    public class OwnersController : Controller
    {
        private readonly IOwnerService _OwnerService;

        public OwnersController(IOwnerService ownerService)
        {
            _OwnerService = ownerService;
        }

        [Authorize]
        // GET: api/values
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _OwnerService.GetAllOwners();
        }

        [Authorize]
        // GET api/values/5
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            return _OwnerService.GetOwner(id);
        }

        [Authorize(Roles = "Administrator")]
        // POST api/values
        [HttpPost]
        public void Post([FromBody]Owner newOwner)
        {
            _OwnerService.AddOwner(newOwner);
        }

        [Authorize(Roles = "Administrator")]
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Owner owner)
        {
            _OwnerService.UpdateOwner(id, owner);
        }

        [Authorize(Roles = "Administrator")]
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _OwnerService.Delete(id);
        }
    }
}
