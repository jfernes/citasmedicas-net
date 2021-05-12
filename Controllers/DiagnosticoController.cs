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
        private IDiagnosticoService Service;
        private ICitaService CService;

        public DiagnosticoController(IDiagnosticoService service, ICitaService cService)
        {
            Service = service;
            CService = cService;
        }

        /*
        [HttpGet]
        public MessageDTO Read()
        {

        }

        [HttpPost]
        public MessageDTO Create(DiagnosticoDTO diagDTO)
        {
            //citas addDiagnostico para actualizar
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
