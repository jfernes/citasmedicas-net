using citasmedicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public interface ICitaService
    {
        public IEnumerable<Cita> FindAll();

        public IEnumerable<Cita> FindByMedico(long id);

        public IEnumerable<Cita> FindByPaciente(long id);

        public Cita FindById(long id);

        public bool Save(Cita cita, long medicoId, long pacienteId);

        public bool AddDiagnostico(long citaId, Diagnostico diagnostico);

        public void DeleteById(long id);
    }
}
