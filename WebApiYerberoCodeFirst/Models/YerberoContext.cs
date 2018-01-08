using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApiYerberoCodeFirst.Models
{
    public class YerberoContext :DbContext
    {
        public YerberoContext() : base("name=YerberoDataBase")
        {
            Database.SetInitializer<YerberoContext>(new CreateDatabaseIfNotExists<YerberoContext>());
        }

        public DbSet<Empleado> Empleados { set; get; }
        public DbSet<Yerba> Yerbas { get; set; }
        public DbSet<Oficina> Oficinas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("Admin");

            // Eliminando la convencion para la pluralizacion de nombres de tablas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Map entity to table
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
            modelBuilder.Entity<Yerba>().ToTable("Yerba");
            modelBuilder.Entity<Oficina>().ToTable("Oficina");

            // Establecer primary Key de las tablas
            modelBuilder.Entity<Oficina>().HasKey(t => t.OficinaId);
            modelBuilder.Entity<Empleado>().HasKey(t => t.EmpleadoId);
            modelBuilder.Entity<Yerba>().HasKey(t=> new { t.YerbaId,});
        }
    }
}



