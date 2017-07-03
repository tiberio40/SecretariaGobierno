﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SecretariaGobierno.Models
{
    public class SecretariaGobiernoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SecretariaGobiernoContext() : base("name=SecretariaGobiernoContext")
        {

        }



        public System.Data.Entity.DbSet<SecretariaGobierno.Models.RolesUsuario> RolesUsuarios { get; set; }

        public System.Data.Entity.DbSet<SecretariaGobierno.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<SecretariaGobierno.Models.Usuario_Roles> Usuario_Roles { get; set; }

        public System.Data.Entity.DbSet<SecretariaGobierno.Models.Establecimiento> Establecimientos { get; set; }

        public System.Data.Entity.DbSet<SecretariaGobierno.Models.Direccion> Direccions { get; set; }

        public System.Data.Entity.DbSet<SecretariaGobierno.Models.Instancia> Instancias { get; set; }

        public System.Data.Entity.DbSet<SecretariaGobierno.Models.Estado> Estadoes { get; set; }

        public System.Data.Entity.DbSet<SecretariaGobierno.Models.Observacion> Observacions { get; set; }
    }
}
