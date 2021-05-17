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
    [Route("medicos")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        public IMedicoService Service;
        private readonly IMapper Mapper;

        public MedicoController(IMedicoService service, IMapper mapper)
        {
            this.Service = service;
            this.Mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult Read()
        {
            IList<MedicoDTO> medicosDTO = new List<MedicoDTO>();
            foreach (Medico m in Service.FindAll())
            {
                medicosDTO.Add(Mapper.Map<MedicoDTO>(m));
            }
            return Ok(new MessageDTO(200, medicosDTO));
        }

        [HttpPost]
        public IActionResult Create(MedicoDTO medicoDTO)
        {
            if (Service.Save(Mapper.Map<Medico>(medicoDTO)))
                return Ok(new MessageDTO(200, "El médico se ha registrado correctamente"));
            return Ok(new MessageDTO(412, "El médico ya existe"));
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            Medico m = Service.FindById(id);
            if (m is null)
                return Ok(new MessageDTO(404, "El médico no existe"));
            return Ok(new MessageDTO(200, Mapper.Map<MedicoDTO>(m)));
        }

        [HttpGet("u/{usuario}")]
        public IActionResult FindByUsuario(string usuario)
        {
            Medico m = Service.FindByUsuario(usuario);
            if (m is null)
                return Ok(new MessageDTO(404, "El médico no existe"));
            return Ok(new MessageDTO(200, Mapper.Map<MedicoDTO>(m)));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Service.DeleteById(id);
            return Ok(new MessageDTO(200, "Médico eliminado correctamente"));
        }

        [HttpPut]
        public IActionResult AddPaciente(MedicoPacienteDTO medpac)
        {
            if (Service.AddPaciente(medpac.MedicoId, medpac.PacienteId))
                return Ok(new MessageDTO(200, "Paciente añadido correctamente"));
            return Ok(new MessageDTO(404, "El paciente o el médico no existe"));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            Medico m = Service.Login(login.Usuario, login.Clave);
            if (m is null)
                return Ok(new MessageDTO(404, "El médico no existe"));
            return Ok(new MessageDTO(200, Mapper.Map<MedicoDTO>(m)));
        }
        
    }
}
