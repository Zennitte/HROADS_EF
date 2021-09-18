using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipousuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            _tipousuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipousuarioRepository.Listar());
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            return Ok(_tipousuarioRepository.BuscarPorId(Id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novatipousuario)
        {
            _tipousuarioRepository.Cadastrar(novatipousuario);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(TipoUsuario tipousuarioAtualizado)
        {
            _tipousuarioRepository.Atualizar(tipousuarioAtualizado.IdTipoUsuario, tipousuarioAtualizado);

            return StatusCode(204);

        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _tipousuarioRepository.Deletar(Id);

            return StatusCode(204);

        }
    }
}
