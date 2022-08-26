using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;
using System;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventosService _eventosService;

        public EventosController(IEventosService eventosService)
        {
            _eventosService = eventosService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos =  await _eventosService.GetALlEventosAsync(true);
                
                if(eventos == null) 
                    return NotFound("Nenhum Evento encontrado");

                return Ok(eventos);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro o tentar recuperar Eventos.Erro: {ex.Message}");               
            }

        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIDAsync (int id)
        {
            try
            {
                var evento =  await _eventosService.GetEventoByIdAsync(id,true);
                
                if(evento == null) 
                    return NotFound("Evento não encontrado");

                return Ok(evento);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro o tentar recuperar Evento.Erro: {ex.Message}");               
            }        
        }
        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTemaAsync (string tema)
        {
            try
            {
                var eventos =  await _eventosService.GetALlEventosByTemaAsync(tema,true);
                
                if(eventos == null) 
                    return NotFound("Evento não encontrado");

                return Ok(eventos);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro o tentar recuperar Evento por Tema.Erro: {ex.Message}");               
            }        
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento =  await _eventosService.AddEvento(model);
                
                if(evento == null) 
                    return BadRequest("Evento não encontrado");

                return Ok(evento);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro o tentar adicionar Evento.Erro: {ex.Message}");               
            }           
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento =  await _eventosService.UpdateEvento(id,model);
                
                if(evento == null) 
                    return BadRequest("Erro  ao tentar alterar evento");

                return Ok(evento);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro o tentar alterar Evento.Erro: {ex.Message}");               
            }  
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _eventosService.DeleteEvento(id) ? 
                                Ok($"Evento id: {id}, Deletado") :
                                    BadRequest("Evento não Deletado");
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro o tentar deletar Evento.Erro: {ex.Message}");               
            }             
        }
    }
}
