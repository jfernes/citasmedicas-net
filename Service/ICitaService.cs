using citasmedicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public interface ICitaService
    {
        public ICollection<Cita> FindAll();

        public ICollection<Cita> FindByMedico(long id);

        public ICollection<Cita> FindByPaciente(long id);

        public Cita FindById(long id);

        public bool Save(Cita cita);

        public bool AddDiagnostico(long citaId, Diagnostico diagnostico);

        public void DeleteById(long id);
    }
}
