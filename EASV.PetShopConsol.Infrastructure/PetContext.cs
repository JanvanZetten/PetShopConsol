using System;
using EASV.PetShopConsol.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace EASV.PetShopConsol.Infrastructure
{
    public class PetContext : DbContext
    {

        public PetContext(DbContextOptions<PetContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> pets { get; set; }
        public DbSet<Owner> owners { get; set; }
    }
}
