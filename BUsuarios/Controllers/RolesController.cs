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
    public class RolesController : ControllerBase
    {

        private readonly AplicationDbContext _context;

        public RolesController(AplicationDbContext context)
        {

            _context = context;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var listarRoles = await _context.Roles.ToListAsync();

                
                  
               return Ok(listarRoles);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }


        // POST api/<RolesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rol rol)
        {

            try
            {

                _context.Add(rol);
                await _context.SaveChangesAsync();
                return Ok(rol);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Rol rol)
        {

            try
            {

                if (id != rol.idRol)
                {
                    return NotFound();

                }

                _context.Update(rol);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Rol Actualizado" });

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var rol = await _context.Roles.FindAsync(id);

                if (rol == null)
                {

                    return NotFound();

                }

                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Rol Eliminado" });


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



    }
}
