using BackEndTarjetaCredito.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndTarjetaCredito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        //variable para manerjar en el contructor y cada una de las peticiones 
        public readonly ApplicationDbContext _Context;


        //creacion del constructor
        public CardController(ApplicationDbContext context)
        {
            _Context = context;
        }



        // GET: para agregar los registros
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listCard = await _Context.TarjetaCreditoDB.ToListAsync();
                return Ok(listCard);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }


        // POST para consultar los registros
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreditCard Card)
        {
            try
            {
                _Context.Add(Card);
                await _Context.SaveChangesAsync();
                return Ok(Card);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT para actualizar los registros
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreditCard Card)
        {
            try
            {
                if(id != Card.Id)
                {
                    return NotFound();
                }
                
                //Guardar los cambios y mandar mensaje de que fue hecho con exito
                _Context.Update(Card);
                await _Context.SaveChangesAsync();
                return Ok(new { message = "Tarjeta Actualizada Con Exito"});
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE para eliminar los registros
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Card = await _Context.TarjetaCreditoDB.FindAsync(id);

                if(Card == null)
                {
                    return NotFound();
                }

                _Context.TarjetaCreditoDB.Remove(Card);
                await _Context.SaveChangesAsync();
                return Ok(new {message =  "Tarjeta Eliminada Con Exito" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
