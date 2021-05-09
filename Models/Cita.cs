using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Models
{
    public class Cita
    {
        [Key]
        public long Id { get; set; }
     
        public DateTime FechaHora { get; set; }

        public string MotivoCita { get; set; }

        public Diagnostico Diagnostico { get; set;  }

        public Medico Medico { get; set; }

        public Paciente Paciente { get; set; }

    }
}
