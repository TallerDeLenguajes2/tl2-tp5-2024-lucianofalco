/*
● Presupuestos
    ○ int IdPresupuesto
    ○ string nombreDestinatario
    ○ List<PresupuestoDetalle> detalle

*/

public class Presupuesto
{
    int idPresupuesto ; 
    string nombreDestinario ; 
    List<PresupuestoDetalle> detalles ;

    public Presupuesto()
    {
    }

    public Presupuesto(int idPresupuesto, string nombreDestinario, List<PresupuestoDetalle> detalles)
    {
        this.idPresupuesto = idPresupuesto;
        this.nombreDestinario = nombreDestinario;
        this.detalles = detalles;
    }

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinario { get => nombreDestinario; set => nombreDestinario = value; }
    public List<PresupuestoDetalle> Detalles { get => detalles; set => detalles = value; }


    /*
    ○ Metodos
        ■ MontoPresupuesto ()
        ■ MontoPresupuestoConIva()
        ■ CantidadProductos ()
    */

    public double MontoPresupuesto(){
        double total = 0 ;
        foreach (var d in detalles)
        {
            total += d.Producto.Precio ; 
        }
        return total ;
    }

    public double MontoPresupuestoConIva(){
        return MontoPresupuesto() * 1.21 ;
    }

    public int CantidadProductos(){
        int cantidad = 0 ;
        foreach (var d in detalles)
        {
            cantidad += d.Cantidad ; 
        }
        return cantidad ;
    }
}