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
        public DbSet<PetColor> PetColors { get; set; }
        public DbSet<PetColorRelation> PetColorRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                        .HasMany(o => o.PreviousPets)
                        .WithOne(p => p.PreviousOwner)
                        .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PetColorRelation>().HasKey(pcr => new { pcr.PetId, pcr.PetColorId });

            modelBuilder.Entity<PetColorRelation>()
                        .HasOne(pcr => pcr.Pet).WithMany(p => p.PetColors)
                        .HasForeignKey(pcr => pcr.PetId);

            modelBuilder.Entity<PetColorRelation>()
                        .HasOne(pcr => pcr.PetColor).WithMany(pc => pc.PetsWithThisColor)
                        .HasForeignKey(pcr => pcr.PetColorId);

        }
    }
}
