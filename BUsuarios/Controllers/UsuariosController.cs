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
    public class UsuariosController : ControllerBase
    {

        private readonly AplicationDbContext _context;

        public UsuariosController(AplicationDbContext context)
        {

            _context = context;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try { 
           
                var listarUsuarios = await _context.Usuarios.ToListAsync(); // Todos los Usuarios

                



                return Ok(listarUsuarios);

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }



        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {

            try
            {

                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
        {

            try
            {

                if(id != usuario.idUsuario)
                {
                    return NotFound();

                }

                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario Actualizado"});

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                if(usuario == null)
                {

                    return NotFound();

                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario Eliminado" });


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
