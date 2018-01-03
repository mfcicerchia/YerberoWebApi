using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations; /* Consultar */

namespace WebApiYerberoCodeFirst.Models
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }
        public int Dni { get; set; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }

    }
}