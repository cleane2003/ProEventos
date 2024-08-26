using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ProEventos.Api.Data;
using ProEventos.Api.Models;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public readonly DataContext _context;

        public EventoController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
            
        }

        [HttpPost]
        public string Post()
        {
            return "exemplo";
        }

        [HttpPut]
        public string Put()
        {
            return "exemplo";
        }

        [HttpDelete]
        public string Delete()
        {
            return "exemplo";
        }
    }
}
