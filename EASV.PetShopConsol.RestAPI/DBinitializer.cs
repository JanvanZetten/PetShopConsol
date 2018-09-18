﻿using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShopConsol.Core.Entity;
using EASV.PetShopConsol.Infrastructure;

namespace EASV.PetShopConsol.RestAPI
{

        public static class DBInitializer
        {
            // This method will create and seed the database.
            public static void Initialize(PetContext context)
            {
                // Delete the database, if it already exists. I do this because an
                // existing database may not be compatible with the entity model,
                // if the entity model was changed since the database was created.
                //context.Database.EnsureDeleted();

                // Create the database, if it does not already exists. This operation
                // is necessary, if you don't use an in-memory database.
                context.Database.EnsureCreated();

                // Look for any TodoItems
            if (context.pets.Any())
                {
                    return;   // DB has been seeded
                }

            List<Pet> petItems = new List<Pet>
            {
                new Pet(){
                    Name = "Fido",
                    Color = "Black and white",
                    Birthday = DateTime.Now.AddYears(-2).AddMonths(-4).AddDays(5),
                    Price = 1000,
                    Type = AnimalType.Dog,
                    PreviousOwner = new Owner(){
                        Id = 1
                    }
                },
                new Pet(){
                    Name = "Rolf",
                    Color = "Black and white",
                    Birthday = DateTime.Now.AddYears(-1).AddMonths(-1).AddDays(5),
                    Price = 1000,
                    Type = AnimalType.Fish,
                    PreviousOwner = new Owner(){
                        Id = 1
                    }
                },
                new Pet(){
                    Name = "Bukke Bruse",
                    Color = "gray",
                    Birthday = DateTime.Now.AddYears(-10).AddMonths(-4).AddDays(5),
                    Price = 1000,
                    Type = AnimalType.Goat,
                    PreviousOwner = new Owner(){
                        Id = 2
                    }
                }
            };

            List<Owner> ownersItems = new List<Owner>{
                new Owner(){
                    FirstName = "John",
                    LastName = "Poulsen"
                },
                new Owner(){
                    FirstName = "Anne",
                    LastName = "Hansen"
                }
            };
                context.owners.AddRange(ownersItems);
                context.pets.AddRange(petItems);
                context.SaveChanges();
               
            }
        }

}