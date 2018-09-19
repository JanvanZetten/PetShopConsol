using System;
using EASV.PetShopConsol.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace EASV.PetShopConsol.InfrastructureEntityFramework
{
    public class PetConsolContext : DbContext
    {

        public PetConsolContext(DbContextOptions<PetConsolContext> options)
            : base(options)
        {
        }



        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                        .HasMany<Pet>()
                        .WithOne(p => p.PreviousOwner)
                        .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
