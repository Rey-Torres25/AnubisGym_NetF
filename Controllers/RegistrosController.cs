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
            List<ClienteTableViewModel> lst = null;


            using (AnubisGymNetFEntities db = new AnubisGymNetFEntities())
            {
                lst = (from d in db.cliente
                       where d.idStatus == 1
                       select new ClienteTableViewModel
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Edad = d.edad,
                           Correo = d.correo,
                           Telefono = d.telefono,
                           Direccion = d.direccion,
                           FechaRegistro = d.fecha_registro
                       }).ToList();
            }
            int CountCustomer = lst.Count();
            ViewBag.CountCustomer = CountCustomer;
            return View(lst);
        }

        [HttpGet]
        public ActionResult AddRegistroCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRegistroCliente(ClienteViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var Tiempo = DateTime.Now.ToString("yyyy-MM-dd");
            string TiempoString = Convert.ToString(Tiempo);

            using (var db = new AnubisGymNetFEntities())
            {
                cliente oCliente = new cliente();
                oCliente.idStatus = 1;
                oCliente.nombre = model.Nombre;
                oCliente.edad = model.Edad;
                oCliente.correo = model.Correo;
                oCliente.telefono = model.Telefono;
                oCliente.direccion = model.Direccion;
                oCliente.fecha_registro = TiempoString;

                db.cliente.Add(oCliente);
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/Registros/RegistroCliente"));
        }

        public ActionResult EditRegistroCliente(int Id)
        {

            EditClienteViewModel model = new EditClienteViewModel();

            using (var db = new AnubisGymNetFEntities())
            {
                var oCliente = db.cliente.Find(Id);

                model.Nombre = oCliente.nombre;
                model.Edad = oCliente.edad;
                model.Correo = oCliente.correo;
                model.Telefono = oCliente.telefono;
                model.Direccion = oCliente.direccion;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditRegistroCliente(EditClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new AnubisGymNetFEntities())
            {
                var oCliente = db.cliente.Find(model.Id);

                oCliente.nombre = model.Nombre;
                oCliente.edad = model.Edad;
                oCliente.correo = model.Correo;
                oCliente.telefono = model.Telefono;
                oCliente.direccion = model.Direccion;

                db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Registros/RegistroCliente"));
        }

        [HttpPost]
        public ActionResult DeleteRegistroCliente(int Id)
        {
            using (var db = new AnubisGymNetFEntities())
            {
                var oCliente = db.cliente.Find(Id);
                oCliente.idStatus = 3; //Eliminamos
                db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
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
        public ActionResult AddRegistroEmpleado()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddRegistroEmpleado(UserViewModel model)
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

        public ActionResult EditRegistroEmpleado(int Id)
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
        public ActionResult EditRegistroEmpleado(EditUserViewModel model)
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
        public ActionResult DeleteRegistroEmpleado(int Id)
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