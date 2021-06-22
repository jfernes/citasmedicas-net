using citasmedicas.Models;
using citasmedicas.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public class PacienteService : IPacienteService
    {
        private CMDBContext DBContext;
        private IMedicoService MService;

        public PacienteService(CMDBContext dbContext, IMedicoService mService)
        {
            MService = mService;
            DBContext = dbContext;
        }

        public bool AddMedico(long pacienteId, long medicoId)
        {
            Paciente p = FindById(pacienteId);
            Medico m = MService.FindById(medicoId);
            if (p is null || m is null)
                return false;
            if (!p.Medicos.Contains(m))
                p.Medicos.Add(m);
            if (!m.Pacientes.Contains(p))
                m.Pacientes.Add(p);
            DBContext.SaveChanges();
            return true;
        }

        public void DeleteById(long id)
        {
            Paciente p = FindById(id);
            if (p != null)
            {
                DBContext.Pacientes.Remove(p);
                DBContext.SaveChanges();
            }
        }

        public IEnumerable<Paciente> FindAll() => DBContext.Pacientes.Include(p => p.Medicos);

        public Paciente FindById(long id) => DBContext.Pacientes.Where(p => p.Id == id).Include(p => p.Medicos).FirstOrDefault();

        public Paciente FindByUsuario(string usuario) => DBContext.Pacientes.Where(p => p.User == usuario).Include(p => p.Medicos).FirstOrDefault();

        public Paciente Login(string usuario, string clave)
        {
            Paciente p = FindByUsuario(usuario);
            if (p is null || p.Clave != clave)
                return null;
            return p;
        }

        public bool Save(Paciente paciente)
        {
            if (paciente is null || FindByUsuario(paciente.User) != null)
                return false;
            DBContext.Pacientes.Add(paciente);
            DBContext.SaveChanges();
            return true;
        }
    }
}
