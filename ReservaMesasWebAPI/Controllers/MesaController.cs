using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaMesasWebAPI.Data;
using ReservaMesasWebAPI.Models;

namespace ReservaMesasWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class MesaController : Controller
    {
        [HttpGet]
        [Route("mesas")]
        public async Task<IActionResult> getAllAsync([FromServices] Contexto contexto)
        {
            var mesas = await contexto
                .Mesas
                .Include(x => x.area)
                .AsNoTracking()
                .ToListAsync();

            return mesas == null ? NotFound() : Ok(mesas);
        }
        
        [HttpGet]
        [Route("mesas/{id}")]

        public async Task<IActionResult> getByIdAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {

            var mesas = await contexto
                .Mesas
                .Include(x => x.area)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.id == id);

            return mesas == null ? NotFound() : Ok(mesas);
        }


        [HttpGet]
        [Route("mesas/area/{id:int}")]

        public async Task<IActionResult> getByAreaAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {

            var mesas = await contexto
                .Mesas
                .Include(x => x.area)
                .Where(x => x.idAreaMesa == id)
                .AsNoTracking()
                .ToListAsync();

            return mesas == null ? NotFound() : Ok(mesas);
        }

        [HttpPost]
        [Route("mesas")]

        public async Task<IActionResult> postAsync(
           [FromServices] Contexto contexto,
           [FromBody] Mesa mesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {          
                await contexto.Mesas.AddAsync(mesa);
                await contexto.SaveChangesAsync();
                return Created($"api/mesas/{mesa.id}", mesa);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir a mesa " + ex.Message);
            }
        }

        [HttpPut]
        [Route("mesas/{id}")]

        public async Task<IActionResult> PutAsync(
            [FromServices] Contexto contexto,
            [FromBody] Mesa mesa,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model inválido");
            }

            var m = await contexto.Mesas
                .FirstOrDefaultAsync(x => x.id == id);

            if (m == null)
                return NotFound();

            try
            {
                m.qtdlugares = mesa.qtdlugares;
                m.numMesa = mesa.numMesa;
                m.funcionando = mesa.funcionando;
                m.idAreaMesa = mesa.idAreaMesa;


                contexto.Mesas.Update(m);
                await contexto.SaveChangesAsync();
                return Ok(m);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("mesas/{id}")]

        public async Task<IActionResult> DeleteAsync(
            [FromServices] Contexto contexto,
            [FromRoute] int id
            )
        {
            var m = await contexto.Mesas
                .FirstOrDefaultAsync(x => x.id == id);

            if (m == null) { return BadRequest(); }

            try
            {
                contexto.Mesas.Remove(m);
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
