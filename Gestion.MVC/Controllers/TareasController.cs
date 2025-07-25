using Gestion.API.Consummer;
using Gestion.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion.MVC.Controllers
{
    public class TareasController : Controller
    {
        // GET: TareasController
        public ActionResult Index()
        {
            var data = Crud<Modelos.Tarea>.GetAll();
            return View(data);
        }

        // GET: TareasController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Modelos.Tarea>.GetById(id);
            return View(data);
        }

        // GET: TareasController/Create
        public ActionResult Create()
        {
            ViewBag.Estados = GetEstado();
            ViewBag.Proyectos = getProyectos();
            ViewBag.Usuarios = getUsuarios();
            
            return View();
        }

        // POST: TareasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tarea data)
        {
            try
            {
                
                Crud<Modelos.Tarea>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
        
        private List<SelectListItem> getProyectos()
        {
            var proyectos = Crud<Modelos.Proyecto>.GetAll();
            return proyectos.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nombre
            }).ToList();
        }
        private List<SelectListItem> getUsuarios()
        {
            var usuarios = Crud<Modelos.Usuario>.GetAll();
            return usuarios.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Nombre
            }).ToList();
        }
        
        private List<SelectListItem> GetEstado()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "En Progreso", Text = "En Progreso" },
                new SelectListItem { Value = "Completada", Text = "Completada" }
            };
        }


        // GET: TareasController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Modelos.Tarea>.GetById(id);
            ViewBag.Estados = GetEstado();
            ViewBag.Proyectos = getProyectos();
            ViewBag.Usuarios = getUsuarios();
            return View(data);
        }

        // POST: TareasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tarea data)
        {
            try
            {
                Crud<Modelos.Tarea>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: TareasController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Modelos.Tarea>.GetById(id);
            return View(data);
        }

        // POST: TareasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Tarea data)
        {
            try
            {
                Crud<Modelos.Tarea>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
