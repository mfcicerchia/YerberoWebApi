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
        public int idEmpleado { get; set; }
        public int dni { get; set; }
        public string nombre { set; get; }
        public string apellido { set; get; }

    }
}