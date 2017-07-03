using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecretariaGobierno.Models
{
    public class Observacion
    {
        [Key]
        public int ObservacionID { get; set; }

        public string Anotacion { get; set; }

        public int InstanciaID { get; set; }
        public virtual Instancia Instancia { get; set;}

    }
}