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
        ICollection<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        void UpdateUser(int id, UserCreateRequest customer);
        void DeleteUser(int id);
        UserDto CreateUser(UserCreateRequest user);
    }
}
