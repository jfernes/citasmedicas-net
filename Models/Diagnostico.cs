using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Models
{
    public class Diagnostico
    {
        [Key]
        public long Id { get; set; }

        public string ValoracionEspecialista { get; set; }

        public string Enfermedad { get; set; }
    }
}
