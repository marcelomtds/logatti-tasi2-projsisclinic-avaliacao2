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
    public class tb_especialidadeController : Controller
    {
        private DadosEntities db = new DadosEntities();

        // GET: tb_especialidade
        public ActionResult Index()
        {
            return View(db.tb_especialidade.ToList());
        }

        // GET: tb_especialidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_especialidade tb_especialidade = db.tb_especialidade.Find(id);
            if (tb_especialidade == null)
            {
                return HttpNotFound();
            }
            return View(tb_especialidade);
        }

        // GET: tb_especialidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_especialidade/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome")] tb_especialidade tb_especialidade)
        {
            if (ModelState.IsValid)
            {
                db.tb_especialidade.Add(tb_especialidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_especialidade);
        }

        // GET: tb_especialidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_especialidade tb_especialidade = db.tb_especialidade.Find(id);
            if (tb_especialidade == null)
            {
                return HttpNotFound();
            }
            return View(tb_especialidade);
        }

        // POST: tb_especialidade/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome")] tb_especialidade tb_especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_especialidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_especialidade);
        }

        // GET: tb_especialidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_especialidade tb_especialidade = db.tb_especialidade.Find(id);
            if (tb_especialidade == null)
            {
                return HttpNotFound();
            }
            return View(tb_especialidade);
        }

        // POST: tb_especialidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_especialidade tb_especialidade = db.tb_especialidade.Find(id);
            db.tb_especialidade.Remove(tb_especialidade);
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
