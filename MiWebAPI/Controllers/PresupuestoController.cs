namespace MiWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

/*
● POST /api/Presupuesto: Permite crear un Presupuesto.
● POST /api/Presupuesto/{id}/ProductoDetalle: Permite agregar un Producto existente
y una cantidad al presupuesto.
● GET /api/presupuesto: Permite listar los presupuestos existentes.
● GET /api/Presupuesto/{id}: Permite agregar un Producto existente y una cantidad al
presupuesto.
*/

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{

    [HttpPost("CrearPresupuesto")]
    public ActionResult<Presupuesto> CrearPresupuesto([FromBody] Presupuesto nuevoP){ // Permite crear un Presupuesto.
        PresupuestosRepository repository = new PresupuestosRepository();
        repository.CrearPresupuesto(nuevoP);
        return Ok();
    }

    [HttpPost("{id}/ProductoDetalle")]
    public ActionResult<Presupuesto> AgregarProductoAlPresupuesto(int id ,int cantidad){ //Permite agregar un Producto existente y una cantidad al presupuesto.
        PresupuestosRepository repository = new PresupuestosRepository();
        repository.agregarProducto(id);
        return Ok();
    }

    [HttpGet("ListarPresupuesto")]
    public ActionResult<List<Presupuesto>> GetPresupuestos(){ //Permite listar los presupuestos existentes.
        PresupuestosRepository repository = new PresupuestosRepository();
        var presupuesto = repository.ListarPresupuesto();
        if(presupuesto is null) return BadRequest();
        return Ok(presupuesto);
    }

    ///
    /// <summary>
    /// Permite visualisar un Presupuesto por id
    /// </summary>
    /// <param name="id"> id del presupuesto </param>
    /// <returns> retorna el presupuesto seleccionado, caso contrario hace un badrequest</returns>
    [HttpGet("{id}")]
    public ActionResult<Presupuesto> GetPresupuesto(int id){ 
        PresupuestosRepository repository = new PresupuestosRepository();
        var presupuesto = repository.GetPresupuesto(id);
        if (presupuesto is null) return BadRequest();
        return Ok(presupuesto);
    }
}

