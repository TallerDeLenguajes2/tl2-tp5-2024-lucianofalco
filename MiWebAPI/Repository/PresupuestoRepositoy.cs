/*
    Crear un repositorio llamado PresupuestosRepository para gestionar todas las
operaciones relacionadas con Presupuestos. Este repositorio debe incluir métodos para:

● Crear un nuevo Presupuesto. (recibe un objeto Presupuesto)
● Listar todos los Presupuestos registrados. (devuelve un List de Presupuestos)
● Obtener detalles de un Presupuesto por su ID. (recibe un Id y devuelve un
Presupuesto con sus productos y cantidades)
● Agregar un producto y una cantidad a un presupuesto (recibe un Id)
● Eliminar un Presupuesto por ID
*/

public interface IPresupuestoRepositoy
{
    void CrearPresupuesto(Presupuesto p);
    List<Presupuesto> ListarPresupuesto();

    Presupuesto getPresupuesto(int id);

    void agregarProducto(int id);// ,  Producto producto , int cantidad);

    void EliminarPresupuesto(int id) ;
}