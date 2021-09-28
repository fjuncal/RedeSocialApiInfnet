using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rede_social_api_at.DbContextConfig;
using rede_social_api_at.Models;
using rede_social_api_at.Repository.ComentarioRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rede_social_api_at.Models.Dto;

namespace rede_social_api_at.Controllers
{
    [Route("api/comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepository _iComentarioRepository;

        public ComentarioController(ApiDbContext apiDbContext, IComentarioRepository iComentarioRepository)
        {
            _iComentarioRepository = iComentarioRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var coment = _iComentarioRepository.GetAll();
                return Ok(coment);
                
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: comentários não encontrados");
            }
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                var outro = _iComentarioRepository.GetById(id);
                return Ok(outro);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: comentario não encontrados");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Comentario coment)
        {
            try
            {
                _iComentarioRepository.CriarComentario(coment);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: criação de comentário inválida");
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var coment = _iComentarioRepository.GetById(id);
                _iComentarioRepository.Delete(coment);
                return Ok();
            }
            catch
            {
                return BadRequest("Request inválido!");
            }
            
        }

        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] Comentario comentario)
        {
            try
            {
                if (comentario.Id == id)
                {
                    _iComentarioRepository.Update(id, comentario);
                    return Ok(comentario);
                }
                else
                {
                    return BadRequest("Dados inconsistentes!");
                }
            }
            catch
            {
                return BadRequest("Request inválido!");
            }
            
        }
    }
}
