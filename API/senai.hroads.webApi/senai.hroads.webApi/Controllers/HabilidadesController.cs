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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_habilidadeRepository.Listar());
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            return Ok(_habilidadeRepository.BuscarPorId(Id));
        }

        [HttpGet("tipo")]
        public IActionResult ListarComTipo()
        {
            return Ok(_habilidadeRepository.ListarComTipo());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade novahabilidade)
        {
            _habilidadeRepository.Cadastrar(novahabilidade);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(Habilidade habilidadeAtualizado)
        {
            _habilidadeRepository.Atualizar(habilidadeAtualizado.IdHabilidade, habilidadeAtualizado);

            return StatusCode(204);

        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(byte Id)
        {
            _habilidadeRepository.Deletar(Id);

            return StatusCode(204);

        }
    }
}
