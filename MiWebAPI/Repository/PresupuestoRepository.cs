
using Microsoft.Data.Sqlite;

public class PresupuestosRepository : IPresupuestoRepositoy
{
    public void agregarProducto(int idPro)  //} , int idPre , int cant) // consultar si no es mejor hacer que re
    {
        string connectionString = "Data Source=bd/Tienda.db;";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open() ;
            string stringQuery = "Select * from productos where idProducto = @id" ; 
            var command = new SqliteCommand(stringQuery , connection);
            command.Parameters.AddWithValue("@id",idPro);
            Producto productoBuscado = null ; 
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    productoBuscado = new Producto();
                    productoBuscado.IdProducto = Convert.ToInt32(reader["idProducto"]);
                    productoBuscado.Precio = Convert.ToDouble(reader["Precio"]);
                    productoBuscado.Descripcion = reader["Descripcion"].ToString();
                }
            }
            if (productoBuscado is not null)
            {
                string newquery = "INSERT INTO PresupuestosDetalle (idPresupuesto, idProducto, Cantidad) VALUES (@idpre, @idpro, @cant); " ; 
                var presupuestoDetalle = new PresupuestoDetalle();
                var newcommand = new SqliteCommand(newquery , connection);
                //newcommand.Parameters.AddWithValue("@idpre" , presupuestoDetalle. );
                newcommand.Parameters.AddWithValue("@idpro" , productoBuscado.Precio);
                newcommand.ExecuteNonQuery();
            }
        }
    }

    public void CrearPresupuesto(Presupuesto p)
    { 
         string connectionString = "Data Source=bd/Tienda.db;";
         using (SqliteConnection connection = new SqliteConnection(connectionString))
         {
             connection.Open();
             string queryString = $"INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES (@Nombre, @Fecha);";
             var command = new SqliteCommand(queryString, connection);
             command.Parameters.AddWithValue("@Nombre", p.NombreDestinatario);
             command.Parameters.AddWithValue("@Fecha", p.FechaCreacion.ToString("yyyy-MM-dd"));
             command.ExecuteNonQuery();
            connection.Close();
         } 
    }

    public void EliminarPresupuesto(int id)
    {
        string connectionString = "Data Source=bd/Tienda.db;" ;
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string queryString = $"DELETE FROM Presupuestos WHERE idPresupuesto = @id ;" ; 
            var command = new SqliteCommand(queryString , connection);
            command.Parameters.AddWithValue("@id" , id);
            command.ExecuteNonQuery(); // consultar que pasa si no encuentra el id a borrar
            connection.Close();
        }
    }

    public Presupuesto GetPresupuesto(int id)
    {
        Presupuesto presupuesto = null; 
         string connectionString = "Data Source=bd/Tienda.db;";
         using (SqliteConnection connection = new SqliteConnection(connectionString))
         {
             connection.Open();
             string queryString = $"select * from Presupuestos where idPresupuesto = @id;";
             var command = new SqliteCommand(queryString, connection);
             command.Parameters.AddWithValue("@id", id);
             using (var reader = command.ExecuteReader())
             {
                 while (reader.Read())
                 {
                    presupuesto = new Presupuesto();
                    presupuesto.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                    presupuesto.NombreDestinatario = reader["NombreDestinatario"].ToString();
                    presupuesto.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    
                 } 
             }
            connection.Close();
         }
        return presupuesto;
    }

    public List<Presupuesto> ListarPresupuesto()
    {
        Presupuesto presupuesto = null ; 
        List<Presupuesto> presupuestos = new List<Presupuesto>();
        string connectionString = "Data Source=bd/Tienda.db;";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string queryString = "select * from presupuestos" ; 
            var command = new SqliteCommand(queryString , connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    presupuesto = new Presupuesto();
                    presupuesto.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                    presupuesto.NombreDestinatario = reader["NombreDestinatario"].ToString();
                    presupuesto.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    presupuestos.Add(presupuesto);
                }
            }
            connection.Close();
        }
            return presupuestos ; 
    }
}