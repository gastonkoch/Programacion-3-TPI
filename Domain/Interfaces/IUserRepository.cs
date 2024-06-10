using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        //ICollection<User> GetAll();
        //User GetUserById(int id);
        //User AddUser(User customer); // Create
        //void DeleteUser(User customer);
        //void UpdateUser(User customer);
    }
}
