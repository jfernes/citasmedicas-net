using citasmedicas.DTO;
using citasmedicas.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Controllers
{
    [Route("/medicos")]
    [ApiController]
    public class MedicoController
    {
        public IMedicoService Service;

        public MedicoController(IMedicoService service)
        {
            this.Service = service;
        }

        /*
        [HttpGet]
        public MessageDTO Read()
        {

        }

        [HttpPost]
        public MessageDTO Create(MedicoDTO medicoDTO)
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
        public MessageDTO AddPaciente(PacienteDTO pacienteDTO)
        {

        }

        [HttpPost("/login")]
        public MessageDTO Login(MedicoDTO medicoDTO)
        {

        }
        */
    }
}
