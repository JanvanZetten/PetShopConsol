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
    public class PetColorsController : Controller
    {


    private readonly IPetColorService _petColorService;

    public PetColorsController(IPetColorService petColorService)
    {
        _petColorService = petColorService;
    }


        [Authorize]
        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<PetColor>> Get()
        {
            var colors = _petColorService.GetAllColors();
            return Ok(colors);
        }

        [Authorize]
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<PetColor> Get(int id)
        {
            var color = _petColorService.GetColor(id);
            return Ok(color);
        }

        [Authorize(Roles = "Administrator")]
        // POST api/values
        [HttpPost]
        public void Post([FromBody]PetColor petColor)
        {
            _petColorService.AddColor(petColor);
        }

        [Authorize(Roles = "Administrator")]
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PetColor petColor)
        {
            petColor.Id = id;
            _petColorService.UpdateColor(petColor);
        }

        [Authorize(Roles = "Administrator")]
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petColorService.DeleteColor(id);
        }
    }
}
