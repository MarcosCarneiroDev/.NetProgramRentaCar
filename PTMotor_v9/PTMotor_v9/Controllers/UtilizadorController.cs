using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTMotor_v9.Models;

namespace PTMotor_v9.Controllers
{
    public class UtilizadorController : Controller
    {

          BaseDadosDataContext db = new BaseDadosDataContext();
        //
        // GET: /Utilizador/

        public ActionResult Index()
        {
            return View("Utilizador");
        }

        //
        // GET: /Utilizador/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Utilizador/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Utilizador/Create

        [HttpPost]
        public ActionResult Create(Pessoa umaPessoa)
        {
            try
            {
                               // TODO: Add insert logic here

                    // verificar o estado do model...
                umaPessoa.Pes_Gru_Id = 2;


                // 1 - validar se os campos obrigatorios estão preenchidos
                if (string.IsNullOrEmpty(umaPessoa.Pes_Login))
                { 
                    ModelState.AddModelError("Pes_Login", "Falta preencher o login");
                    return View("Utilizador");
                }

                if (string.IsNullOrEmpty(umaPessoa.Pes_Password))
                {
                    ModelState.AddModelError("Pes_Password", "Falta preencher o password");
                    return View("Utilizador");
                }

                if (string.IsNullOrEmpty(umaPessoa.Pes_Nif))
                {
                    ModelState.AddModelError("Pes_NIF", "Falta preencher o Nif");
                    return View("Utilizador");
                }

                if (string.IsNullOrEmpty(umaPessoa.Pes_Nome))
                {
                    ModelState.AddModelError("Pes_Nome", "Falta preencher o Nome");
                    return View("Utilizador");
                }

                if (string.IsNullOrEmpty(umaPessoa.Pes_Contacto))
                {
                    ModelState.AddModelError("Pes_Contacto", "Falta preencher o Contacto");
                    return View("Utilizador");
                }

                // 2 - aceitar so numeora no cc e nif
                int num;
                bool isNum=int.TryParse(umaPessoa.Pes_Nif,out num);
                if (!(isNum))
                {
                    ModelState.AddModelError("Pes_NIF", "O NIF Tem de ser numero");
                    return View("Utilizador");
                }


                 isNum = int.TryParse(umaPessoa.Pes_CC, out num);
                if (!(isNum))
                {
                    ModelState.AddModelError("Pes_CC", "O CC Tem de ser numero");
                    return View("Utilizador");
                }

                    if (ModelState.IsValid)
                    {
                        // TODO: Add insert logic here

                       db.Pessoas.InsertOnSubmit(umaPessoa);

                        db.SubmitChanges(); // atualização da BD

                        return RedirectToAction("Index","Home");
                    }
                    //else
                    //{
                    //    ViewBag.Lista = new SelectList(db.tipo_cursos, "ID", "nome");
                    //    return View();
                    //}
                

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Utilizador");
            }
        }

        //
        // GET: /Utilizador/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Utilizador/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Utilizador/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Utilizador/Delete/5

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
