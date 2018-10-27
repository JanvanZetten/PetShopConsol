using System;
namespace EASV.PetShopConsol.Core.Entity
{
    public class User
    {
        public User()
        {
        }
        public long Id { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public bool IsAdmin { get; set; }
    }
}
