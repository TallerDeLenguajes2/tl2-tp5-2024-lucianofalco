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
    ActionResult<Presupuesto> CrearPresupuesto(){ // Permite crear un Presupuesto.
        return Ok();
    }

    [HttpPost("{id}/ProductoDetalle")]
    ActionResult<Presupuesto> AgregarProductoAlPresupuesto(int id , PresupuestoDetalle pd){ //Permite agregar un Producto existente y una cantidad al presupuesto.
        return Ok();
    }

    [HttpGet]
    ActionResult<List<Presupuesto>> GetPresupuestos(){ //Permite listar los presupuestos existentes.
        return Ok();
    }


    [HttpPut("{id}")] //PUT /api/Presupuesto/{id}/ProductoDetalle
    ActionResult<Presupuesto> ModificarPresupuesto(int id , int cantidad , Producto p){ //Permite agregar un Producto existente y una cantidad al presupuesto.
        return Ok();
    }
}

