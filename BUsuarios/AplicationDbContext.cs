using BUsuarios.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUsuarios
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuarios_Roles> Usuarios_Roles { get; set; } 

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

    }


}