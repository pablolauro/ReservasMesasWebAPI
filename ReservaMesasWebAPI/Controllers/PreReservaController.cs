using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaMesasWebAPI.Data;
using ReservaMesasWebAPI.Models;

namespace ReservaMesasWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class PreReservaController : Controller
    {
        [HttpGet]
        [Route("prereservas")]
        public async Task<IActionResult> getAllAsync([FromServices] Contexto contexto)
        {
            var prereservas = await contexto
                .PreReservas                
                .AsNoTracking()
                .ToListAsync();

            return prereservas == null ? NotFound() : Ok(prereservas);
        }

        [HttpGet]
        [Route("prereservas/{id}")]

        public async Task<IActionResult> getByIdAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {

            var prereservas = await contexto
                .PreReservas
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.id == id);




            return prereservas == null ? NotFound() : Ok(prereservas);
        }

        [HttpGet]
        [Route("prereservas/data")]

        public async Task<IActionResult> getByDataHojeAsync([FromServices] Contexto contexto)
        {

            var prereservas = await contexto
                .PreReservas
                .Where(x => x.data >= DateTime.Now.Date)
                .AsNoTracking()
                .ToListAsync();

            return prereservas == null ? NotFound() : Ok(prereservas);
        }

        [HttpPost]
        [Route("prereservas")]

        public async Task<IActionResult> postAsync(
        [FromServices] Contexto contexto,
        [FromBody] PreReserva prereserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await contexto.PreReservas.AddAsync(prereserva);
                await contexto.SaveChangesAsync();
                return Created($"api/reservas/{prereserva.id}", prereserva);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir a pré reserva " + ex.Message);
            }
        }

        [HttpPut]
        [Route("prereservas/{id}")]

        public async Task<IActionResult> PutAsync(
            [FromServices] Contexto contexto,
            [FromBody] PreReserva prereserva,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model inválido" + ModelState);
            }

            var r = await contexto.PreReservas
                .FirstOrDefaultAsync(x => x.id == id);

            if (r == null)
                return NotFound();

            try
            {
                r.data = prereserva.data;
                r.emailcliente = prereserva.emailcliente;
                r.fonecliente = prereserva.fonecliente;
                r.nomecliente = prereserva.nomecliente;


                contexto.PreReservas.Update(r);
                await contexto.SaveChangesAsync();
                return Ok(r);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("prereservas/{id}")]

        public async Task<IActionResult> DeleteAsync(
            [FromServices] Contexto contexto,
            [FromRoute] int id
            )
        {
            var r = await contexto.PreReservas
                .FirstOrDefaultAsync(x => x.id == id);

            if (r == null) { return BadRequest(); }

            try
            {
                contexto.PreReservas.Remove(r);
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
