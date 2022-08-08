using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {   
        private readonly DataContext _context;

        public EventosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }
        
        [HttpGet("{id}")]
        public async Task<Evento> GetByIDAsync (int id)
        {
            return await _context.Eventos.FirstOrDefaultAsync(evento => evento.EventoId == id);
            //.Where(evento => evento.EventoId == id);
        }
    
        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put, id: {id} ";
        }
        [HttpDelete]
        public string Delete()
        {
            return "Exemplo de Delete";
        }
    }
}
