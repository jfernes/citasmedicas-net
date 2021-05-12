using citasmedicas.Models;
using citasmedicas.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Service
{
    public class UsuarioService : IUsuarioService
    {
        private CMDBContext DBContext;

        public UsuarioService(CMDBContext dbContext) => DBContext = dbContext;
        public void DeleteById(long id)
        {
            Usuario u = FindById(id);
            if (u != null)
            {
                DBContext.Usuarios.Remove(u);
                DBContext.SaveChanges();
            }
        }

        public ICollection<Usuario> FindAll() => (ICollection<Usuario>)DBContext.Usuarios;

        public Usuario FindById(long id) => DBContext.Usuarios.Find(id);


        public bool Save(Usuario usuario)
        {
            if (usuario is null)
                return false;
            DBContext.Usuarios.Add(usuario);
            DBContext.SaveChanges();
            return true;
        }
    }
}
