using System;
namespace EASV.PetShopConsol.Core.Entity
{
    public class User
    {
        public User()
        {
        }
        public long Id { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    }
}
