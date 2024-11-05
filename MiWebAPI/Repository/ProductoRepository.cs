using System.Security.Authentication.ExtendedProtection;
using Microsoft.Data.Sqlite;

public class ProductoRepository : IProductoRepository
{
    public void CrearProducto(Producto p)
    {
        string connectionString = "Data Source=bd/Tienda.db;";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string querystring = "INSERT INTO Productos (Descripcion, Precio) VALUES (@nombre, @precio);" ; 
            var command = new SqliteCommand(querystring , connection);
            command.Parameters.AddWithValue("@nombre" , p.Descripcion);
            command.Parameters.AddWithValue("@precio" , p.Precio);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void EliminarProducto(int id)
    {
        string connectionString = "Data Source=bd/Tienda.db;" ;
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string querystring = "DELETE FROM PresupuestosDetalle WHERE idProducto = @id" ; 
            var command = new SqliteCommand(querystring , connection);
            command.Parameters.AddWithValue("@id" , id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public List<Producto> ListarProductos()
    {
        string connectionString = "Data Source=bd/Tienda.db;";
        List<Producto> productos = new List<Producto>() ; 
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string queryString = "Select * from productos; " ;
            var command = new SqliteCommand(queryString , connection);
            using (var reader = command.ExecuteReader())
            {
                while(reader.Read()){

                    var producto = new Producto();
                    producto.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                    producto.Descripcion = reader["Descripcion"].ToString();
                    producto.Precio = Convert.ToInt32(reader["Precio"]);
                    productos.Add(producto);
                }
            }
            connection.Close();
        } 
        return productos;
    }

    public Producto ModificarProducto(Producto p, int id)
    {
        string connectionString = "Data Source=bd/Tienda.db;" ;
        List<Producto> productos = new List<Producto>();
        Producto productoBuscado = null ;
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string querystring = "UPDATE Productos SET Descripcion = @Descripcion, Precio = @Precio WHERE idProducto = @idProducto;" ; 
            var command = new SqliteCommand(querystring , connection);
             using (var reader = command.ExecuteReader())
            {
                while(reader.Read()){

                    var producto = new Producto();
                    producto.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                    producto.Descripcion = reader["Descripcion"].ToString();
                    producto.Precio = Convert.ToInt32(reader["Precio"]);
                    productos.Add(producto);
                }
            }

            productoBuscado = productos.Find(p => p.IdProducto == id);
            command.Parameters.AddWithValue("@Precio" , p.Precio);
            command.Parameters.AddWithValue("@Descripcion" , p.Descripcion);
            command.Parameters.AddWithValue("@idProducto" , p.IdProducto);
            command.ExecuteNonQuery();
            connection.Close();
        }
        return productoBuscado ;
    }
}