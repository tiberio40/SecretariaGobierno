using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecretariaGobierno.Models
{
    public class Instancia
    {
        [Key]   
        public int InstanciaID { get; set; }

        public int Folios { get; set; }

        [Required]
        [Display(Name = "Fecha Ultima Actuación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Actualizacion { get; set; }

        [Display(Name = "Nombre del Establecimiento")]
        public int EstablecimientoID { get; set; }
        public virtual Establecimiento Establecimiento { get; set; }

        [Display(Name = "Estado")]
        public int EstadoID { get; set; }

        [Display(Name = "Estado")]
        public virtual Estado Estado {get; set;}
        public virtual ICollection<Observacion> Observacion { get; set; }

    }
}