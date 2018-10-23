using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace EASV.PetShopConsol.InfrastructureEntityFramework
{
    public class PetColorDBRepository : IPetColorRepository
    {
        private readonly PetConsolContext _ctx;

        public PetColorDBRepository(PetConsolContext ctx)
        {
            _ctx = ctx;
        }

        public void DeleteColor(int id)
        {
            _ctx.PetColors.Remove(new PetColor { Id = id });
            _ctx.SaveChanges();
        }

        public IEnumerable<PetColor> GetColors()
        {
            return _ctx.PetColors;
        }

        public void SaveColor(PetColor petColor)
        {
            _ctx.Attach(petColor).State = EntityState.Added;
            _ctx.SaveChanges();

        }

        public void UpdateColor(PetColor petColor)
        {
            _ctx.Attach(petColor).State = EntityState.Modified;
            _ctx.Entry(petColor).Reference(pc => pc.PetsWithThisColor).IsModified = true;
            _ctx.SaveChanges();
        }
    }
}
