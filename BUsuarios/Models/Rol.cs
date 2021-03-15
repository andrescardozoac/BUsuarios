using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BUsuarios.Models
{
    public class Rol
    {

        [Key]
        public int idRol { get; set; }

        [Required]
        public string nombreRol { get; set; }
    }
}
