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

        public ICollection<UserDto> GetAllUsers()
        {
            var users = UserDto.ToList(_userRepository.ListAsync().Result ?? throw new Exception("No se encontraron usuarios"));
            return users;
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

        public void UpdateUser(int id, UserCreateRequest userDto) 
        {
            _userRepository.UpdateAsync(UserCreateRequest.ToEntity(userDto));
        }

        public void DeleteUser(int id)
        {
            var userDto = _userRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontro el usuario");
            _userRepository.DeleteAsync(userDto);
        }
    }
}
