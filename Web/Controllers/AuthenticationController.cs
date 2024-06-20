using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthenticationService _customAuthenticationService;

        public AuthenticationController(IConfiguration config, IAuthenticationService autenticacionService)
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
            _customAuthenticationService = autenticacionService;
        }

        [HttpPost("authenticate")] //Vamos a usar un POST ya que debemos enviar los datos para hacer el login
        public ActionResult<AuthenticationResponse> Autenticar(AuthenticationRequest authenticationRequest) //Enviamos como parámetro la clase que creamos arriba
        {
            var token = _customAuthenticationService.Autenticate(authenticationRequest); //Lo primero que hacemos es llamar a una función que valide los parámetros que enviamos.

            return Ok(token);
        }
    }
}
