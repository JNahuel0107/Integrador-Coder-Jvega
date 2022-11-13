namespace WebApiCoder.Modelos
{
    public class ProductoVendido
    {
        public long Id { get; set; }
        public int Stock { get; set; }
        public long IdProducto { get; set; }
        public long IdVenta { get; set; }

        public string descripcion { get; set; }

        public Producto Producto { get; set; }



    }


}
