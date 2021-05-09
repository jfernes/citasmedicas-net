using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.DTO
{
    public class UsuarioDTO
    {
        public long  id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Usuario { get; set; }

        public string clave { get; set; }
    }
}
