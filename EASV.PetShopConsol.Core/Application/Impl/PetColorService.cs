using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Core.Application.Impl
{
    public class PetColorService : IPetColorService
    {
        private readonly IPetColorRepository _PetColorRepository;
        public PetColorService(IPetColorRepository petColorRepo)
        {
            _PetColorRepository = petColorRepo;
        }

        public void AddColor(PetColor petColor)
        {
            _PetColorRepository.SaveColor(petColor);
        }

        public void DeleteColor(int id)
        {
            _PetColorRepository.DeleteColor(id);
        }

        public List<PetColor> GetAllColors()
        {
            return _PetColorRepository.GetColors().ToList();
        }

        public PetColor GetColor(int id)
        {
            return _PetColorRepository.GetColors().FirstOrDefault(c => c.Id == id);
        }

        public void UpdateColor(PetColor petColor)
        {
            _PetColorRepository.UpdateColor(petColor);
        }
    }
}
