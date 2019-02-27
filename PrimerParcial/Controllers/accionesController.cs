using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrimerParcial.Models;

namespace PrimerParcial.Controllers
{
    public class accionesController : Controller
    {
        private primer_parcialEntities db = new primer_parcialEntities();

        // GET: acciones
        public ActionResult Index()
        {
            return View(db.acciones.ToList());
        }

        // GET: acciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acciones acciones = db.acciones.Find(id);
            if (acciones == null)
            {
                return HttpNotFound();
            }
            return View(acciones);
        }

        // GET: acciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: acciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,precioAccion,dineroInvertido,accionesOperadas")] acciones acciones)
        {
            if (ModelState.IsValid)
            {
                db.acciones.Add(acciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acciones);
        }

        // GET: acciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acciones acciones = db.acciones.Find(id);
            if (acciones == null)
            {
                return HttpNotFound();
            }
            return View(acciones);
        }

        // POST: acciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,precioAccion,dineroInvertido,accionesOperadas")] acciones acciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acciones);
        }

        // GET: acciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acciones acciones = db.acciones.Find(id);
            if (acciones == null)
            {
                return HttpNotFound();
            }
            return View(acciones);
        }

        // POST: acciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            acciones acciones = db.acciones.Find(id);
            db.acciones.Remove(acciones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
