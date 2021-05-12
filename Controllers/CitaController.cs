using citasmedicas.DTO;
using citasmedicas.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Controllers
{
    [Route("citas")]
    [ApiController]
    public class CitaController
    {
        
        private ICitaService Service;
        private IPacienteService PService;
        private IMedicoService MService;

        public CitaController(ICitaService service, IPacienteService pService, IMedicoService mService)
        {
            Service = service;
            PService = pService;
            MService = mService;
        }
        /*
        [HttpPost]
        public MessageDTO Create(CitaDTO citaDTO)
        {
            //llamar a addPaciente y addMedico
        }

        [HttpGet]
        public MessageDTO Read()
        {

        }

        [HttpGet("/{id}")]
        public MessageDTO FindByID(long id)
        {

        }

        [HttpGet("/medico/{id}")]
        public MessageDTO FindByMedico(long id)
        {

        }

        [HttpGet("/paciente/{id}")]
        public MessageDTO FindByPaciente(long id)
        {

        }

        [HttpGet("/diagnostico/{id}")]
        public MessageDTO GetDiagnosticoByCita(long id)
        {

        }

        [HttpDelete("/{id}")]
        public MessageDTO Delete(long id)
        {
         
        }
        */
    }
}
