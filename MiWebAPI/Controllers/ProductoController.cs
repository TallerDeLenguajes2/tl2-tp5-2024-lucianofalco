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
    private ProductoRepository  repo = new ProductoRepository();

    [HttpGet("GetProductos")]
    public ActionResult<List<Producto>> GetProductos(){
        return Ok(repo.ListarProductos());
    }

    [HttpPut("ModificarProducto/{id}")]
    public ActionResult<Producto> PutProducto(int id , string nombre){ //consultar por que manda nombre por parametro si en el repositorio recibe un producto
        var p = repo.ModificarProducto(id , nombre);
        if (p is null) return BadRequest();
        return Ok(p);
    }

    [HttpPost("AgregarProducto")]
    public ActionResult<Producto> AddProducto(Producto p){
        repo.CrearProducto(p);
        return Ok();
    } 

    [HttpDelete("EliminarProducto/{id}")]
    public ActionResult<Producto> DeleteProducto(int id){
        Producto eliminado = repo.EliminarProducto(id);
        if (eliminado is null) return BadRequest();
        return Ok(eliminado);
    }

}