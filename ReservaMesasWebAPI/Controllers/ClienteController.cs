using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaMesasWebAPI.Data;
using ReservaMesasWebAPI.Models;

namespace ReservaMesasWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClienteController : Controller
    {
        [HttpGet]
        [Route("clientes")]
        public async Task<IActionResult> getAllAsync([FromServices] Contexto contexto)
        {
            var clientes = await contexto
                .Clientes
                .AsNoTracking()
                .ToListAsync();
            
            return clientes == null ? NotFound() : Ok(clientes);
        }

        [HttpGet]
        [Route("clientes/{id}")]

        public async Task<IActionResult> getByIdAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {
            var clientes = await contexto
                .Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.id == id);
            return clientes == null ? NotFound() : Ok(clientes);
        }

        [HttpPost]
        [Route("clientes")]

        public async Task<IActionResult> postAsync(
            [FromServices] Contexto contexto,
            [FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await contexto.Clientes.AddAsync(cliente);
                await contexto.SaveChangesAsync();
                return Created($"api/clientes/{cliente.id}", cliente);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir o cliente "+ex.Message);
            }
        }


        [HttpPut]
        [Route("clientes/{id}")]

        public async Task<IActionResult> PutAsync(
            [FromServices] Contexto contexto,
            [FromBody] Cliente cliente,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model inválido");
            }

            var c = await contexto.Clientes
                .FirstOrDefaultAsync(x => x.id == id);

            if (c == null)
                return NotFound();

            try
            {
                c.nome = cliente.nome;
                c.email = cliente.email;
                c.telefone = cliente.telefone;

                contexto.Clientes.Update(c);
                await contexto.SaveChangesAsync();
                return Ok(c);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("clientes/{id}")]

        public async Task<IActionResult> DeleteAsync(
            [FromServices] Contexto contexto,
            [FromRoute] int id
            )
        {
            var p = await contexto.Clientes
                .FirstOrDefaultAsync(x => x.id == id);

            if (p == null) { return BadRequest(); }

            try
            {
                contexto.Clientes.Remove(p);
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
