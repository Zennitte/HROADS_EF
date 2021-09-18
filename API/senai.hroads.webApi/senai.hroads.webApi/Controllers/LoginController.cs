using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("login")]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _usuarioRepository.Login(login.Senha, login.Email);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou Senha invalidos");
            }

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Senha),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai_HROADS_webAPI.securitykey"));

            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(issuer: "senai.hroads.webApi", audience: "senai.hroads.webApi", claims: Claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: Creds);

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(Token)
            });

        }
    }
}
