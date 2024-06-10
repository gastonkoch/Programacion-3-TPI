using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public UserDto GetUserById(int id)
        {
            UserDto userDto = UserDto.ToDto(_userRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontro el usuario"));
            return userDto;
        }

        public UserDto CreateUser(UserCreateRequest dto)
        {
            return UserDto.ToDto(_userRepository.AddAsync(UserCreateRequest.ToEntity(dto)).Result);

        }


        //public User GetUserById(int id)
        //{
        //    return _userRepository.GetUserById(id);
        //}

        //public ICollection<User> GetAllUsers() 
        //{
        //    return _userRepository.GetAll();
        //}
        //public void DeleteUser(int id)
        //{
        //    var userDelete = _userRepository.GetUserById(id);    
        //    _userRepository.DeleteUser(userDelete);
        //}

        //public void UpdateUser(int id, UserDto userDto) 
        //{
        //   var userUpdate = _userRepository.GetUserById(id);
        //    userUpdate.Password = userDto.Password;
        //    _userRepository.UpdateUser(userUpdate); 
        //}

        //public User CreateUser(UserDto user)
        //{
        //    var newUser = new User()
        //    {
        //        Id = user.Id, // borrar
        //        Name = user.Name,
        //        Password = user.Password,
        //        Email = user.Email,
        //        RegisterDate = user.RegisterDate,
        //        UserType = user.UserType,
        //    };
        //    _userRepository.AddUser(newUser);
        //    return _userRepository.GetUserById(user.Id); // Esto no tendria sentido cuando tengamos Base da datos por que el id no llegaria por parametro
        //}
    }
}
