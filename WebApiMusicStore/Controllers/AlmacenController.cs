using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMusicStore.Models;

namespace WebApiMusicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        List<Almacen> almacen = new List<Almacen>
        {
            new Almacen{ id=1,Name="Almacen 1",MaxProducts=30},
            new Almacen{ id=2,Name="Almacen 2",MaxProducts=80},
            new Almacen{ id=3,Name="Almacen 3",MaxProducts=100}
        };

        [HttpGet("GetAlmacenes")]
        public ActionResult Get() // me refiero a esto....
        {
            return Ok(almacen);
        }
        [HttpPost("AddAlmacen")]
        public ActionResult Post(Almacen alm)
        {
            if (alm == null)
                return NotFound("Sin Información");
            if (alm.id <= 0)
                return BadRequest("No ha ingresado un id al almacen");
            if (string.IsNullOrEmpty(alm.Name))
                return BadRequest("No ha ingresado un nombre de almacen");
            almacen.Add(alm);
            return Ok(almacen);
        }
        [HttpPut("EditAlmacen")]
        public ActionResult Put(Almacen alm)
        {
            if (alm == null)
                return NotFound("Sin Información");
            if (alm.id <= 0)
                return BadRequest("No ha ingresado un id al almacen");
            if (string.IsNullOrEmpty(alm.Name))
                return BadRequest("No ha ingresado un nombre de almacen");
            foreach (var data in almacen)
            {
                if (data.id == alm.id)
                {
                    data.Name = alm.Name;
                    data.MaxProducts = alm.MaxProducts;
                }
            }

            return Ok(almacen);
        }
        [HttpDelete("DeleteAlmacen")]
        public ActionResult Delete(int id)
        {
            // var = obtiene el tipo de dato dinamicamente, pero tiene que estar instanciado
            IEnumerable<Almacen> Buqueda = almacen.Where(w => w.id == id);
            Almacen valorEliminar = Buqueda.FirstOrDefault();
            if (valorEliminar != null)
                almacen.Remove(valorEliminar);
            else
                return BadRequest("Almacen ya no existe, no es posible eliminar 2 veces");
            return Ok(almacen);
        }
    }
}
