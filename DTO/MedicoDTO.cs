using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.DTO
{
    public class MedicoDTO
    {
        public long Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Usuario { get; set; }

        public string Clave { get; set; }

        public string NumColegiado { get; set; }

        public ICollection<long> Pacientes { get; set; }
    }
}
