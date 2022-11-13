using System.Data;
using System.Data.SqlClient;
using WebApiCoder.Modelos;

namespace WebApiCoder.Repository
{
    public class ADO_Venta
    {
      
        public static List<Venta> DevolverVenta()
        {
            var ventas = new List<Venta>();
            string connectionString = Connection.traerConnection();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM Venta";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var venta = new Venta();

                    venta.id = Convert.ToInt32(reader2.GetValue(0).ToString());
                    venta.Comentarios = reader2.GetValue(1).ToString();
                    venta.idUsuario = Convert.ToInt32(reader2.GetValue(2).ToString());

                    ventas.Add(venta);

                }
                reader2.Close();
                connection.Close();

            }
            return ventas;
        }

        public static List<Venta> DevolverVentaxUsuario(int idusuario)
        {
            var ventas = new List<Venta>();
            string connectionString = Connection.traerConnection();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "select * from venta where IdUsuario = @idusuario";
                cmd2.Parameters.AddWithValue("@idusuario", idusuario);
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var venta = new Venta();

                    venta.id = Convert.ToInt64(reader2.GetValue(0).ToString());
                    venta.Comentarios = reader2.GetValue(1).ToString();
                    venta.idUsuario = Convert.ToInt64(reader2.GetValue(2).ToString());


                    ventas.Add(venta);

                }
                reader2.Close();
                connection.Close();

            }
            return ventas;
        }
        public static class GetId
        {
            public static int Get(SqlCommand sqlCommand)
            {
                sqlCommand.CommandText = "Select @@IDENTITY";
                sqlCommand.Parameters.Clear();

                object objID = sqlCommand.ExecuteScalar();

                int id = Convert.ToInt32(objID);

                return id;
            }
        }

        public static void InsertVenta(List<Producto> productos, int IdUsuario)
        {
            Venta venta = new Venta();
            string connectionString = Connection.traerConnection();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Connection.Open();
            sqlCommand.CommandText = @"INSERT INTO Venta
                                ([Comentarios]
                                ,[IdUsuario])
                                VALUES
                                (@Comentarios,
                                    @IdUsuario)";

            sqlCommand.Parameters.AddWithValue("@Comentarios", "");
            sqlCommand.Parameters.AddWithValue("@IdUsuario", IdUsuario);

            sqlCommand.ExecuteNonQuery(); //Se ejecuta realmente el INSERT INTO
            venta.id = GetId.Get(sqlCommand);
            venta.idUsuario = IdUsuario;

            foreach (Producto producto in productos)
            {
                sqlCommand.CommandText = @"INSERT INTO ProductoVendido
                                ([Stock]
                                ,[IdProducto]
                                ,[IdVenta])
                                VALUES
                                (@Stock,
                                @IdProducto,
                                @IdVenta)";

                sqlCommand.Parameters.AddWithValue("@Stock", producto.Stock);
                sqlCommand.Parameters.AddWithValue("@IdProducto", producto.Id);
                sqlCommand.Parameters.AddWithValue("@IdVenta", venta.id);

                sqlCommand.ExecuteNonQuery(); //Se ejecuta realmente el INSERT INTO
                sqlCommand.Parameters.Clear();

                sqlCommand.CommandText = @" UPDATE Producto
                                                SET 
                                                Stock = Stock - @Stock
                                                WHERE id = @IdProducto";

                sqlCommand.Parameters.AddWithValue("@Stock", producto.Stock);
                sqlCommand.Parameters.AddWithValue("@IdProducto", producto.Id);

                sqlCommand.ExecuteNonQuery(); //Se ejecuta realmente el INSERT INTO
                sqlCommand.Parameters.Clear();
            }
            sqlCommand.Connection.Close();
        }
    }
}
