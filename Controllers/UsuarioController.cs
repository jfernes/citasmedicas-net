using citasmedicas.DTO;
using citasmedicas.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Controllers
{
    [Route("/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IUsuarioService service;

        public UsuarioController(IUsuarioService service) 
        {
            this.service = service;
        }
        /*
        [HttpGet]
        public MessageDTO Read()
        {

        }

        [HttpPost]
        public MessageDTO Create(UsuarioDTO usuarioDTO)
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
