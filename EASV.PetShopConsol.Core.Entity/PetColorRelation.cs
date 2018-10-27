using System;
namespace EASV.PetShopConsol.Core.Entity
{
    public class PetColorRelation
    {
        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public int PetColorId { get; set; }
        public PetColor PetColor { get; set; }
    }
}
