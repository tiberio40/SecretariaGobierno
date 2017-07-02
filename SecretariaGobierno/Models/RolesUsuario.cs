using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecretariaGobierno.Models
{
    public class RolesUsuario
    {
        [Key]
        public int RolesUsuarioID { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<Usuario_Roles> Usuario_Roles { get; set; }
    }
}