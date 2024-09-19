using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreenHillsAPI.Models;

namespace GreenHillsAPI.Controllers
{
    public class SensoresController : Controller
    {
        private BancoDadosAPI db = new BancoDadosAPI();

        // GET: Sensores
        public ActionResult Index()
        {
            return View(db.tbsensores.ToList());
        }

        // GET: Sensores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbsensores tbsensores = db.tbsensores.Find(id);
            if (tbsensores == null)
            {
                return HttpNotFound();
            }
            return View(tbsensores);
        }

        // GET: Sensores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sensores/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nomeComum,nomeCientifico,tempRecomendada,umidRecomendada,lumiRecomendada")] tbsensores tbsensores)
        {
            if (ModelState.IsValid)
            {
                db.tbsensores.Add(tbsensores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbsensores);
        }

        // GET: Sensores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbsensores tbsensores = db.tbsensores.Find(id);
            if (tbsensores == null)
            {
                return HttpNotFound();
            }
            return View(tbsensores);
        }

        // POST: Sensores/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nomeComum,nomeCientifico,tempRecomendada,umidRecomendada,lumiRecomendada")] tbsensores tbsensores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbsensores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbsensores);
        }

        // GET: Sensores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbsensores tbsensores = db.tbsensores.Find(id);
            if (tbsensores == null)
            {
                return HttpNotFound();
            }
            return View(tbsensores);
        }

        // POST: Sensores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbsensores tbsensores = db.tbsensores.Find(id);
            db.tbsensores.Remove(tbsensores);
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
