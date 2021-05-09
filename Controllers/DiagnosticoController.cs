using citasmedicas.DTO;
using citasmedicas.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Controllers
{
    [Route("/diagnosticos")]
    [ApiController]
    public class DiagnosticoController
    {
        public IDiagnosticoService service;

        public DiagnosticoController(IDiagnosticoService service)
        {
            this.service = service;
        }

        /*
        [HttpGet]
        public MessageDTO Read()
        {

        }

        [HttpPost]
        public MessageDTO Create(DiagnosticoDTO diagDTO)
        {

        }

        [HttpGet("/{id}")]
        public MessageDTO FindById(long id)
        {

        }

        [HttpDelete("/{id}")]
        public MessageDTO Delete(long id)
        {

        }
        */
    }
}
