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
        private IMedicoService MService;
        private IPacienteService PService;

        public CitaService(CMDBContext dbContext, IDiagnosticoService dService,
            IMedicoService mService, IPacienteService pService)
        {
            DBContext = dbContext;
            DService = dService;
            MService = mService;
            PService = pService;
        }

        public bool AddDiagnostico(long citaId, Diagnostico diagnostico)
        {
            Cita c = FindById(citaId);
            if (c != null && diagnostico != null)
            {
                //DService.Save(diagnostico);
                DBContext.Add(diagnostico);
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

        public IEnumerable<Cita> FindAll() => DBContext.Citas
            .Include(c => c.Diagnostico)
            .Include(c => c.Medico)
            .Include(c => c.Paciente);

        public Cita FindById(long id) => DBContext.Citas.Where(c => c.Id == id)
            .Include(c => c.Paciente)
            .Include(c => c.Medico)
            .Include(c => c.Diagnostico)
            .FirstOrDefault();


        public IEnumerable<Cita> FindByMedico(long id)
        {
            var response = DBContext.Citas.Where(c => c.Medico.Id == id).FirstOrDefault();
            if (response is null)
                return new List<Cita>();
            return DBContext.Citas.Where(c => c.Medico.Id == id)
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Include(c => c.Diagnostico);
        }

        public IEnumerable<Cita> FindByPaciente(long id) 
        {
            var response = DBContext.Citas.Where(c => c.Paciente.Id == id).FirstOrDefault();
            if (response is null)
                return new List<Cita>();
            return DBContext.Citas.Where(c => c.Paciente.Id == id)
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Include(c => c.Diagnostico);
        }

        public bool Save(Cita cita, long medicoId, long pacienteId)
        {
            if (cita is null)
                return false;
            Medico m = MService.FindById(medicoId);
            Paciente p = PService.FindById(pacienteId);
            if (m is null || p is null)
                return false;
            cita.Medico = m;
            cita.Paciente = p;
            cita.Diagnostico = null;
            PService.AddMedico(pacienteId, medicoId);
            DBContext.Citas.Add(cita);
            DBContext.SaveChanges();
            return true;
        }
    }
}
