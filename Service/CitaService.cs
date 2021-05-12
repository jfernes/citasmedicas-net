using citasmedicas.Models;
using citasmedicas.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public class CitaService : ICitaService
    {
        private CMDBContext DBContext;

        public CitaService(CMDBContext dbContext) => DBContext = dbContext;

        public bool AddDiagnostico(long citaId, Diagnostico diagnostico)
        {
            Cita c = FindById(citaId);
            if (c != null && diagnostico != null)
            {
                DBContext.Diagnosticos.Add(diagnostico);
                c.Diagnostico = diagnostico;
                DBContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteById(long id)
        {
            Cita c = FindById(id);
            if (c != null)
            {
                DBContext.Citas.Remove(c);
                DBContext.SaveChanges();
            }
        }

        public ICollection<Cita> FindAll() => (ICollection<Cita>)DBContext.Citas.Include(c => c.Diagnostico);

        public Cita FindById(long id) => DBContext.Citas.Find(id);


        public ICollection<Cita> FindByMedico(long id) => (ICollection<Cita>)DBContext.Citas.Where(c => c.Medico.Id == id);

        public ICollection<Cita> FindByPaciente(long id) => (ICollection<Cita>) DBContext.Citas.Where(c => c.Paciente.Id == id);

        public bool Save(Cita cita)
        {
            if (cita is null)
                return false;
            Medico m = DBContext.Medicos.Find(cita.Medico.Id);
            Paciente p = DBContext.Pacientes.Find(cita.Paciente.Id);
            if (m is null || p is null)
                return false;
            DBContext.Citas.Add(cita);
            DBContext.SaveChanges();
            return true;
        }
    }
}
