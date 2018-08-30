using System;
using EASV.PetShopConsol.Core.Application;
using EASV.PetShopConsol.Core.Application.Impl;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace EASV.PetShopConsol.Menu
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetMockRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();

            new Menu(petService);
        }
    }
}
