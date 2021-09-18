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
    public class ClassesController : ControllerBase
    {

        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeRepository.Listar());
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            return Ok(_classeRepository.BuscarPorId(Id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Classe novaClasse)
        {
            _classeRepository.Cadastrar(novaClasse);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(Classe classeAtualizado)
        {
            _classeRepository.Atualizar(classeAtualizado.IdClasse, classeAtualizado);

            return StatusCode(204);

        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(byte Id)
        {
            _classeRepository.Deletar(Id);

            return StatusCode(204);

        }

        
    }
}
