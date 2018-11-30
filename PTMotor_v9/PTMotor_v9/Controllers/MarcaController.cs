using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTMotor_v9.Models;

namespace PTMotor_v9.Controllers
{
    public class MarcaController : Controller
    {
        //
        // GET: /Marca/

        BaseDadosDataContext db = new BaseDadosDataContext();

        public ActionResult Index()
        {
            return View(db.Marcas.OrderBy(model=>model.Mar_Descricao));
        }

        //
        // GET: /Marca/Details/5

        public ActionResult Details(int Id)
        {
            return RedirectToAction("Index", "Modelo", new { Id = Id });
           //return View(db.Modelos.Where(model=>model.Mod_Mar_Id==id));
          
        }

        //
        // GET: /Marca/Create

        public ActionResult Create()
        {


            return View();
        }

        //
        // POST: /Marca/Create

        [HttpPost]
        public ActionResult Create(Marca novaMarca)
        {
            try
            {
                // verificar o estado do model...
                if (string.IsNullOrEmpty(novaMarca.Mar_Descricao))
                {
                    ModelState.AddModelError("Mar_Descricao", "A descrição não pode ser vazia.");
                    return View();
                }

                if (ModelState.IsValid)
                {
                   // TODO: Add insert logic here

                   db.Marcas.InsertOnSubmit(novaMarca);

                    db.SubmitChanges(); // atualização da BD

                    return RedirectToAction("Index");
                }
            
            }
            catch
            {
            ////    ViewBag.Lista = new SelectList(db.tipo_cursos, "ID", "nome");
            //return View();
            }

              return View();
        }

        //
        // GET: /Marca/Edit/5

        public ActionResult Edit(int id)
        {
            return View(db.Marcas.Single(z => z.Mar_Id == id));
            
        }

        //
        // POST: /Marca/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (string.IsNullOrEmpty(collection["Mar_Descricao"]))
                {
                    ModelState.AddModelError("Mar_Descricao", "O campo descrição não pode ser nulo.");
                    return View();
                }

                if (ModelState.IsValid)
                {
                    Marca alterado = db.Marcas.Single(n => n.Mar_Id == id);
                    alterado.Mar_Descricao = collection["Mar_Descricao"];
                    
                    db.SubmitChanges();

                    return RedirectToAction("Index");
                }
               
            }
            catch
            {
             
            }
            return View();

        }

        //
        // GET: /Marca/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                using (db)
                {
                    //if already loaded in existing DBContext then use Set().Remove(entity) to delete it.
                    var MarcaApagar = db.Marcas.Where(t => t.Mar_Id == id).FirstOrDefault<Marca>();
                    db.Marcas.DeleteOnSubmit(MarcaApagar);

                    db.SubmitChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                //return View();
            }
            return View();
        }

        //
        // POST: /Marca/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
