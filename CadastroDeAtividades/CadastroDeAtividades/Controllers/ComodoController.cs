using BaseModel;
using CadastroDeAtividades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CadastroDeAtividades.Controllers
{
    public class ComodoController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Comodo
        public ActionResult Index()
        {
            return View(db.Comodos.Where(p => p.Ativo == true).ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comodo comodo)
        {
            if (ModelState.IsValid)
            {
                if (Validacao(comodo) == null)
                {
                    comodo.Ativo = true;
                    db.Comodos.Add(comodo);
                    db.SaveChanges();
                    RedirectToAction("Index");
                    return View(comodo);
                }
                else
                {
                    ViewBag.Erro = "Já existem um comodo com esse nome";   
                }
               
                
            }

            return View();
        }


        public  Comodo Validacao (Comodo comodo)
        {

            return db.Comodos.FirstOrDefault(x => x.NomeComodo.Equals(comodo.NomeComodo));
        }


        public ActionResult Details(int? id)
        {
            
            if (id.HasValue != true)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Comodo comodo = db.Comodos.Find(id);

            

            if (comodo == null)
            {
                
                return HttpNotFound();

            }

            
            return View(comodo);

        }

        

        public ActionResult Edit(int? id)
        {
            if (id.HasValue != true)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Comodo comodo = db.Comodos.Find(id);

            

            if (comodo == null)
            {
                
                return HttpNotFound();

            }

            
            return View(comodo);

        }


        [HttpPost]
        public ActionResult Edit(Comodo comodo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comodo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            return View(comodo);

        }

        


        public ActionResult Delete(int? id)
        {
            
            if (id.HasValue != true)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Comodo comodo = db.Comodos.Find(id);

            

            if (comodo == null)
            {
                
                return HttpNotFound();

            }

            
            return View(comodo);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comodo comodo = db.Comodos.Find(id);
            comodo.Ativo = false;
            db.SaveChanges();
            return RedirectToAction("Index");
          

        }

        public ActionResult Lixeira()
        {

            return View(db.Comodos.Where(p => p.Ativo == false).ToList());
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Recuperar(int id)
        {
            Comodo comodo = db.Comodos.Find(id);
            comodo.Ativo = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}