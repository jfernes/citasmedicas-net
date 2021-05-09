using citasmedicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public class MedicoService : IMedicoService
    {
        public bool AddPaciente(long medicoId, long pacienteId)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Medico> FindAll()
        {
            throw new NotImplementedException();
        }

        public Medico FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Medico FindByUsuario(string usuario)
        {
            throw new NotImplementedException();
        }

        public ICollection<Paciente> FindPacientes(long id)
        {
            throw new NotImplementedException();
        }

        public Medico Login(string Usuario, string clave)
        {
            throw new NotImplementedException();
        }

        public bool Save(Medico medico)
        {
            throw new NotImplementedException();
        }
    }
}
