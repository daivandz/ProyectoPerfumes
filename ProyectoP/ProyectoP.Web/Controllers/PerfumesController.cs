using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoP.Web.Models;

namespace ProyectoP.Web.Controllers
{
    public class PerfumesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Perfumes
        public ActionResult Index()
        {
            var perfumes = db.Perfumes.Include(p => p.Marca);
            return View(perfumes.ToList());
        }
        public ActionResult IndexClient()
        {
            var perfumes = db.Perfumes.Include(p => p.Marca);
            return View(perfumes.ToList());
        }

        // GET: Perfumes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfume perfume = db.Perfumes.Find(id);
            if (perfume == null)
            {
                return HttpNotFound();
            }
            return View(perfume);
        }

        // GET: Perfumes/Create
        public ActionResult Create()
        {
            ViewBag.MarcaId = new SelectList(db.Marcas, "id", "Name");
            return View();
        }

        // POST: Perfumes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Description,Gender,Price,ImgUrl,MarcaId")] Perfume perfume)
        {
            if (ModelState.IsValid)
            {
                db.Perfumes.Add(perfume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarcaId = new SelectList(db.Marcas, "id", "Name", perfume.MarcaId);
            return View(perfume);
        }

        // GET: Perfumes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfume perfume = db.Perfumes.Find(id);
            if (perfume == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "id", "Name", perfume.MarcaId);
            return View(perfume);
        }

        // POST: Perfumes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Description,Gender,Price,ImgUrl,MarcaId")] Perfume perfume)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfume).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "id", "Name", perfume.MarcaId);
            return View(perfume);
        }

        // GET: Perfumes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfume perfume = db.Perfumes.Find(id);
            if (perfume == null)
            {
                return HttpNotFound();
            }
            return View(perfume);
        }

        // POST: Perfumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfume perfume = db.Perfumes.Find(id);
            db.Perfumes.Remove(perfume);
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
