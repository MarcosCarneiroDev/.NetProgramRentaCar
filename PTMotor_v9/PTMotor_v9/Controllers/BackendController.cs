using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTMotor_v9.Controllers
{
    public class BackendController : Controller
    {
        //
        // GET: /Backend/

        public ActionResult Index()
        {
            if (Session["Autenticado"] ==null)
                 return RedirectToAction("Index", "Home");

            if ((Boolean)Session["Autenticado"] == false)
                return RedirectToAction("Index", "Home");

            return View();
        }

        public ActionResult EditarPerfil()
        {
            return View();
        }

        public ActionResult CL_Principal()
        {
            return View();
        }

        public ActionResult CL_Novo()
        {
            return View();
        }

        public ActionResult CL_Editar()
        {
            return View();
        }

        public ActionResult CL_Eliminar()
        {
            return View();
        }

        public ActionResult Vei_Principal()
        {
            return View();
        }

        public ActionResult Vei_Novo()
        {
            return View();
        }

        public ActionResult Vei_Marcas()
        {
            return RedirectToAction("Index","Marca");
        }

        public ActionResult Vei_Modelos()
        {
            return RedirectToAction("Index", "Modelo");
        }

        public ActionResult Vei_Editar()
        {
            return View();
        }

        public ActionResult Notificacoes()
        {
            return View();
        }

    }
}
