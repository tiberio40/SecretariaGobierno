using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecretariaGobierno.Models
{
    public class Establecimiento
    {
        [Key]
        public int EstablecimientoID { get; set; }

        [Required]
        [Display(Name = "Nombre del Establecimiento")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Nombre del Propietario")]
        public string Propietario { get; set; }

        [Required]
        [Display(Name = "Dirección del Establecimiento")]
        public string Direccion { get; set; }

        public string UserName { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Instancia> Instancia { get; set; }
    }
}