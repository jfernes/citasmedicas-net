using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.DTO
{
    public class CitaDTO
    {
        public long Id { get; set; }

        public string FechaHora { get; set; }

        public string MotivoCita { get; set; }

        public long Diagnostico { get; set; }

        public long Paciente { get; set; }

        public long Medico { get; set; }
    }
}
