using System;
using System.Collections.Generic;

namespace EASV.PetShopConsol.Core.Entity
{
    public class Owner
    {
       
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<Pet> PreviousPets { get; set; }

    }
}
