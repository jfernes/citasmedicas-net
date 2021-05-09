using citasmedicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public interface IPacienteService
    {
		public ICollection<Paciente> FindAll();

		public Paciente FindById(long id);

		public bool Save(Paciente paciente);

		public void DeleteById(long id);

		public ICollection<Medico> FindMedicos(long id);

		public bool AddMedico(long pacienteId, long medicoId);

		public Paciente FindByUsuario(string usuario);

		public Paciente Login(string usuario, string clave);
	}
}
