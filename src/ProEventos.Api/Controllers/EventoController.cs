using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ProEventos.Api.Models;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[]
        {
            new Evento()
            {
                EventoId = 1,
                Tema = "Angular 11 e dotnet",
                Local = "Belo Horizonte",
                Lote = "1 lote",
                QtdPessoa = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                ImagemURL = "foto.png",
            },
            new Evento()
            {
                EventoId = 1,
                Tema = "Angular 11 e dotnet",
                Local = "Belo Horizonte",
                Lote = "1 lote",
                QtdPessoa = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                ImagemURL = "foto.png",
            }
        };

        public EventoController() { }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(_evento => _evento.EventoId == id);
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
