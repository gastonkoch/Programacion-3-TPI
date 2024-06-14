﻿using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Application.Interfaces;

namespace Infrastructure.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly AutenticacionServiceOptions _options;

        public AuthenticationService(IUserRepository userRepository, IOptions<AutenticacionServiceOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }

        public User? ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password) ) return null;

            var user = _userRepository.GetByUserName(authenticationRequest.UserName);

            if (authenticationRequest.UserName == user.Name || authenticationRequest.Password == user.Password) return user ;
        
            return null;
        }

        public AuthenticationResponse Autenticate(AuthenticationRequest authenticationRequest)
        {
            //Validamos las credenciales
            var user = ValidateUser(authenticationRequest);

            if (user == null)
            {
                throw new InvalidOperationException("User authentication failed");
            }


            //Hash del secreto
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey)); // Obtenemos el salt
            
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256); // Hasheamos el salt

            //Los claims son datos en clave->valor que nos permite guardar data del usuario.
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("given_name", user.Name));
            claimsForToken.Add(new Claim("given_email", user.Email));
            claimsForToken.Add(new Claim("given_register_date", user.RegisterDate.ToString()));
            claimsForToken.Add(new Claim("role", user.UserType.ToString()));

            //Creamos el token
            var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
             _options.Issuer,
             _options.Audience,
             claimsForToken,
             DateTime.UtcNow,
             DateTime.UtcNow.AddHours(1), // La cantidad de horas que va a ser valido en este caso 1
             credentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            var response = new AuthenticationResponse(tokenToReturn.ToString());

            return response;
        }
    }

    public class AutenticacionServiceOptions
    {
        public const string AutenticacionService = "AutenticacionService";

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretForKey { get; set; }
    }
}