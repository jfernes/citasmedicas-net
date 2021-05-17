using citasmedicas.Models;
using citasmedicas.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public class MedicoService : IMedicoService
    {
        private CMDBContext DBContext;

        public MedicoService(CMDBContext dbContext) => DBContext = dbContext;
        
        public bool AddPaciente(long medicoId, long pacienteId)
        {
            Medico m = FindById(medicoId);
            Paciente p = DBContext.Pacientes.Find(pacienteId);
            if (p is null || m is null || m.Pacientes.Contains(p))
                return false;
            m.Pacientes.Add(p);
            DBContext.SaveChanges();
            return true;
        }

        public void DeleteById(long id)
        {
            Medico m = FindById(id);
            if (m != null)
            {
                DBContext.Medicos.Remove(m);
                DBContext.SaveChanges();
            }
        }

        public IEnumerable<Medico> FindAll() => DBContext.Medicos.Include(m => m.Pacientes);

        public Medico FindById(long id) => DBContext.Medicos.Find(id);

        public Medico FindByUsuario(string usuario) => DBContext.Medicos.SingleOrDefault(m => m.User == usuario);
       
        public Medico Login(string usuario, string clave)
        {
            Medico m = FindByUsuario(usuario);
            if (m is null || m.Clave != clave)
                return null;
            return m;
        }

        public bool Save(Medico medico)
        {
            if (medico is null || FindByUsuario(medico.User) != null)
                return false;
            DBContext.Medicos.Add(medico);
            DBContext.SaveChanges();
            return true;                
        }
    }
}
