using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EASV.PetShopConsol.Core.Application;
using EASV.PetShopConsol.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EASV.PetShopConsol.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetAllPets();
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.GetPetById(id);
        }

        // POST api/pets
        [HttpPost]
        public void Post([FromBody] Pet newPet)
        {
            _petService.SavePet(newPet);
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet updatedPet)
        {
            _petService.EditPet(updatedPet);
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.DeletePetById(id);
        }
    }
}
