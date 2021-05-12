using citasmedicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public interface IMedicoService
    {
		public ICollection<Medico> FindAll();

		public Medico FindById(long id);

		public bool Save(Medico medico);

		public void DeleteById(long id);

		public bool AddPaciente(long medicoId, long pacienteId);

		public Medico FindByUsuario(string usuario);

		public Medico Login(string usuario, string clave);
	}
}
