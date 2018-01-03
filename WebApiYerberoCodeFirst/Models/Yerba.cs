using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApiYerberoCodeFirst.Models
{
    public class Yerba
    {
        [Key]
        public int YerbaId { set; get; }
        public string Nombre { set; get; }
        public string Marca { set; get; }
        float Peso { set; get; }
        public DateTime FechaIngreso { set; get; }
        public DateTime FechaApertura { set; get; }
        public DateTime FechaAgotada { set; get; }
    }
}