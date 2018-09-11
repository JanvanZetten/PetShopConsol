using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Core.Application.Impl
{
    public class OwnerService :IOwnerService
    {
        private readonly IOwnerRepository _OwnerRepository;
        public OwnerService(IOwnerRepository ownerRepository)
        {
            _OwnerRepository = ownerRepository;
        }

        public void AddOwner(Owner newOwner)
        {
            _OwnerRepository.AddOwner(newOwner);
        }

        public void Delete(int id)
        {
            _OwnerRepository.DeleteOwner(id);
        }

        public List<Owner> GetAllOwners()
        {
            return _OwnerRepository.GetOwners().ToList();
        }

        public Owner GetOwner(int id)
        {
            return _OwnerRepository.GetOwners().FirstOrDefault(owner => owner.Id == id);
        }

        public void UpdateOwner(int id, Owner owner)
        {
            _OwnerRepository.UpdateOwner(id, owner);
        }
    }
}
