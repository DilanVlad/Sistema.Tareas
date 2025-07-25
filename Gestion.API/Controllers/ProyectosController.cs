using Dapper;
using Gestion.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gestion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private DbConnection conection;
        public ProyectosController(IConfiguration config)
        {
            var conectionString = config.GetConnectionString("DefaultConnection");
            conection = new Microsoft.Data.SqlClient.SqlConnection(conectionString);
            conection.Open();
        }
        
        // GET: api/<ProyectosController>
        [HttpGet]
        public IEnumerable<Modelos.Proyecto> Get()
        {
            // obtener todo
            var proyectos = conection.Query<Modelos.Proyecto>("SELECT * FROM Proyectos").ToList();
            return proyectos;
        }
        
        // GET api/<ProyectosController>/5
        [HttpGet("{id}")]
        public Proyecto Get(int id)
        {
            // obtener por id
            var proyecto = conection.QuerySingle<Modelos.Proyecto>
                ("SELECT * FROM Proyectos WHERE Id = @Id", new { Id = id });
            return proyecto;
        }

        // POST api/<ProyectosController>
        [HttpPost]
        public Proyecto Post([FromBody] Proyecto proyecto)
        {
            // Insertar un proyecto 
            conection.Execute
                ("INSERT INTO Proyectos (Nombre, Descripcion, FechaInicio, FechaFin) VALUES (@Nombre, @Descripcion, @FechaInicio, @FechaFin)", proyecto);
            

            return proyecto;
        }

        // PUT api/<ProyectosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Proyecto proyecto)
        {
            conection.Execute
                ("UPDATE Proyectos SET Nombre = @Nombre, Descripcion = @Descripcion, FechaInicio = @FechaInicio, FechaFin = @FechaFin WHERE Id = @Id", proyecto);

        }

        // DELETE api/<ProyectosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            conection.Execute("DELETE FROM Proyectos WHERE Id = @Id", new { Id = id });

        }
    }
}



