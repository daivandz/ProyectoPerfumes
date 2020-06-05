using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
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
            ViewBag.MarcaId = (from p in db.Marcas select p).ToList();
            return View(perfumes.ToList());
        }

        public ActionResult IndexMan()
        {
            var perfumes = db.Perfumes.Include(p => p.Marca);
            return View(perfumes.ToList());
        }

        public ActionResult IndexFemale()
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
        public ActionResult Create([Bind(Include = "id,Name,Description,Gender,Price,Image,MarcaId")] Perfume perfume)
        {
            HttpPostedFileBase FileBase = Request.Files[0];

            WebImage image = new WebImage(FileBase.InputStream);

            perfume.Image = image.GetBytes();

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
        public ActionResult Edit([Bind(Include = "id,Name,Description,Gender,Price,Image,MarcaId")] Perfume perfume)
        {
            byte[] imagenActual = null;

            HttpPostedFileBase FileBase = Request.Files[0];

            if (FileBase == null)
            {
                imagenActual = db.Perfumes.SingleOrDefault(t => t.id == perfume.id).Image;
            }
            else
            {
                WebImage image = new WebImage(FileBase.InputStream);

                perfume.Image = image.GetBytes();
            }

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

        public ActionResult getImage(int id)
        {
            Perfume menuk = db.Perfumes.Find(id);
            byte[] byteImage = menuk.Image;

            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream, "image/jpg");
        }

    }
}
