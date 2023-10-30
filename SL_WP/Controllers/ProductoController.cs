using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WP.Controllers
{
    public class ProductoController : ApiController
    {
        // GET api/<controller>/5
        [HttpGet]
        [Route("api/producto/getAll")]
        public IHttpActionResult GetAll([FromBody] ML.Producto productoBusqueda)
        {
            productoBusqueda.Departamento = new ML.Departamento();

            ML.Result result = BL.Producto.GetAll(productoBusqueda);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/producto/getById/{idProducto}")]
        public IHttpActionResult GetById(int IdProducto)
        {
            ML.Result result = BL.Producto.GetById(IdProducto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/producto/add")]
        public IHttpActionResult Post([FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/producto/Update/{IdProducto}")]
        public IHttpActionResult Put(int IdProducto, [FromBody] ML.Producto producto)
        {

            producto.IdProducto = IdProducto;

            ML.Result result = BL.Producto.Update(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/producto/delete/{IdProducto}")]
        public IHttpActionResult Delete(int IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            producto.IdProducto = IdProducto;

            ML.Result result = BL.Producto.Delete(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}