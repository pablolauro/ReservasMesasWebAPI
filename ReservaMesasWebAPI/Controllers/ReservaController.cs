using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaMesasWebAPI.Data;
using ReservaMesasWebAPI.Models;

namespace ReservaMesasWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ReservaController : Controller
    {
        [HttpGet]
        [Route("reservas")]
        public async Task<IActionResult> getAllAsync([FromServices] Contexto contexto)
        {
            var reservas = await contexto
                .Reservas
                .Include(x => x.mesa)
                .Include(x => x.cliente)
                .AsNoTracking()
                .ToListAsync();

            return reservas == null ? NotFound() : Ok(reservas);
        }

        [HttpGet]
        [Route("reservas/{id}")]

        public async Task<IActionResult> getByIdAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {

            var reservas = await contexto
                .Reservas
                .Include(x => x.mesa)
                .Include(x => x.cliente)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.id == id);




            return reservas == null ? NotFound() : Ok(reservas);
        }

        [HttpGet]
        [Route("reservas/data/{data}")]

        public async Task<IActionResult> getByDataAsync([FromServices] Contexto contexto, [FromRoute] DateTime data)
        {

            var reservas = await contexto
                .Reservas
                .Include(x => x.mesa)
                .Include(x => x.cliente)
                .Where(x => x.data == data)
                .AsNoTracking()
                .ToListAsync();

            return reservas == null ? NotFound() : Ok(reservas);
        }

        [HttpGet]
        [Route("reservas/cliente/{id:int}")]

        public async Task<IActionResult> getByClienteAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {

            var reservas = await contexto
                .Reservas
                .Include(x => x.mesa)
                .Include(x => x.cliente)
                .Where(x => x.clienteId == id)
                .AsNoTracking()
                .ToListAsync();

            return reservas == null ? NotFound() : Ok(reservas);
        }

        [HttpGet]
        [Route("reservas/mesa/{id:int}")]

        public async Task<IActionResult> getByMesaAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {

            var reservas = await contexto
                .Reservas
                .Include(x => x.mesa)
                .Include(x => x.cliente)
                .Where(x => x.mesaId == id)
                .AsNoTracking()
                .ToListAsync();

            return reservas == null ? NotFound() : Ok(reservas);
        }

        [HttpPost]
        [Route("reservas")]

        public async Task<IActionResult> postAsync(
           [FromServices] Contexto contexto,
           [FromBody] Reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await contexto.Reservas.AddAsync(reserva);
                await contexto.SaveChangesAsync();
                return Created($"api/reservas/{reserva.id}", reserva);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir a reserva " + ex.Message);
            }
        }

        [HttpPut]
        [Route("reservas/{id}")]

        public async Task<IActionResult> PutAsync(
            [FromServices] Contexto contexto,
            [FromBody] Reserva reserva,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model inválido" + ModelState);
            }

            var r = await contexto.Reservas
                .FirstOrDefaultAsync(x => x.id == id);

            if (r == null)
                return NotFound();

            try
            {
                r.data = reserva.data;
                r.horainicio = reserva.horainicio;
                r.horaFim = reserva.horaFim;
                r.clienteId = reserva.clienteId;
                r.mesaId = reserva.mesaId;


                contexto.Reservas.Update(r);
                await contexto.SaveChangesAsync();
                return Ok(r);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("reservas/{id}")]

        public async Task<IActionResult> DeleteAsync(
            [FromServices] Contexto contexto,
            [FromRoute] int id
            )
        {
            var r = await contexto.Reservas
                .FirstOrDefaultAsync(x => x.id == id);

            if (r == null) { return BadRequest(); }

            try
            {
                contexto.Reservas.Remove(r);
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
