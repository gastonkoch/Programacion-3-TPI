using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        //Lo User en un futuro van a ser UserDto todavia no dimos por que
        ICollection<User> GetAllUsers(); //GetAll
        User GetUserById(int id);
        void DeleteUser(int id);
        void UpdateUser(int id, UserDto customer);
        User CreateUser(UserDto customer);
    }
}
