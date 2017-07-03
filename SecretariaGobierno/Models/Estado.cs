using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecretariaGobierno.Models
{
    public class Estado
    {
        [Key]
        public int EstadoID { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<Instancia> Instancia { get; set; }
    }
}