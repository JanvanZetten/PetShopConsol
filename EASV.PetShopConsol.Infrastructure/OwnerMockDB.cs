using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Entity;
using System.Linq;

namespace EASV.PetShopConsol.Infrastructure
{
    public class OwnerMockDB
    {
        internal static IEnumerable<Owner> Owners { get; set; }
        private static int nextId = 1;

        internal static int NextID(){
            return nextId++;
        }

        internal static void AddMockdataIfEmpty()
        {
            if (Owners == null)
            {
                var aslist = new List<Owner>();
                var owner = new Owner() { Id = NextID(), FirstName = "Jens", LastName = "Eriksen" };
                aslist.Add(owner);
                owner = new Owner() { Id = NextID(), FirstName = "Erik", LastName = "Hansen" };
                aslist.Add(owner);
                owner = new Owner() { Id = NextID(), FirstName = "Hans", LastName = "Jensen" };
                aslist.Add(owner);

                OwnerMockDB.Owners = aslist;
            }
        }
    }
}
