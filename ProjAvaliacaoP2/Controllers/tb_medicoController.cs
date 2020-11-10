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
    public class tb_medicoController : Controller
    {
        private DadosEntities db = new DadosEntities();

        // GET: tb_medico
        public ActionResult Index()
        {
            var tb_medico = db.tb_medico.Include(t => t.tb_endereco).Include(t => t.tb_especialidade);
            return View(tb_medico.ToList());
        }

        // GET: tb_medico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_medico tb_medico = db.tb_medico.Find(id);
            if (tb_medico == null)
            {
                return HttpNotFound();
            }
            return View(tb_medico);
        }

        // GET: tb_medico/Create
        public ActionResult Create()
        {
            ViewBag.id_endereco = new SelectList(db.tb_endereco, "id", "cep");
            ViewBag.id_especialidade = new SelectList(db.tb_especialidade, "id", "nome");
            return View();
        }

        // POST: tb_medico/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,cpf,rg,telefone,data_nascimento,crm,id_especialidade,id_endereco")] tb_medico tb_medico)
        {
            if (ModelState.IsValid)
            {
                db.tb_medico.Add(tb_medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_endereco = new SelectList(db.tb_endereco, "id", "cep", tb_medico.id_endereco);
            ViewBag.id_especialidade = new SelectList(db.tb_especialidade, "id", "nome", tb_medico.id_especialidade);
            return View(tb_medico);
        }

        // GET: tb_medico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_medico tb_medico = db.tb_medico.Find(id);
            if (tb_medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_endereco = new SelectList(db.tb_endereco, "id", "cep", tb_medico.id_endereco);
            ViewBag.id_especialidade = new SelectList(db.tb_especialidade, "id", "nome", tb_medico.id_especialidade);
            return View(tb_medico);
        }

        // POST: tb_medico/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,cpf,rg,telefone,data_nascimento,crm,id_especialidade,id_endereco")] tb_medico tb_medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_endereco = new SelectList(db.tb_endereco, "id", "cep", tb_medico.id_endereco);
            ViewBag.id_especialidade = new SelectList(db.tb_especialidade, "id", "nome", tb_medico.id_especialidade);
            return View(tb_medico);
        }

        // GET: tb_medico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_medico tb_medico = db.tb_medico.Find(id);
            if (tb_medico == null)
            {
                return HttpNotFound();
            }
            return View(tb_medico);
        }

        // POST: tb_medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_medico tb_medico = db.tb_medico.Find(id);
            db.tb_medico.Remove(tb_medico);
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
