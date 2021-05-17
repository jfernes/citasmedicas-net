using citasmedicas.DTO;
using citasmedicas.Service;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using citasmedicas.Controllers.Mapper;
using citasmedicas.Models;

namespace citasmedicas.Controllers
{
    [Route("usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IUsuarioService Service;
        public IMapper Mapper;

        public UsuarioController(IUsuarioService service, IMapper mapper) 
        {
            this.Service = service;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Read()
        {
            IList<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            foreach (Usuario u in Service.FindAll())
            {
                usuariosDTO.Add(Mapper.Map<UsuarioDTO>(u));
            }
            return Ok(new MessageDTO(200, usuariosDTO));
        }

        [HttpPost]
        public IActionResult Create(UsuarioDTO usuarioDTO)
        {
            if (Service.Save(Mapper.Map<Usuario>(usuarioDTO)))
                return Ok(new MessageDTO(200, "El usuario se ha registrado correctamente"));
            return Ok(new MessageDTO(412, "El usuario ya existe"));
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            Usuario u = Service.FindById(id);
            if (u is null)
                return Ok(new MessageDTO(404, "El usuario no existe"));
            return Ok(new MessageDTO(200, Mapper.Map<UsuarioDTO>(u)));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Service.DeleteById(id);
            return Ok(new MessageDTO(200, "Usuario eliminado correctamente"));
        }
    }
}
