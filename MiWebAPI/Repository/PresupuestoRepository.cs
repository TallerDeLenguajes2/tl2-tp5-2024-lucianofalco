
using Microsoft.Data.Sqlite;

public class PresupuestosRepository : IPresupuestoRepositoy
{
    public void agregarProducto(int id)
    {
        throw new NotImplementedException();
    }

    public void CrearPresupuesto(Presupuesto p)
    {
        throw new NotImplementedException();
    }

    public void EliminarPresupuesto(int id)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}