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
    public class ClassesHabilidadesController : ControllerBase
    {
        private IClasseHabilidadeRepository _classeHabilidadeRepository { get; set; }

        public ClassesHabilidadesController()
        {
            _classeHabilidadeRepository = new ClasseHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeHabilidadeRepository.Listar());
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            return Ok(_classeHabilidadeRepository.BuscarPorId(Id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(ClasseHabilidade novaClasseHabilidade)
        {
            _classeHabilidadeRepository.Cadastrar(novaClasseHabilidade);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(ClasseHabilidade classeHabilidadeAtualizado)
        {
            _classeHabilidadeRepository.Atualizar(classeHabilidadeAtualizado.IdClasseHabilidade, classeHabilidadeAtualizado);

            return StatusCode(204);

        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(short Id)
        {
            _classeHabilidadeRepository.Deletar(Id);

            return StatusCode(204);

        }
    }
}
