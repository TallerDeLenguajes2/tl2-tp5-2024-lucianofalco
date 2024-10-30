namespace MiWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

/*
  POST /api/Producto: Permite crear un nuevo Producto.
● GET /api/Producto: Permite listar los Productos existentes.
● PUT /api/Producto/{Id}: Permite modificar un nombre de un Producto.

*/
[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    [HttpGet("GetProductos")]
    ActionResult<List<Producto>> GetProductos(){
        return Ok();
    }

    [HttpPut("ModificarProducto/{id}")]
    ActionResult<Producto> PutProducto(int id , string nombre){
        return Ok();
    }

    [HttpPost("AgregarProducto")]
    ActionResult<Producto> AddProducto(Producto p){
        return Ok();
    } 

}