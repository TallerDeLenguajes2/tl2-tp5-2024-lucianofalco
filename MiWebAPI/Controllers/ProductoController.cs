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
    public ActionResult<List<Producto>> GetProductos(){
        var repositoy = new ProductoRepository();
        return Ok(repositoy.ListarProductos());
    }

    [HttpPut("ModificarProducto/{id}")]
    public ActionResult<Producto> PutProducto(int id , string nombre){ //consultar por que manda nombre por parametro si en el repositorio recibe un producto
        return Ok();
    }

    [HttpPost("AgregarProducto")]
    public ActionResult<Producto> AddProducto(Producto p){
        var repositoy = new ProductoRepository();
        repositoy.CrearProducto(p);
        return Ok();
    } 

}