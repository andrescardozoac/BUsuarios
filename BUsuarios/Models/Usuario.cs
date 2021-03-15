using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BUsuarios.Models
{
    public class Usuario
    {

        [Key]
        public int idUsuario { get; set; }

        [Required]
        public string login { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string nombre { get; set; }


    }
}
