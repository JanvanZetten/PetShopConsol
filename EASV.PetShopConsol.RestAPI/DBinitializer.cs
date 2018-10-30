using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShopConsol.Core.Entity;
using EASV.PetShopConsol.InfrastructureEntityFramework;

namespace EASV.PetShopConsol.RestAPI
{

    public static class DBInitializer
    {
        // This method will create and seed the database.
        public static void Initialize(PetConsolContext context)
        {
            // Delete the database, if it already exists. I do this because an
            // existing database may not be compatible with the entity model,
            // if the entity model was changed since the database was created.
            //context.Database.EnsureDeleted();

            // Create the database, if it does not already exists. This operation
            // is necessary, if you don't use an in-memory database.
            //context.Database.EnsureCreated();

            // Look for any TodoItems
            if (context.Pets.Any())
            {
                return;   // DB has been seeded
            }

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

            List<Pet> petItems = new List<Pet>
            {
                new Pet(){
                    Name = "Fido",
                    Birthday = DateTime.Now.AddYears(-2).AddMonths(-4).AddDays(5),
                    Price = 1000,
                    Type = AnimalType.Dog,
                    PetColors = new List<PetColorRelation>(){
                        new PetColorRelation(){
                            PetColor = new PetColor()
                            {
                                ColorName = "Black"
                            }
                        }
                    },
                    PreviousOwner = ownersItems[0]
                    
                },
                new Pet(){
                    Name = "Rolf",
                    Birthday = DateTime.Now.AddYears(-1).AddMonths(-1).AddDays(5),
                    Price = 1000,
                    Type = AnimalType.Fish,
                    PreviousOwner = ownersItems[0]

                },
                new Pet(){
                    Name = "Bukke Bruse",
                    Birthday = DateTime.Now.AddYears(-10).AddMonths(-4).AddDays(5),
                    Price = 1000,
                    Type = AnimalType.Goat,
                    PreviousOwner = ownersItems[1]

                }
            };

            List<PetColor> petColors = new List<PetColor>
            {
                new PetColor(){ColorName = "Blue"},
                new PetColor(){ColorName = "Red"},
                new PetColor(){ColorName = "Green"}
            };


            // Create two users with hashed and salted passwords
            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };

            context.Owners.AddRange(ownersItems);
            context.Pets.AddRange(petItems);
            context.PetColors.AddRange(petColors);
            context.Users.AddRange(users);
            context.SaveChanges();

        }

        // This method computes a hashed and salted password using the HMACSHA512 algorithm.
        // The HMACSHA512 class computes a Hash-based Message Authentication Code (HMAC) using 
        // the SHA512 hash function. When instantiated with the parameterless constructor (as
        // here) a randomly Key is generated. This key is used as a password salt.

        // The computation is performed as shown below:
        //   passwordHash = SHA512(password + Key)

        // A password salt randomizes the password hash so that two identical passwords will
        // have significantly different hash values. This protects against sophisticated attempts
        // to guess passwords, such as a rainbow table attack.
        // The password hash is 512 bits (=64 bytes) long.
        // The password salt is 1024 bits (=128 bytes) long.
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }

}
