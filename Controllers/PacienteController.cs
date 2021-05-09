using citasmedicas.DTO;
using citasmedicas.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Controllers
{
    [Route("/pacientes")]
    [ApiController]
    public class PacienteController
    {
        public IPacienteService Service;

        public PacienteController(IPacienteService service)
        {
            this.Service = service;
        }
        /*
        [HttpGet]
        public MessageDTO Read()
        {

        }

        [HttpPost]
        public MessageDTO Create(PacienteDTO pacienteDTO)
        {

        }

        [HttpGet("/{id}")]
        public MessageDTO FindById(long id)
        {

        }

        [HttpGet("/u/{usuario}")]
        public MessageDTO FindByUsuario(string usuario)
        {

        }

        [HttpDelete("/{id}")]
        public MessageDTO Delete(long id)
        {

        }

        [HttpPut]
        public MessageDTO AddMedico(MedicoDTO medicoDTO)
        {

        }

        [HttpPost("/login")]
        public MessageDTO Login(PacienteDTO pacienteDTO)
        {

        }
        */
    }
}
