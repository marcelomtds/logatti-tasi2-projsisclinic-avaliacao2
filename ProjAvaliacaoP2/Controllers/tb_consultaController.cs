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
    public class tb_consultaController : Controller
    {
        private DadosEntities db = new DadosEntities();

        // GET: tb_consulta
        public ActionResult Index()
        {
            var tb_consulta = db.tb_consulta.Include(t => t.tb_clinica).Include(t => t.tb_medico).Include(t => t.tb_paciente);
            return View(tb_consulta.ToList());
        }

        // GET: tb_consulta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_consulta tb_consulta = db.tb_consulta.Find(id);
            if (tb_consulta == null)
            {
                return HttpNotFound();
            }
            return View(tb_consulta);
        }

        // GET: tb_consulta/Create
        public ActionResult Create()
        {
            ViewBag.id_clinica = new SelectList(db.tb_clinica, "id", "nome");
            ViewBag.id_medico = new SelectList(db.tb_medico, "id", "nome");
            ViewBag.id_paciente = new SelectList(db.tb_paciente, "id", "nome");
            return View();
        }

        // POST: tb_consulta/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,data_consulta,observacao,id_paciente,id_clinica,id_medico")] tb_consulta tb_consulta)
        {
            if (ModelState.IsValid)
            {
                db.tb_consulta.Add(tb_consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_clinica = new SelectList(db.tb_clinica, "id", "nome", tb_consulta.id_clinica);
            ViewBag.id_medico = new SelectList(db.tb_medico, "id", "nome", tb_consulta.id_medico);
            ViewBag.id_paciente = new SelectList(db.tb_paciente, "id", "nome", tb_consulta.id_paciente);
            return View(tb_consulta);
        }

        // GET: tb_consulta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_consulta tb_consulta = db.tb_consulta.Find(id);
            if (tb_consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_clinica = new SelectList(db.tb_clinica, "id", "nome", tb_consulta.id_clinica);
            ViewBag.id_medico = new SelectList(db.tb_medico, "id", "nome", tb_consulta.id_medico);
            ViewBag.id_paciente = new SelectList(db.tb_paciente, "id", "nome", tb_consulta.id_paciente);
            return View(tb_consulta);
        }

        // POST: tb_consulta/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,data_consulta,observacao,id_paciente,id_clinica,id_medico")] tb_consulta tb_consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_clinica = new SelectList(db.tb_clinica, "id", "nome", tb_consulta.id_clinica);
            ViewBag.id_medico = new SelectList(db.tb_medico, "id", "nome", tb_consulta.id_medico);
            ViewBag.id_paciente = new SelectList(db.tb_paciente, "id", "nome", tb_consulta.id_paciente);
            return View(tb_consulta);
        }

        // GET: tb_consulta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_consulta tb_consulta = db.tb_consulta.Find(id);
            if (tb_consulta == null)
            {
                return HttpNotFound();
            }
            return View(tb_consulta);
        }

        // POST: tb_consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_consulta tb_consulta = db.tb_consulta.Find(id);
            db.tb_consulta.Remove(tb_consulta);
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
