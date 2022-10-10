using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymAnubisNetF.Models;
using GymAnubisNetF.Models.TableViewModels;
using GymAnubisNetF.Models.ViewModels;

namespace GymAnubisNetF.Controllers
{
    public class RegistrosController : Controller
    {
        // GET: Registros
        public ActionResult RegistroCliente()
        {
            return View();
        }



        public ActionResult RegistroEmpleado()
        {
            List<UserTableViewModel> lst = null;

            using(AnubisGymNetFEntities db = new AnubisGymNetFEntities())
            {
                lst = (from d in db.user
                       where d.idStatus == 1
                       select new UserTableViewModel
                       {
                           Id = d.id,
                           NombreUsuario = d.usuario,
                           Correo = d.correo,
                           Nombre = d.nombre,
                           Edad = (int)d.edad,
                       }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult RE_Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RE_Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            using(var db = new AnubisGymNetFEntities())
            {
                user oUser = new user();
                oUser.idStatus = 1;
                oUser.nombre = model.Nombre;
                oUser.usuario = model.NombreUsuario;
                oUser.correo = model.Correo;
                oUser.password = model.Password;
                oUser.edad = model.Edad;

                db.user.Add(oUser);
                db.SaveChanges();

            }
            return Redirect(Url.Content("~/Registros/RegistroEmpleado"));
        }

        public ActionResult EditRE(int Id)
        {

            EditUserViewModel model = new EditUserViewModel();

            using (var db = new AnubisGymNetFEntities())
            {
                var oUser = db.user.Find(Id);

                model.Nombre = oUser.nombre;
                model.NombreUsuario = oUser.usuario;
                model.Correo = oUser.correo;
                model.Edad = oUser.edad;
                model.Id = oUser.id;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditRE(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new AnubisGymNetFEntities())
            { 
                var oUser = db.user.Find(model.Id);
                oUser.nombre = model.Nombre;
                oUser.usuario = model.NombreUsuario;
                oUser.correo = model.Correo;
                oUser.edad = model.Edad;

                if(model.Password!=null && model.Password.Trim() != "")
                {
                    oUser.password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
                return Redirect(Url.Content("~/Registros/RegistroEmpleado"));
        }

        [HttpPost]
        public ActionResult DeleteRE(int Id)
        {
            using ( var db = new AnubisGymNetFEntities())
            {
                var oUser = db.user.Find(Id);
                oUser.idStatus = 3; //Eliminamos
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }


        public ActionResult RegistroEntrada()
        {
            return View();
        }

        public ActionResult RegistroEquipo()
        {
            return View();
        }
    }
}