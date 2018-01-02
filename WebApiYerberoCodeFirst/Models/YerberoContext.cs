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
        public DbSet<Empleado> empleados { set; get; }
        public DbSet<Yerba> yerbas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("Admin");

            // Eliminando la convencion para la pluralizacion de nombres de tablas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Map entity to table
            modelBuilder.Entity<Empleado>().ToTable("EmpleadoInfo");
            modelBuilder.Entity<Yerba>().ToTable("YerbaInfo");

            // Establecer primary Key de las tablas
            modelBuilder.Entity<Empleado>().HasKey(t => t.idEmpleado);
            modelBuilder.Entity<Yerba>().HasKey(t=> new { t.idYerba,});

            


        }
    }
}



