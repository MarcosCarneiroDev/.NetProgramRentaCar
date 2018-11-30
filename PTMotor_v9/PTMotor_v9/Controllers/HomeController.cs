using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTMotor_v9.Models;

namespace PTMotor_v9.Controllers
{
    public class HomeController : Controller
    {
        PTMotor_v9.Models.BaseDadosDataContext BD =new Models.BaseDadosDataContext();
        
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }

        public ActionResult Veiculos()
        {
            return View();
        }

        public ActionResult Sitemap()
        {
            return View();
        }

        #region Registar
        public ActionResult Registar()
        {
            return View();
        }

        public ActionResult RegistarUtilizador(string Nome )
        {
            return View();
        }
        #endregion

        public ActionResult CriarVeiculo()
        {
            return View();
        }

        #region Login

        public ActionResult EfectuarLogin(String TBNome, string TBPassword)
        {
            PTMotor_v9.Models.Pessoa umaPessoa= BD.Pessoas.FirstOrDefault(user=>user.Pes_Login==TBNome && user.Pes_Password==TBPassword);

            if (umaPessoa == null)
                return View("Index");
            else
            {
                Session["Autenticado"] = true;

                if (umaPessoa.Pes_Gru_Id==1)
                    return RedirectToAction("Index", "Backend");
                else
                    return RedirectToAction("Index", "FrontEnd");
            }
        }
#endregion
    }
}
