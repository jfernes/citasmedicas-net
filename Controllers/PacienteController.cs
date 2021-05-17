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
    [Route("pacientes")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private IPacienteService Service;
        private readonly IMapper Mapper;

        public PacienteController(IPacienteService service, IMapper mapper)
        {
            this.Service = service;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Read()
        {
            IList<PacienteDTO> pacientesDTO = new List<PacienteDTO>();
            foreach (Paciente p in Service.FindAll())
            {
                pacientesDTO.Add(Mapper.Map<PacienteDTO>(p));
            }
            return Ok(new MessageDTO(200, pacientesDTO));
        }

        [HttpPost]
        public IActionResult Create(PacienteDTO pacienteDTO)
        {
            if (Service.Save(Mapper.Map<Paciente>(pacienteDTO)))
                return Ok(new MessageDTO(200, "El paciente se ha registrado correctamente"));
            return Ok(new MessageDTO(412, "El paciente ya existe"));
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            Paciente p = Service.FindById(id);
            if (p is null)
                return Ok(new MessageDTO(404, "El paciente no existe"));
            return Ok(new MessageDTO(200, Mapper.Map<PacienteDTO>(p)));

        }

        [HttpGet("u/{usuario}")]
        public IActionResult FindByUsuario(string usuario)
        {
            Paciente p = Service.FindByUsuario(usuario);
            if (p is null)
                return Ok(new MessageDTO(404, "El paciente no existe"));
            return Ok(new MessageDTO(200, Mapper.Map<PacienteDTO>(p)));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Service.DeleteById(id);
            return Ok(new MessageDTO(200, "Paciente eliminado correctamente"));
        }

        [HttpPut]
        public IActionResult AddMedico(MedicoPacienteDTO medpac)
        {
            if (Service.AddMedico(medpac.PacienteId, medpac.MedicoId))
                return Ok(new MessageDTO(200, "Medico añadido correctamente"));
            return Ok(new MessageDTO(404, "El paciente o el médico no existe"));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            Paciente p = Service.Login(login.Usuario, login.Clave);
            if (p is null)
                return Ok(new MessageDTO(404, "El paciente no existe"));
            return Ok(new MessageDTO(200, Mapper.Map<PacienteDTO>(p)));
        }
        
    }
}
