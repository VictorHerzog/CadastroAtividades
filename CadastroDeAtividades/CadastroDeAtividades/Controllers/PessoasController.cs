using CadastroDeAtividades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseModel;
using System.Web.Mvc;

namespace CadastroDeAtividades.Controllers
{
    public class PessoasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categorias (LISTAGEM)
        public ActionResult Index()
        {
            var Pessoa = db.Pessoas.ToList();

            return View(Pessoa);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {

                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                RedirectToAction("Index");
            }

            return View(pessoa);

        }
    }
}