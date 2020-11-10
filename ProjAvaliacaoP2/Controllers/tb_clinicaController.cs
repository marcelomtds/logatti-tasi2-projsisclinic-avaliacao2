using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjAvaliacaoP2;

namespace ProjAvaliacaoP2.Controllers
{
    public class tb_clinicaController : Controller
    {
        private DadosEntities db = new DadosEntities();

        // GET: tb_clinica
        public ActionResult Index()
        {
            var tb_clinica = db.tb_clinica.Include(t => t.tb_endereco);
            return View(tb_clinica.ToList());
        }

        // GET: tb_clinica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_clinica tb_clinica = db.tb_clinica.Find(id);
            if (tb_clinica == null)
            {
                return HttpNotFound();
            }
            return View(tb_clinica);
        }

        // GET: tb_clinica/Create
        public ActionResult Create()
        {
            ViewBag.id_endereco = new SelectList(db.tb_endereco, "id", "cep");
            return View();
        }

        // POST: tb_clinica/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,telefone,id_endereco")] tb_clinica tb_clinica)
        {
            if (ModelState.IsValid)
            {
                db.tb_clinica.Add(tb_clinica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_endereco = new SelectList(db.tb_endereco, "id", "cep", tb_clinica.id_endereco);
            return View(tb_clinica);
        }

        // GET: tb_clinica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_clinica tb_clinica = db.tb_clinica.Find(id);
            if (tb_clinica == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_endereco = new SelectList(db.tb_endereco, "id", "cep", tb_clinica.id_endereco);
            return View(tb_clinica);
        }

        // POST: tb_clinica/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,telefone,id_endereco")] tb_clinica tb_clinica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_clinica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_endereco = new SelectList(db.tb_endereco, "id", "cep", tb_clinica.id_endereco);
            return View(tb_clinica);
        }

        // GET: tb_clinica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_clinica tb_clinica = db.tb_clinica.Find(id);
            if (tb_clinica == null)
            {
                return HttpNotFound();
            }
            return View(tb_clinica);
        }

        // POST: tb_clinica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_clinica tb_clinica = db.tb_clinica.Find(id);
            db.tb_clinica.Remove(tb_clinica);
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
