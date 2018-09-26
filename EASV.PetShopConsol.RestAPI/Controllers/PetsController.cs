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
        private readonly IOwnerService _ownerService;

        public PetsController(IPetService petService, IOwnerService ownerService)
        {
            _petService = petService;
            _ownerService = ownerService;
        }

        /*
        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            var pets = _petService.GetAllPets();

            return pets; 
        }*/

        // GET api/pets/page=1&items=2 OR GET api/pets
        [HttpGet()]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] int page, [FromQuery] int items)
        {
            List<Pet> pets;
            if (page < 1 || items < 1)
                pets = _petService.GetAllPets();
            else
                pets = _petService.GetAllPetsPaged(page, items);
            return pets;
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            Pet pet;
            try
            {
                pet = _petService.GetPetById(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return pet == null ? (ActionResult<Pet>)NotFound() : (ActionResult<Pet>)Ok(pet);
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet newPet)
        {
            var owner = newPet.PreviousOwner;

            //no ID But a new Owner
            if (owner != null && owner.Id <= 0 && owner.FirstName != null && owner.LastName != null)
            {
                owner = _ownerService.AddOwner(owner);
                newPet.PreviousOwner = new Owner() { Id = owner.Id };
            }

            try
            {
                return Ok(_petService.SavePet(newPet));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet updatedPet)
        {
            updatedPet.Id = id;
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
