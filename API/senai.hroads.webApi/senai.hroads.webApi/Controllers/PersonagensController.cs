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
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_personagemRepository.Listar());
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            return Ok(_personagemRepository.BuscarPorId(Id));
        }

        [HttpGet("classe")]
        public IActionResult ListarComClasse()
        {
            return Ok(_personagemRepository.ListarComClasse());
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem novapersonagem)
        {
            _personagemRepository.Cadastrar(novapersonagem);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(Personagem personagemAtualizado)
        {
            _personagemRepository.Atualizar(personagemAtualizado.IdPersonagem, personagemAtualizado);

            return StatusCode(204);

        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _personagemRepository.Deletar(Id);

            return StatusCode(204);

        }
    }
}
