using System;
using System.Collections.Generic;

namespace EASV.PetShopConsol.Core.Entity
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public List<Pet> PetsWithThisColor { get; set; }
    }
}