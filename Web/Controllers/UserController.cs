using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(_userService.GetUserById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser([FromBody] UserCreateRequest user)
        {
            try
            {
                return _userService.CreateUser(user);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //public ActionResult<ICollection<User>> GetAll()
        //{
        //    try
        //    {
        //        return Ok(_userService.GetAllUsers());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public void DeleteUser([FromRoute] int id)
        //{
        //    _userService.DeleteUser(id);
        //}

        //[HttpPut("{id}")]
        //public void UpdateUser([FromRoute] int id, [FromBody] UserDto user)
        //{
        //    _userService.UpdateUser(id, user);
        //}


    }
}
