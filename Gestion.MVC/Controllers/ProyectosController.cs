using Gestion.API.Consummer;
using Gestion.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Gestion.MVC.Controllers
{
    public class ProyectosController : Controller
    {
        // GET: ProyectosController
        public ActionResult Index()
        {
            var data = Crud<Modelos.Proyecto>.GetAll();
            return View(data);
        }

        // GET: ProyectosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Modelos.Proyecto>.GetById(id);
            data.Tareas = Crud<Modelos.Tarea>.GetBy("proyecto", id);
            
            return View(data);
        }

        // GET: ProyectosController/Create
        public ActionResult Create()
        {
            //
            return View();
        }

        // POST: ProyectosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proyecto data)
        {
            try
            {
                
                if (data.FechaInicio < DateTime.Now)
                {
                    ModelState.AddModelError("FechaInicio", "La fecha de inicio no puede ser anterior a la fecha actual.");
                    return View(data);
                }
                if (data.FechaFin <= data.FechaInicio )
                {
                    ModelState.AddModelError("FechaFin", "La fecha de fin debe ser mayor que la fecha de inicio.");
                    return View(data);
                }
                Crud<Modelos.Proyecto>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: ProyectosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Modelos.Proyecto>.GetById(id);
            return View(data);
        }

        // POST: ProyectosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Proyecto data)
        {
            try
            {
                if (data.FechaInicio < DateTime.Now)
                {
                    ModelState.AddModelError("FechaInicio", "La fecha de inicio debe ser mayor que la fecha actual.");
                    return View(data);
                }
                if (data.FechaFin <= data.FechaInicio)
                {
                    ModelState.AddModelError("FechaFin", "La fecha de fin debe ser mayor que la fecha de inicio.");
                    return View(data);
                }
                Crud<Modelos.Proyecto>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: ProyectosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Modelos.Proyecto>.GetById(id);
            return View(data);
        }

        // POST: ProyectosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Proyecto data)
        {
            try
            {
                Crud<Modelos.Proyecto>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
