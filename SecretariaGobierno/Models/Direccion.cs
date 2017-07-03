using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecretariaGobierno.Models
{
    public class Direccion
    {
        [Key]
        public int DireccionID { get; set; }

        public string Direcciones { get; set; }

        public int EstablecimientoID { get; set; }
        public virtual Establecimiento Establecimiento { get; set; }
    }
}