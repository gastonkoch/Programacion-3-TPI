using Application.Models;
using Application.Models.Requests;
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
        //ICollection<User> GetAllUsers(); //GetAll
        UserDto GetUserById(int id);
        //void DeleteUser(int id);
        //void UpdateUser(int id, UserDto customer);
        UserDto CreateUser(UserCreateRequest user);
    }
}
