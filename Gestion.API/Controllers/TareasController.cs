using Dapper;
using Gestion.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gestion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private DbConnection conection;
        public TareasController(IConfiguration config) {

            var conectionString = config.GetConnectionString("DefaultConnection");
            conection = new Microsoft.Data.SqlClient.SqlConnection(conectionString);
            conection.Open();

        }
        // GET: api/<TareasController>
        [HttpGet]
        public IEnumerable<Modelos.Tarea> Get()
        {
            var tareas = conection.Query<Modelos.Tarea>("SELECT * FROM Tareas").ToList();
            return tareas;
        }

        // GET api/<TareasController>/5
        [HttpGet("{id}")]
        public Tarea Get(int id)
        {
            var tarea = conection.QuerySingle<Modelos.Tarea>
                ("SELECT * FROM Tareas WHERE Id = @Id", new { Id = id });
            return tarea;
        }

        // POST api/<TareasController>
        [HttpPost]
        public Tarea Post([FromBody] Tarea tarea)
        {
            conection.Execute
                ("INSERT INTO Tareas (Id, Nombre, Descripcion, Estado, FechaCreacion, FechaVencimiento, ProyectoId, UsuarioId) VALUES (@Id, @Nombre, @Descripcion, @Estado, @FechaCreacion, @FechaVencimiento, @ProyectoId, @UsuarioId)", tarea);
            return tarea;
        }

        // PUT api/<TareasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Tarea tarea)
        {
            conection.Execute
                ("UPDATE Tareas SET Nombre = @Nombre, Descripcion = @Descripcion, Estado = @Estado, FechaCreacion = @FechaCreacion, FechaVencimiento = @FechaVencimiento, ProyectoId = @ProyectoId, UsuarioId = @UsuarioId WHERE Id = @Id", tarea);
        }

        // DELETE api/<TareasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            conection.Execute
                ("DELETE FROM Tareas WHERE Id = @Id", new { Id = id });
        }
    }
}
