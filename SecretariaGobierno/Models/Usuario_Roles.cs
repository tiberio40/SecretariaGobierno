using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecretariaGobierno.Models
{
    public class Usuario_Roles
    {
        [Key]
        public int Usuario_RolesID { get; set; }

        public int RolesUsuarioID { get; set; }
        public string UserName { get; set; }


        public virtual RolesUsuario RolesUsuarios { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}