

// string CadenaDeConexion = "Data Source=InstitutoDb.db;Cache=Shared“ ; Cadena de conexión para sqlite
//string connectionString = "Data Source=(local);Initial Catalog=Northwind;" + "IntegratedSecurity=true"; //que es ? 
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
        //throw new NotImplementedException();
        string connectionString = "Data Source=(local);Initial Catalog=Northwind;" + "IntegratedSecurity=true";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string queryString = $"select * from presupuestos where idPresupuesto = {id} ;";
            var command = new SqlCommand(queryString, connection);
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {} // Resultados obtenidos (1 fila por vez)
            }

            connection.Close();
        }
        // string queryString = $"select * from presupuestos where idPresupuesto = {id} ;" ; 
    }

    public List<Presupuesto> ListarPresupuesto()
    {
        throw new NotImplementedException();
    }
}