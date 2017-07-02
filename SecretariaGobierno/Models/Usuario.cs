using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecretariaGobierno.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }



        [Required]
        [Display(Name = "Nombre y Apellidos")]
        public string Nombres { get; set; }


        [Required]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }

        public virtual ICollection<Usuario_Roles> Usuario_Roles { get; set; }
    }
}