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
    public ActionResult<Presupuesto> CrearPresupuesto(){ // Permite crear un Presupuesto.
        return Ok();
    }

    [HttpPost("{id}/ProductoDetalle")]
    public ActionResult<Presupuesto> AgregarProductoAlPresupuesto(int id , PresupuestoDetalle pd){ //Permite agregar un Producto existente y una cantidad al presupuesto.
        return Ok();
    }

    [HttpGet]
    public ActionResult<List<Presupuesto>> GetPresupuestos(){ //Permite listar los presupuestos existentes.
        return Ok();
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

