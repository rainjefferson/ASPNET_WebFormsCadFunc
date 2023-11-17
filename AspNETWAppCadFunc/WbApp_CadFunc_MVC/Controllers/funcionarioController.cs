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
    public class funcionarioController : Controller
    {
        private ConexaoBanco db = new ConexaoBanco();

        // GET: funcionario
        public ActionResult Index()
        {
            var tb_funcionario = db.tb_funcionario.Include(t => t.tb_departamento);
            return View(tb_funcionario.ToList());
        }

        // GET: funcionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_funcionario tb_funcionario = db.tb_funcionario.Find(id);
            if (tb_funcionario == null)
            {
                return HttpNotFound();
            }
            return View(tb_funcionario);
        }

        // GET: funcionario/Create
        public ActionResult Create()
        {
            ViewBag.id_departamento = new SelectList(db.tb_departamento, "Id", "nome");
            return View();
        }

        // POST: funcionario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,sobrenome,email,RG,CPF,logradouro,bairro,cidade,UF,id_departamento")] tb_funcionario tb_funcionario)
        {
            if (ModelState.IsValid)
            {
                db.tb_funcionario.Add(tb_funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_departamento = new SelectList(db.tb_departamento, "Id", "nome", tb_funcionario.id_departamento);
            return View(tb_funcionario);
        }

        // GET: funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            tb_funcionario tb_funcionario = db.tb_funcionario.Find(id);

            ViewBag.Departamentos = db.tb_departamento.ToList();

            if (tb_funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_departamento = new SelectList(db.tb_departamento, "Id", "nome", tb_funcionario.id_departamento);
            return View(tb_funcionario);
        }

        // POST: funcionario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,sobrenome,email,RG,CPF,logradouro,bairro,cidade,UF,id_departamento")] tb_funcionario tb_funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_departamento = new SelectList(db.tb_departamento, "Id", "nome", tb_funcionario.id_departamento);
            return View(tb_funcionario);
        }

        // GET: funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_funcionario tb_funcionario = db.tb_funcionario.Find(id);
            if (tb_funcionario == null)
            {
                return HttpNotFound();
            }
            return View(tb_funcionario);
        }

        // POST: funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_funcionario tb_funcionario = db.tb_funcionario.Find(id);
            db.tb_funcionario.Remove(tb_funcionario);
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
