using citasmedicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public interface IDiagnosticoService
    {
		public ICollection<Diagnostico> FindAll();

		public Diagnostico FindById(long id);

		public bool Save(Diagnostico diagnostico);

		public void DeleteById(long id);
	}
}
