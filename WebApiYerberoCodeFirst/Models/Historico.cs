using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApiYerberoCodeFirst.Models
{
    public class Historico
    {
        [Key]
        public int  idLog {set; get;}
        public String descripcion { set; get; }
    }
}