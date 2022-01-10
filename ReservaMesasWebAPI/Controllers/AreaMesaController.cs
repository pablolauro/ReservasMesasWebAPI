using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaMesasWebAPI.Data;
using ReservaMesasWebAPI.Models;

namespace ReservaMesasWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AreaMesaController : Controller
    {
        [HttpGet]
        [Route("areamesas")]
        public async Task<IActionResult> getAllAsync([FromServices] Contexto contexto)
        {
            var areamesas = await contexto
                .AreaMesas
                .AsNoTracking()
                .ToListAsync();

            return areamesas == null ? NotFound() : Ok(areamesas);
        }

        [HttpGet]
        [Route("areamesas/{id}")]

        public async Task<IActionResult> getByIdAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {
            var areamesas = await contexto
                .AreaMesas
                .Include(x => x.mesas)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.id == id);
            return areamesas == null ? NotFound() : Ok(areamesas);
        }

        [HttpPost]
        [Route("areamesas")]

        public async Task<IActionResult> postAsync(
            [FromServices] Contexto contexto,
            [FromBody] AreaMesa areamesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await contexto.AreaMesas.AddAsync(areamesa);
                await contexto.SaveChangesAsync();
                return Created($"api/areamesas/{areamesa.id}", areamesa);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir a Area Mesa" + ex.Message);
            }
        }


        [HttpPut]
        [Route("areamesas/{id}")]

        public async Task<IActionResult> PutAsync(
            [FromServices] Contexto contexto,
            [FromBody] AreaMesa areamesa,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model inválido");
            }

            var a = await contexto.AreaMesas
                .FirstOrDefaultAsync(x => x.id == id);

            if (a == null)
                return NotFound();

            try
            {
                a.nome = areamesa.nome;
                
                contexto.AreaMesas.Update(a);
                await contexto.SaveChangesAsync();
                return Ok(a);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("areamesas/{id}")]

        public async Task<IActionResult> DeleteAsync(
            [FromServices] Contexto contexto,
            [FromRoute] int id
            )
        {
            var a = await contexto.AreaMesas
                .FirstOrDefaultAsync(x => x.id == id);

            if (a == null) { return BadRequest(); }

            try
            {
                contexto.AreaMesas.Remove(a);
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
