using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Core.Domain
{
    public interface IPetColorRepository
    {
        IEnumerable<PetColor> GetColors();
        void SaveColor(PetColor petColor);
        void DeleteColor(int id);
        void UpdateColor(PetColor petColor);
    }
}
