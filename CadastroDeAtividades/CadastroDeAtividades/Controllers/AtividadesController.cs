using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseModel;
using CadastroDeAtividades.Models;

namespace CadastroDeAtividades.Controllers
{
    public class AtividadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Atividades
        public ActionResult Index()
        {
            return View(db.Atividades.Where(p => p.Ativo == true).ToList());
        }

        // GET: Atividades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividade atividade = db.Atividades.Find(id);
            if (atividade == null)
            {
                return HttpNotFound();
            }
            return View(atividade);
        }

        // GET: Atividades/Create
        public ActionResult Create()
        {
            ViewBag.ComodoID = new SelectList(db.Comodos, "ComodoID", "NomeComodo");
            ViewBag.PessoaID = new SelectList(db.Pessoas, "PessoaID", "Nome");
            return View();
        }

        // POST: Atividades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtividadeID,NomeAtividade,DescricaoAtividade,Ativo,ComodoID,PessoaID")] Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                if (Validacao(atividade) == null)
                {
                    atividade.Ativo = true;
                    db.Atividades.Add(atividade);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Já existe uma pessoa cadastrada com esse nome");
                }
            }

            ViewBag.ComodoID = new SelectList(db.Comodos, "ComodoID", "NomeComodo", atividade.ComodoID);
            ViewBag.PessoaID = new SelectList(db.Pessoas, "PessoaID", "Nome", atividade.PessoaID);
            return View(atividade);
        }

        public Atividade Validacao(Atividade atividade)
        {

            return db.Atividades.FirstOrDefault(x => x.NomeAtividade.Equals(atividade.NomeAtividade));
        }


        // GET: Atividades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividade atividade = db.Atividades.Find(id);
            if (atividade == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComodoID = new SelectList(db.Comodos, "ComodoID", "NomeComodo", atividade.ComodoID);
            ViewBag.PessoaID = new SelectList(db.Pessoas, "PessoaID", "Nome", atividade.PessoaID);
            return View(atividade);
        }

        // POST: Atividades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtividadeID,NomeAtividade,DescricaoAtividade,Ativo,ComodoID,PessoaID")] Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atividade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComodoID = new SelectList(db.Comodos, "ComodoID", "NomeComodo", atividade.ComodoID);
            ViewBag.PessoaID = new SelectList(db.Pessoas, "PessoaID", "Nome", atividade.PessoaID);
            return View(atividade);
        }

        // GET: Atividades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividade atividade = db.Atividades.Find(id);
            if (atividade == null)
            {
                return HttpNotFound();
            }
            return View(atividade);
        }

        // POST: Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atividade atividade = db.Atividades.Find(id);
            atividade.Ativo = false;
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

        public ActionResult Lixeira()
        {

            return View(db.Atividades.Where(p => p.Ativo == false).ToList());
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Recuperar(int id)
        {
            Atividade atividade = db.Atividades.Find(id);
            atividade.Ativo = true;
            db.SaveChanges();
            return RedirectToAction("Lixeira");
        }


    }
}
