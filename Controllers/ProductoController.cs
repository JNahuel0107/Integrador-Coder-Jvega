using Microsoft.AspNetCore.Mvc;
using WebApiCoder.Modelos;
using WebApiCoder.Repository;

namespace WebApiCoder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("GetProductos")]
        public List<Producto> Get()
        {
            return ADO_Producto.DevolverProductos();
        }
        /*
         [HttpGet("GetProductosId")]
         public Producto Get(Int32 id)
         {
             return ADO_Producto.TraerProductoId(id);
         }


         [HttpGet("GetProductoxUsuario")]
         public List<Producto> ProductoUsu(int idusuario)
         {
             return ADO_Producto.DevolverUsuario(idusuario);
         }
        */

        [HttpPost]
        public void Crear([FromBody] Producto prod)
        {
            ADO_Producto.CrearProducto(prod);
        }
        [HttpPut]
        public void Modificar([FromBody] Producto prod)
        {
            ADO_Producto.ModificarProducto(prod);
        }
        [HttpDelete]
        public void Eliminar(long idProducto)
        {
            ADO_Producto.EliminarProducto(idProducto);
        }

        
    }
}
