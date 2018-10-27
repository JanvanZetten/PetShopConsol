using System;
using System.Linq;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Core.Application.Impl
{
    public class UserService: IUserService
    {
        private IUserRepositorie _Repository;

        public UserService(IUserRepositorie repository)
        {
            _Repository = repository;
        }

        public User GetWhereUsername(string username)
        {
            return _Repository.GetAll().FirstOrDefault(u => u.Username.Equals(username));
        }
    }
}
