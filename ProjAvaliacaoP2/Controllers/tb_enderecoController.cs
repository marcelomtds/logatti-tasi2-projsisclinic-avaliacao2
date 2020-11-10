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
    public class tb_enderecoController : Controller
    {
        private DadosEntities db = new DadosEntities();

        // GET: tb_endereco
        public ActionResult Index()
        {
            return View(db.tb_endereco.ToList());
        }

        // GET: tb_endereco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_endereco tb_endereco = db.tb_endereco.Find(id);
            if (tb_endereco == null)
            {
                return HttpNotFound();
            }
            return View(tb_endereco);
        }

        // GET: tb_endereco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_endereco/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cep,logradouro,numero,complemento,bairro,localidade,uf")] tb_endereco tb_endereco)
        {
            if (ModelState.IsValid)
            {
                db.tb_endereco.Add(tb_endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_endereco);
        }

        // GET: tb_endereco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_endereco tb_endereco = db.tb_endereco.Find(id);
            if (tb_endereco == null)
            {
                return HttpNotFound();
            }
            return View(tb_endereco);
        }

        // POST: tb_endereco/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cep,logradouro,numero,complemento,bairro,localidade,uf")] tb_endereco tb_endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_endereco);
        }

        // GET: tb_endereco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_endereco tb_endereco = db.tb_endereco.Find(id);
            if (tb_endereco == null)
            {
                return HttpNotFound();
            }
            return View(tb_endereco);
        }

        // POST: tb_endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_endereco tb_endereco = db.tb_endereco.Find(id);
            db.tb_endereco.Remove(tb_endereco);
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
