using Gestion.API.Consummer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gestion.MVC.Models;

namespace Gestion.MVC.Controllers
{
    public class ReportesController : Controller
    {
        // GET: ReportesController
        public ActionResult Index(string? estadoFiltro = null, string? ordenarPor = null, int? proyectoId = null, int? usuarioId = null)
        {
            var tareas = Crud<Modelos.Tarea>.GetAll();

            
            if (!string.IsNullOrEmpty(estadoFiltro)) // Verifica si el filtro no esta vacio
            {
                tareas = tareas.Where(t => t.Estado.ToLower() == estadoFiltro.ToLower()).ToList();
            }


            if (proyectoId.HasValue) // verifica si tiene un valor el ProyectoId
            {
                tareas = tareas.Where(t => t.ProyectoId == proyectoId.Value).ToList();
            }

            
            if (usuarioId.HasValue) // verifica si tiene un valor el UsuarioId
            {
                tareas = tareas.Where(t => t.UsuarioId == usuarioId.Value).ToList();
            }



            // Ordenar
            tareas = ordenarPor?.ToLower() switch
            {
                "fecha" => tareas.OrderBy(t => t.FechaVencimiento).ToList(), 
                "proyecto" => tareas.OrderBy(t => t.ProyectoId).ToList(),
                "usuario" => tareas.OrderBy(t => t.UsuarioId).ToList(),
                "estado" => tareas.OrderBy(t => t.Estado).ToList(),
                _ => tareas
            };

            // Agrupar
            var tareasProyecto = tareas.GroupBy(t => t.ProyectoId).ToDictionary(g => g.Key, g => g.ToList());
            var tareasUsuario = tareas.GroupBy(t => t.UsuarioId).ToDictionary(g => g.Key, g => g.ToList());

            var viewModel = new ReportesViewModel
            {
                Tareas = tareas,
                TareasPorProyecto = tareasProyecto,
                TareasPorUsuario = tareasUsuario,
                EstadoFiltro = estadoFiltro,
                OrdenarPor = ordenarPor,
                ProyectoId = proyectoId,
                UsuarioId = usuarioId
            };

            return View(viewModel);
        }

        

        
    }
}
