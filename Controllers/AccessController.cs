using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymAnubisNetF.Models;

namespace GymAnubisNetF.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Enter(string user, string pass)
        {

            try
            {   //Aqui se hace la conexion con la base de datos para validar el loggin.
                using (AnubisGymNetFEntities db = new AnubisGymNetFEntities())
                {

                    var oUser = (from d in db.user
                                 where d.usuario == user.Trim() && d.password == pass.Trim() && d.idStatus == 1
                                 select d).FirstOrDefault();

                    //var userData = (from d in db.users
                    //                    where d.nombre == 
                    //                    select d.nombre).ToString();

                    if (oUser == null)
                    {
                        return Content("El Usuario o la Contraseña son Incorrectos :(");

                    }
                    else
                    {
                        Session["User"] = oUser;
                        Session["Id_user"] = oUser.id;
                        Session["Nombre"] = oUser.usuario.ToString();
                        //Session["Nombre"]
                        //return RedirectToAction("Index", "Home");
                        return Content("1");
                    }

                }

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error" + ex.Message);
            }
        }


        public ActionResult Logoff()
        {
            try
            {
                using (AnubisGymNetFEntities db = new AnubisGymNetFEntities())
                {
                    user useroff = (user)Session["User"];
                    // db.user.Where(U => U.id == useroff.id).Single().idState = 2;
                    // db.SaveChanges();
                    Session["User"] = null;
                    return RedirectToAction("Index", "Home"); ;
                }

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error" + ex.Message);
            }
        }

    }
}