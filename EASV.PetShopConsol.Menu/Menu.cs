using System;
using EASV.PetShopConsol.Core.Application;

namespace EASV.PetShopConsol.Menu
{
    public class Menu
    {
        private readonly IPetService _PetService;
        public Menu(IPetService petService)
        {
            _PetService = petService;
        }
    }
}
