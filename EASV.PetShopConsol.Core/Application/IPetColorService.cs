using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Core.Application
{
    public interface IPetColorService
    {
        List<PetColor> GetAllColors();
        PetColor GetColor(int id);
        void AddColor(PetColor petColor);
        void UpdateColor(PetColor petColor);
        void DeleteColor(int id);
    }
}
