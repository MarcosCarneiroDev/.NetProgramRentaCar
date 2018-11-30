using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTMotor_v9.Controllers
{
    public class FrontendController : Controller
    {
        //
        // GET: /Frontend/

        public ActionResult Index()
        {
            if (Session["Autenticado"] == null)
                return RedirectToAction("Index", "Home");

            if ((Boolean)Session["Autenticado"] == false)
                return RedirectToAction("Index", "Home");

            return View();
        }

        public ActionResult Editar()
        {
            return View();
        }

        public ActionResult Historico()
        {
            return View();
        }

        public ActionResult Veiculos()
        {
            return View();
        }

        public ActionResult Veiculos_Pagamento()
        {
            return View();
        }

        public ActionResult Veiculos_Confirmar()
        {
            return View();
        }

        public ActionResult Veiculos_Sucesso()
        {
            return View();
        }

    }
}
