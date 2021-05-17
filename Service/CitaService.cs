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
        private IDiagnosticoService DService;

        public CitaService(CMDBContext dbContext, IDiagnosticoService dService)
        {
            DBContext = dbContext;
            DService = dService;
        }

        public bool AddDiagnostico(long citaId, long diagnosticoId)
        {
            Cita c = FindById(citaId);
            Diagnostico d = DService.FindById(diagnosticoId);
            if (c != null && d != null)
            {
                DBContext.Diagnosticos.Add(d);
                c.Diagnostico = d;
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


        public IEnumerable<Cita> FindByMedico(long id)
        {
            var response = DBContext.Citas.Where(c => c.Medico.Id == id).FirstOrDefault();
            if (response is null)
                return new List<Cita>();
            return DBContext.Citas.Where(c => c.Medico.Id == id);
        }

        public IEnumerable<Cita> FindByPaciente(long id) 
        {
            var response = DBContext.Citas.Where(c => c.Medico.Id == id).FirstOrDefault();
            if (response is null)
                return new List<Cita>();
            return DBContext.Citas.Where(c => c.Medico.Id == id);
        }

        public bool Save(Cita cita, long medicoId, long pacienteId)
        {
            if (cita is null)
                return false;
            Medico m = DBContext.Medicos.Find(medicoId);
            Paciente p = DBContext.Pacientes.Find(pacienteId);
            if (m is null || p is null)
                return false;
            cita.Medico = m;
            cita.Paciente = p;
            cita.Diagnostico = null;
            DBContext.Citas.Add(cita);
            DBContext.SaveChanges();
            return true;
        }
    }
}
