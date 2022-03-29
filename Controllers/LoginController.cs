using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using workoholicshop.Data;
using workoholicshop.Models;

namespace workoholicshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext _context;

       

        // TRAEMOS EL OBJETO DE CONFIGURACIÓN (appsettings.json)
        // MEDIANTE INYECCIÓN DE DEPENDENCIAS.
        public LoginController(IConfiguration configuration, ApplicationDbContext context)
        {
            this.configuration = configuration;
            _context = context;
        }

        // POST: api/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(User user)
        {
            var _userInfo = await AutenticarUsuarioAsync(user.Name, user.Password);
            if (_userInfo != null)
            {
                return Ok(new { token = GenerarTokenJWT(_userInfo) });
            }
            else
            {
                return Unauthorized();
            }
        }

        // COMPROBAMOS SI EL USUARIO EXISTE EN LA BASE DE DATOS 
        private async Task<ActionResult<User>> AutenticarUsuarioAsync(string email, string password)
        {
            

            var user = await _context.User.Where(u=> u.Email==email && u.Password==password).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;

            // Supondremos que el Usuario NO existe en la Base de Datos.
            // Retornamos NULL.
            //return null;
        }

        // GENERAMOS EL TOKEN CON LA INFORMACIÓN DEL USUARIO
        private string GenerarTokenJWT(User usuarioInfo)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.Id.ToString()),
                new Claim("nombre", usuarioInfo.Name),
                new Claim("apellidos", usuarioInfo.Surname),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email)
            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}