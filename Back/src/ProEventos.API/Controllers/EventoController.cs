using System;
using System.Collections.Generic;
using System.Linq;
using       Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {   
        public IEnumerable<Evento> _evento = new Evento[]
            {
                new Evento() {
                    EventoId = 1,
                    Local = "São Paulo",
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yy HH:mm"),
                    Tema = "Aniversário",
                    QtdPessoas = 100,
                    Lote = "2º Lote",
                    ImagemUrl = "foto.png"
                },
                 new Evento() {
                    EventoId = 2,
                    Local = "Diadema",
                    DataEvento = DateTime.Now.AddDays(7).AddHours(5).ToString("dd/MM/yy HH:mm"),
                    Tema = "Casamento",
                    QtdPessoas = 1250,
                    Lote = "4º Lote",
                    ImagemUrl = "foto.png"
                }
            };

        public EventoController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }
        
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetByID(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
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
