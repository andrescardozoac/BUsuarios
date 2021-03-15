using BUsuarios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuarios_RolesController : ControllerBase

    {

        private readonly AplicationDbContext _context;

        public Usuarios_RolesController (AplicationDbContext context)
        {

            _context = context;
        }

        // GET: api/<Usuarios_RolesController>
        [HttpGet]
        public async Task <IActionResult> Get()
        {

            try
            {
                //var listarRolesUsuarios = await _context.Usuarios_Roles.ToListAsync();


                var listarUsuariosroles = await (from usuarios in _context.Usuarios.DefaultIfEmpty()
                                                 join usuariosroles in _context.Usuarios_Roles
                                          on usuarios.idUsuario equals usuariosroles.idUsuario
                                                 join roles in _context.Roles
                                                 on usuariosroles.idRol equals roles.idRol

                                                 select new
                                                 {
                                                     usuariosroles.idUsuarios_Roles,
                                                     usuarios.idUsuario,
                                                     usuarios.login,
                                                     usuarios.nombre,
                                                     usuarios.password,
                                                     roles.idRol,
                                                     roles.nombreRol
                                                  


                                                 }


                              ).ToListAsync();



                return Ok(listarUsuariosroles);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        // POST api/<Usuarios_RolesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuarios_Roles rolUsuario)
        {

            try
            {

                _context.Add(rolUsuario);
                await _context.SaveChangesAsync();
                return Ok(rolUsuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<Usuarios_RolesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Usuarios_Roles rolUsuario)
        {

            try
            {

                if (id != rolUsuario.idUsuarios_Roles)
                {
                    return NotFound();

                }

                _context.Update(rolUsuario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Rol - Usuario Actualizado" });

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        // DELETE api/<Usuarios_RolesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var rolUsuario = await _context.Usuarios_Roles.FindAsync(id);

                if (rolUsuario == null)
                {

                    return NotFound();

                }

                _context.Usuarios_Roles.Remove(rolUsuario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Rol - Usuario Eliminado" });


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
