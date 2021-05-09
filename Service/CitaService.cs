using citasmedicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public class CitaService : ICitaService
    {
        public bool AddDiagnostico(long citaId, Diagnostico diagnostico)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Cita> FindAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Cita> FindById()
        {
            throw new NotImplementedException();
        }

        public ICollection<Cita> FindByMedico()
        {
            throw new NotImplementedException();
        }

        public ICollection<Cita> FindByPaciente()
        {
            throw new NotImplementedException();
        }

        public bool Save(Cita cita)
        {
            throw new NotImplementedException();
        }
    }
}
