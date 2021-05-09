using citasmedicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public class PacienteService : IPacienteService
    {
        public bool AddMedico(long pacienteId, long medicoId)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Paciente> FindAll()
        {
            throw new NotImplementedException();
        }

        public Paciente FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Paciente FindByUsuario(string usuario)
        {
            throw new NotImplementedException();
        }

        public ICollection<Medico> FindMedicos(long id)
        {
            throw new NotImplementedException();
        }

        public Paciente Login(string usuario, string clave)
        {
            throw new NotImplementedException();
        }

        public bool Save(Paciente paciente)
        {
            throw new NotImplementedException();
        }
    }
}
