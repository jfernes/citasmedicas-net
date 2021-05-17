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
    [Route("/diagnosticos")]
    [ApiController]
    public class DiagnosticoController : ControllerBase
    {
        private IDiagnosticoService Service;
        private ICitaService CService;
        private IMapper Mapper;

        public DiagnosticoController(IDiagnosticoService service, ICitaService cService, IMapper mapper)
        {
            Service = service;
            CService = cService;
            Mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult Read()
        {
            IList<DiagnosticoDTO> diagnosticosDTO = new List<DiagnosticoDTO>();
            foreach (Diagnostico d in Service.FindAll())
            {
                diagnosticosDTO.Add(Mapper.Map<DiagnosticoDTO>(d));
            }
            return Ok(new MessageDTO(200, diagnosticosDTO));
        }

        [HttpPost]
        public IActionResult Create(DiagnosticoDTO diagDTO)
        {
            if (Service.Save(Mapper.Map<Diagnostico>(diagDTO)))
                return Ok(new MessageDTO(200, "El diagnóstico se ha registrado correctamente"));

            return Ok(new MessageDTO(412, "El diagnóstico ya existe"));
            //citas addDiagnostico para actualizar
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            Diagnostico d = Service.FindById(id);
            if (d is null)
                return Ok(new MessageDTO(404, "El diagnostico no existe"));
            return Ok(new MessageDTO(200, Mapper.Map<DiagnosticoDTO>(d)));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Service.DeleteById(id);
            return Ok(new MessageDTO(200, "Diagnóstico eliminado correctamente"));
        }
        
    }
}
