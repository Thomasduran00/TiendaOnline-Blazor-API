using Microsoft.AspNetCore.Mvc;
using TiendaOnline.API.Models;

namespace TiendaOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private static List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { IdCliente = 1, Nombre = "Johan", Email = "johan@test.com", Telefono = "123456" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get() => Ok(clientes);

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.IdCliente == id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            cliente.IdCliente = clientes.Count > 0 ? clientes.Max(c => c.IdCliente) + 1 : 1;
            clientes.Add(cliente);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente cliente)
        {
            var existente = clientes.FirstOrDefault(c => c.IdCliente == id);
            if (existente == null) return NotFound();

            existente.Nombre = cliente.Nombre;
            existente.Email = cliente.Email;
            existente.Telefono = cliente.Telefono;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.IdCliente == id);
            if (cliente == null) return NotFound();

            clientes.Remove(cliente);
            return Ok();
        }
    }
}