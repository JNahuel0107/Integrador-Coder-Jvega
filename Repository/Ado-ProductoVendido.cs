using System.Data.SqlClient;
using WebApiCoder.Modelos;

namespace WebApiCoder.Repository
{
    public class ADO_ProductoVendido
    {
        public static List<ProductoVendido> DevolverProductosVendidos2()
        {
            var listaProductos = new List<ProductoVendido>();
            string connectionString = Connection.traerConnection();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT Id,Stock,IdProducto,IdVenta FROM dbo.ProductoVendido";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var producto = new ProductoVendido();
                    producto.Id = Convert.ToInt64(reader2.GetValue(0));
                    producto.Stock = Convert.ToInt32(reader2.GetValue(1).ToString());
                    producto.IdProducto = Convert.ToInt64(reader2.GetValue(2));
                    producto.IdVenta = Convert.ToInt64(reader2.GetValue(3));

                    listaProductos.Add(producto);

                }
                reader2.Close();
                connection.Close();

            }
            return listaProductos;
        }

        public static List<ProductoVendido> DevolverProductosVendidos()
        {
            var listaProductos = new List<ProductoVendido>();
            string connectionString = Connection.traerConnection();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM ProductoVendido";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var producto = new ProductoVendido();

                    producto.Id = Convert.ToInt64(reader2.GetValue(0));
                    producto.Stock = Convert.ToInt32(reader2.GetValue(1));
                    producto.IdProducto = Convert.ToInt32(reader2.GetValue(2));
                    producto.IdVenta = Convert.ToInt32(reader2.GetValue(3));


                    listaProductos.Add(producto);

                }
                reader2.Close();
                connection.Close();

            }
            return listaProductos;
        }
        public static List<Producto> DevolverProductosVendidosxUsuario(int usu)
        {
            var listaProductos = new List<Producto>();
            string connectionString = Connection.traerConnection();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "select Producto.id,Producto.Descripciones,ProductoVendido.Stock,Producto.Costo,Producto.PrecioVenta,Venta.IdUsuario from ProductoVendido inner join Producto on ProductoVendido.IdProducto = Producto.Id inner join venta on ProductoVendido.IdVenta = venta.Id where Venta.IdUsuario = " + usu.ToString();
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {

                    var productos = new Producto();
                    productos.Id = Convert.ToInt64(reader2.GetValue(0));
                    productos.Descripciones = reader2.GetValue(1).ToString();
                    productos.Stock = Convert.ToInt32(reader2.GetValue(2));
                    productos.Costo = Convert.ToInt32(reader2.GetValue(3));
                    productos.PrecioVenta = Convert.ToInt32(reader2.GetValue(4));
                    productos.IdUsuario = Convert.ToInt32(reader2.GetValue(5));


                    listaProductos.Add(productos);

                }
                reader2.Close();
                connection.Close();

            }
            return listaProductos;
        }
    }
}
