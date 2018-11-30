using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTMotor_v9.Models;

namespace PTMotor_v9.Controllers
{
    public class ModeloController : Controller
    {
        //
        // GET: /Modelo/

        BaseDadosDataContext db = new BaseDadosDataContext();


        public ActionResult Index(int Id)
        {
            if (Session["MarcaId"]==null)
                Session["MarcaId"] = Id;

            if ((int)Session["MarcaId"] !=Id)
                Session["MarcaId"] = Id;

            return View(db.Modelos.Where(model => model.Mod_Mar_Id == Id));
        }

        //
        // GET: /Modelo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Modelo/Create

        public ActionResult Create()
        {
            //SelectList ListaMarcas = new SelectList(db.Marcas, "Mar_Id", "Mar_Descricao");
            //ViewBag.Marcas = ListaMarcas;
            Marca umaMarca = db.Marcas.Where(model => model.Mar_Id == (int)Session["MarcaId"]).FirstOrDefault();
            ViewBag.Marca = umaMarca.Mar_Descricao;
            return View();
        }

        //
        // POST: /Modelo/Create

        [HttpPost]
        public ActionResult Create(Modelo NovoModelo)
        {
            try
            {
                // verificar o estado do model...
                if (string.IsNullOrEmpty(NovoModelo.Mod_Descricao))
                {
                    ModelState.AddModelError("Mod_Descricao", "O campo descrição não pode ser nulo.");
                 
                }


                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here

                    NovoModelo.Mod_Mar_Id = (int)Session["MarcaId"];
                    db.Modelos.InsertOnSubmit(NovoModelo);

                    db.SubmitChanges(); // atualização da BD

                    return RedirectToAction("Index","Modelo",new{Id=(int)Session["MarcaId"]});
                }
                else
                {
                    
                    return View();
                }
            }
            catch
            {
                return View();
            }
        
           // return View();
        }

        //
        // GET: /Modelo/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.Marcas = new SelectList(db.Marcas, "Mar_Id", "Mar_Descricao");
            return View(db.Modelos.Single(z => z.Mod_Id == id));
            //return View();
        }

        //
        // POST: /Modelo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (string.IsNullOrEmpty(collection["Mod_Descricao"]))
                    ModelState.AddModelError("Mod_Descricao", "A descrição não pode ser nula.");


                if (ModelState.IsValid)
                {
                    Modelo alterado = db.Modelos.Single(n => n.Mod_Id == id);
                    alterado.Mod_Descricao = collection["Mod_Descricao"];
                    short v = Convert.ToInt16(collection["Mod_Mar_Id"]);
                    alterado.Mod_Mar_Id = v;

                    db.SubmitChanges();

                    return RedirectToAction("Index", "Modelo", new { Id = (int)Session["MarcaId"] });
                }
                else
                {
                    ViewBag.Lista = new SelectList(db.Modelos, "Mod_Id", "Mod_Descricao");
                    return View();
                }
            }
            catch
            {
                ViewBag.Lista = new SelectList(db.Modelos, "Mod_Id", "Mod_Descricao");
                return View();
            }


        }

        //
        // GET: /Modelo/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                using (db)
                {
                    //if already loaded in existing DBContext then use Set().Remove(entity) to delete it.
                    var ModeloApagar = db.Modelos.Where(t => t.Mod_Id == id).FirstOrDefault<Modelo>();
                    db.Modelos.DeleteOnSubmit(ModeloApagar);

                    db.SubmitChanges();
                }

                return RedirectToAction("Index", "Modelo", new { Id = (int)Session["MarcaId"] });
            }
            catch
            {
                //return View();
            }
            return View();
        }

        //
        // POST: /Modelo/Delete/5

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
