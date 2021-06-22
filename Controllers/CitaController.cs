using AutoMapper;
using citasmedicas.DTO;
using citasmedicas.Models;
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
    public class CitaController : ControllerBase
    {
        
        private ICitaService Service;
        private IPacienteService PService;
        private IMedicoService MService;
        private IMapper Mapper;

        public CitaController(ICitaService service, IPacienteService pService, 
            IMedicoService mService, IMapper mapper)
        {
            Service = service;
            PService = pService;
            MService = mService;
            Mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult Create(CitaDTO citaDTO)
        {
            if (Service.Save(Mapper.Map<Cita>(citaDTO), citaDTO.Medico, citaDTO.Paciente))
            {
                return Ok(new MessageDTO(200, "Cita creada correctamente"));
            }
            return Ok(new MessageDTO(412, "La cita ya existe"));
        }

        [HttpGet]
        public IActionResult Read()
        {
            IList<CitaDTO> citasDTO = new List<CitaDTO>();
            foreach (Cita c in Service.FindAll())
            {
                citasDTO.Add(Mapper.Map<CitaDTO>(c));
            }
            return Ok(new MessageDTO(200, citasDTO));
        }

        [HttpGet("{id}")]
        public IActionResult FindByID(long id)
        {
            Cita c = Service.FindById(id);
            if (c is null)
                return Ok(new MessageDTO(404, "La cita no existe"));
            return Ok(new MessageDTO(200, Mapper.Map<CitaDTO>(c)));
        }

        [HttpGet("medico/{id}")]
        public IActionResult FindByMedico(long id)
        {
            IList<CitaDTO> citasDTO = new List<CitaDTO>();
            foreach(Cita c in Service.FindByMedico(id))
            {
                citasDTO.Add(Mapper.Map<CitaDTO>(c));
            }
            return Ok(new MessageDTO(200, citasDTO));

        }

        [HttpGet("paciente/{id}")]
        public IActionResult FindByPaciente(long id)
        {
            IList<CitaDTO> citasDTO = new List<CitaDTO>();
            foreach (Cita c in Service.FindByPaciente(id))
            {
                citasDTO.Add(Mapper.Map<CitaDTO>(c));
            }
            return Ok(new MessageDTO(200, citasDTO));
        }

        [HttpGet("diagnostico/{id}")]
        public IActionResult GetDiagnosticoByCita(long id)
        {
            Cita c = Service.FindById(id);
            if (c is null || c.Diagnostico is null)
                return Ok(new MessageDTO(404, "La cita o el diagnóstico no existen"));
            return Ok(new MessageDTO(200, Mapper.Map<DiagnosticoDTO>(c.Diagnostico)));
        }

        [HttpPost("diagnostico/{id}")]
        public IActionResult AddDiagnostico(long id, DiagnosticoDTO diagnosticoDTO)
        {
            if (Service.AddDiagnostico(id, Mapper.Map<Diagnostico>(diagnosticoDTO)))
            {
                return Ok(new MessageDTO(200, "Diagnóstico añadido correctamente"));
            }
            return Ok(new MessageDTO(404, "Cita o diagnóstico no existen"));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Service.DeleteById(id);
            return Ok(new MessageDTO(200, "Cita eliminada correctamente"));
        }
        
    }
}
