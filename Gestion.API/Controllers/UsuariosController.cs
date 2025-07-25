using Dapper;
using Gestion.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gestion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private DbConnection conection;
        public UsuariosController(IConfiguration config)
        {
            var conectionString = config.GetConnectionString("DefaultConnection");
            conection = new Microsoft.Data.SqlClient.SqlConnection(conectionString);
            conection.Open();
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<Modelos.Usuario> Get()
        {
            var usuario = conection.Query<Modelos.Usuario>("SELECT * FROM Usuarios").ToList();
            return usuario;
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            var usuario = conection.QuerySingle<Modelos.Usuario>
                ("SELECT * FROM Usuarios WHERE Id = @Id", new { Id = id });
            return usuario;
        }




        // POST api/<UsuariosController>
        [HttpPost]
        public Usuario Post([FromBody] Usuario usuario)
        {
            conection.Execute
                ("INSERT INTO Usuarios (Nombre, Email, Password) VALUES (@Nombre, @Email, @Password)", usuario);
            return usuario;
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usuario usuario)
        {
            conection.Execute
                ("UPDATE Usuarios SET Nombre = @Nombre, Email = @Email, Password = @Password WHERE Id = @Id", usuario);

        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            conection.Execute
                ("DELETE FROM Usuarios WHERE Id = @Id", new { Id = id });
        }
    }
}
