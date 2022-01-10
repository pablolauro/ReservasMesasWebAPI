using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaMesasWebAPI.Data;
using ReservaMesasWebAPI.Models;

namespace ReservaMesasWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsuarioController : Controller
    {
        [HttpGet]
        [Route("usuarios")]
        public async Task<IActionResult> getAllAsync([FromServices] Contexto contexto)
        {
            var usuarios = await contexto
                .Usuarios
                .AsNoTracking()
                .ToListAsync();

            return usuarios == null ? NotFound() : Ok(usuarios);
        }

        [HttpGet]
        [Route("usuarios/{login}")]

        public async Task<IActionResult> getByIdAsync([FromServices] Contexto contexto, [FromRoute] string login)
        {
            var usuarios = await contexto
                .Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.login == login);
            return usuarios == null ? NotFound() : Ok(usuarios);
        }

        [HttpPost]
        [Route("usuarios")]

        public async Task<IActionResult> postAsync(
            [FromServices] Contexto contexto,
            [FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await contexto.Usuarios.AddAsync(usuario);
                await contexto.SaveChangesAsync();
                return Created($"api/usuarios/{usuario.login}", usuario);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir o usuário " + ex.Message);
            }
        }


        [HttpPut]
        [Route("usuarios/{login}")]

        public async Task<IActionResult> PutAsync(
            [FromServices] Contexto contexto,
            [FromBody] Usuario usuario,
            [FromRoute] string login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model inválido");
            }

            var c = await contexto.Usuarios
                .FirstOrDefaultAsync(x => x.login == login);

            if (c == null)
                return NotFound();

            try
            {
                c.password = usuario.password;

                contexto.Usuarios.Update(c);
                await contexto.SaveChangesAsync();
                return Ok(c);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("usuarios/{login}")]

        public async Task<IActionResult> DeleteAsync(
            [FromServices] Contexto contexto,
            [FromRoute] string login
            )
        {
            var p = await contexto.Usuarios
                .FirstOrDefaultAsync(x => x.login == login);

            if (p == null) { return BadRequest(); }

            try
            {
                contexto.Usuarios.Remove(p);
                await contexto.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
