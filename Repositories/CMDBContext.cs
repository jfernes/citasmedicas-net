using Microsoft.EntityFrameworkCore;
using citasmedicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Repositories
{
    public class CMDBContext : DbContext
    {
        public CMDBContext(DbContextOptions<CMDBContext> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Medico> Medicos{ get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Cita> Citas { get; set; }

        public DbSet<Diagnostico> Diagnosticos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasAlternateKey(u => u.User)
                .HasName("User");
        }
    }
}
