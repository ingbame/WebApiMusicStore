using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMusicStore.Models;

namespace WebApiMusicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        List<Ventas> ventas = new List<Ventas>
        {
            new Ventas{ id=1, TipoVenta="Instrumentos",Total=5000},
            new Ventas{ id=2, TipoVenta="Refacciones",Total=3000},
            new Ventas{ id=3, TipoVenta="Remplazos",Total=2000}
        };
        [HttpGet("GetVentas")]
        public ActionResult Get()
        {
            return Ok(ventas);
        }

        [HttpPost("AddVentas")]
        public ActionResult Post(Ventas venta)
        {
            if(venta.id <= 0)
                return BadRequest("No ha ingresado un Id a la venta");
            if (string.IsNullOrEmpty(venta.TipoVenta))
                return BadRequest("No ah ingresado el tipo de venta");
            
            ventas.Add(venta);
            return Ok(ventas);
        }
        [HttpPut("EditVentas")]
        public ActionResult Put(Ventas venta)
        {
            if (venta == null)
                return NotFound("Sin informacion");
            if (venta.id <= 0)
                return BadRequest("No ingreso ID de la venta");
            if (string.IsNullOrEmpty(venta.TipoVenta))
                return BadRequest("NO ah Ingresado el nombre del tipo de venta");
            foreach(var data in ventas)
            {
                if (data.id == venta.id)
                {
                    data.TipoVenta = venta.TipoVenta;
                    data.Total = venta.Total;
                }
            }

            return Ok(ventas);

        }
        [HttpDelete("DeleteVentas")]
        public ActionResult Delete(int id)
        {
            IEnumerable<Ventas> Busqueda = ventas.Where(w => w.id == id);
            Ventas valorEliminar = Busqueda.FirstOrDefault();
            if (valorEliminar != null)
                ventas.Remove(valorEliminar);
            else
                return BadRequest("Venta ya no existe, o esta duplicado");
            return Ok(ventas);
        }

    }
}
