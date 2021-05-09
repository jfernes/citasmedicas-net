using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Models
{
    [Table("Medicos")]
    public class Medico : Usuario
    {
        public string NumColegiado { get; set; }

        public ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
    }
}
