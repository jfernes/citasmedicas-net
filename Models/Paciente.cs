using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Models
{
    [Table("Pacientes")]
    public class Paciente : Usuario
    {
        public string Nss { get; set; }

        public string NumTarjeta { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public ICollection<Medico> Medicos { get; set; } = new List<Medico>();


    }
}
