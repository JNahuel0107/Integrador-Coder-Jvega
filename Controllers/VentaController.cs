using Microsoft.AspNetCore.Mvc;
using System;
using WebApiCoder.Modelos;
using WebApiCoder.Repository;

namespace WebApiCoder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public void PostVenta(List<Producto> productos, int idUsuario)
        {
            ADO_Venta.InsertVenta(productos, idUsuario);
        }
    
    [HttpGet("GetVentas")]
        public List<Venta> Get()
        {
            return ADO_Venta.DevolverVenta();
        }

    [HttpGet("GetVentasxUsuario")]

        public List<Venta> ventasxusu(int idusu)
        {
            return ADO_Venta.DevolverVentaxUsuario(idusu);
        }

    }
}
