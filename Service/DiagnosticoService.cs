using citasmedicas.Models;
using citasmedicas.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public class DiagnosticoService : IDiagnosticoService
    {
        private CMDBContext DBContext;

        public DiagnosticoService(CMDBContext dbContext) => DBContext = dbContext;
        public void DeleteById(long id)
        {
            Diagnostico d = FindById(id);
            if (d != null)
            {
                DBContext.Diagnosticos.Remove(d);
                DBContext.SaveChanges();
            }
        }

        public IEnumerable<Diagnostico> FindAll() => DBContext.Diagnosticos;

        public Diagnostico FindById(long id) => DBContext.Diagnosticos.Find(id);
       

        public bool Save(Diagnostico diagnostico)
        {
            if (diagnostico is null)
                return false;
            DBContext.Diagnosticos.Add(diagnostico);
            DBContext.SaveChanges();
            return true;
        }
    }
}
