using System;
using System.Collections.Generic;

namespace EASV.PetShopConsol.Core.Entity
{
    public class PetColor
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public List<PetColorRelation> PetsWithThisColor { get; set; }
    }
}