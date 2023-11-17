using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WbApp_CadFunc_MVC;

namespace WbApp_CadFunc_MVC.Controllers
{
    public class departamentoController : Controller
    {
        private ConexaoBanco db = new ConexaoBanco();

        // GET: departamento
        public ActionResult Index()
        {
            return View(db.tb_departamento.ToList());
        }

        // GET: departamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_departamento tb_departamento = db.tb_departamento.Find(id);
            if (tb_departamento == null)
            {
                return HttpNotFound();
            }
            return View(tb_departamento);
        }

        // GET: departamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: departamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,descricao")] tb_departamento tb_departamento)
        {
            if (ModelState.IsValid)
            {
                db.tb_departamento.Add(tb_departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_departamento);
        }

        // GET: departamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            tb_departamento tb_departamento = db.tb_departamento.Find(id);

            if (tb_departamento == null)
            {
                return HttpNotFound();
            }
            return View(tb_departamento);
        }

        // POST: departamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,descricao")] tb_departamento tb_departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_departamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_departamento);
        }

        // GET: departamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_departamento tb_departamento = db.tb_departamento.Find(id);
            if (tb_departamento == null)
            {
                return HttpNotFound();
            }
            return View(tb_departamento);
        }

        // POST: departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_departamento tb_departamento = db.tb_departamento.Find(id);
            db.tb_departamento.Remove(tb_departamento);
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
