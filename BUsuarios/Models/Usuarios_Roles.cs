using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BUsuarios.Models
{
    public class Usuarios_Roles
    {
        [Key]
        public int idUsuarios_Roles { get; set; }

        [Required]
        public int idUsuario { get; set; }

        [Required]
        public int idRol { get; set; }
    }
}
