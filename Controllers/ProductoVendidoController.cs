using Microsoft.AspNetCore.Mvc;
using WebApiCoder.Modelos;
using WebApiCoder.Repository;

namespace WebApiCoder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("GetProductosVendidos")]
        public List<ProductoVendido> Get()
        {
            return ADO_ProductoVendido.DevolverProductosVendidos();
        }

        [HttpGet("GetProductoVendidoxUsuario")]


        public List<Producto> get(int usuario)
        {
            return ADO_ProductoVendido.DevolverProductosVendidosxUsuario(usuario);
        }


    }
}
