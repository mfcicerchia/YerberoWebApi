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
        public int idYerba { set; get; }
       public string nombre { set; get; }

        public string marca { set; get; }
        float peso { set; get; }
        public DateTime fechaIngreso { set; get; }

        public DateTime fechaApertura { set; get; }

        public DateTime fechaAgotada { set; get; }

    }
}