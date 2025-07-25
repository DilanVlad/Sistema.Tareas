using Gestion.API.Consummer;
using Gestion.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Gestion.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: UsuariosController
        public ActionResult Index()
        {
            var data = Crud<Modelos.Usuario>.GetAll();
            return View(data);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Modelos.Usuario>.GetById(id);
            return View(data);
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            //
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario data)
        {
            try
            {
                Crud<Modelos.Usuario>.Create(data); 
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Modelos.Usuario>.GetById(id);
            return View(data);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario data)
        {
            try
            {
                Crud<Modelos.Usuario>.Update(id, data); 
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Modelos.Usuario>.GetById(id);
            return View(data);
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario data)
        {
            try
            {
                Crud<Modelos.Usuario>.Delete(id);
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
