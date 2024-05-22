using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        public ICollection<User> GetAll()
        {
            return null;
        }

        public User GetUserById(int id)
        {
            return null;
        }
        public User AddUser(User user)
        {
            return null;
        }

        public void DeleteUser(User user)
        {

        }

        public void UpdateUser(User user)
        {

        }
    }
}
