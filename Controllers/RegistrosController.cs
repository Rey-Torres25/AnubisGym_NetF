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
                //lst = (from d in db.cliente
                //       where d.idStatus == 1
                //       select new ClienteTableViewModel
                //       {
                //           Id = d.id,
                //           Nombre = d.nombre,
                //           Edad = d.edad,
                //           Correo = d.correo,
                //           Telefono = d.telefono,
                //           Direccion = d.direccion,
                //           FechaRegistro = d.fecha_registro
                //       }).ToList();
                //var Tiempo = DateTime.Now.ToString("yyyy-MM-dd");
                //string TiempoString = Convert.ToString(Tiempo);
                lst = (from c in db.cliente
                       join s in db.suscripcion_mensual
                       on c.id equals s.idCliente
                       where c.idStatus == 1 
                       select new ClienteTableViewModel
                       {
                           Id = c.id,
                           Nombre = c.nombre,
                           Edad = c.edad,
                           Correo = c.correo,
                           Telefono = c.telefono,
                           Direccion = c.direccion,
                           FechaRegistro = c.fecha_registro,
                           FechaInicio = s.fecha_inicio,
                           FechaFin = s.fecha_fin,
                           PagoMensual = s.pago_mensual
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

            using (AnubisGymNetFEntities db = new AnubisGymNetFEntities())
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

            using (var db = new AnubisGymNetFEntities())
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

                if (model.Password != null && model.Password.Trim() != "")
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
            using (var db = new AnubisGymNetFEntities())
            {
                var oUser = db.user.Find(Id);
                oUser.idStatus = 3; //Eliminamos
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

        public ActionResult RegistroAsistencia()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegistroEntrada(int Id)
        {

            AsistenciaViewModel modelAsist = new AsistenciaViewModel();
            ClienteViewModel modelClient = new ClienteViewModel();


            //var oAsist = db.producto.Find(Id);

            //modelClient.Nombre = 
            List<ClienteViewModel> lst = null;

            using (var db = new AnubisGymNetFEntities())
            {
                lst = (from d in db.cliente
                       select new ClienteViewModel
                       {
                           Nombre = d.nombre,
                           Id = d.id
                       }).ToList();
            }

            List<SelectListItem> clients = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Id + " - " + d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false,
                };
            });
            //-------------------------------------
            //List<AsistenciaTableViewModel> lstAsist = null;

            //using (var db = new AnubisGymNetFEntities())
            //{
            //    string FechaHoy = DateTime.Now.ToString("yyyy-MM-dd");
            //    lstAsist = (from d in db.asistencia
            //                //where d.fecha == FechaHoy
            //                select new AsistenciaTableViewModel
            //                {
            //                    Id = d.id,
            //                    //Nombre = d.nombre,
            //                    //Asistencia = d.asistencia1

            //                }).ToList();
            //}
            ViewBag.clients = clients;
            //ViewBag.lstAsist = lstAsist;

            return View();
        }

        [HttpPost]
        public ActionResult RegistroEntrada(AsistenciaViewModel model)
        {
            //AsistenciaViewModel model = new AsistenciaViewModel();
            var FechaHoy = DateTime.Now.ToString("yyyy-MM-dd");
            //var HoraHoy = DateTime.Now.ToString("hh:mm tt");
            //HoraHoy = model.Hora;
            using (var db = new AnubisGymNetFEntities())
            {
                try
                {
                    var GetUser = (from d in db.asistencia
                                   where d.idCliente == model.IdCliente && d.fecha == FechaHoy
                                   select d).ToList();

                    if (model.IdCliente == GetUser[0].idCliente! && model.Fecha == GetUser[0].fecha!) //Eliminar este if
                    {
                        return Content("No se puede registrar más de dos veces al día");
                    }
                    else
                    {
                        asistencia oAsist = new asistencia();
                        //oAsist.nombre = model.Nombre;
                        oAsist.idCliente = model.IdCliente;
                        oAsist.fecha = model.Fecha;
                        oAsist.hora = model.Hora;
                        //oAsist.asistencia1 = model.Asistencia;

                        db.asistencia.Add(oAsist);
                        db.SaveChanges();
                    }
                }
                catch
                {
                    asistencia oAsist = new asistencia();
                    //oAsist.nombre = model.Nombre;
                    oAsist.idCliente = model.IdCliente;
                    oAsist.fecha = model.Fecha;
                    oAsist.hora = model.Hora;
                    //oAsist.asistencia1 = model.Asistencia;

                    db.asistencia.Add(oAsist);
                    db.SaveChanges();
                }



            }

            //return Redirect(Url.Content("~/Registros/RegistroEntrada/"+FechaHoy));
            return Content("1");
        }

        [HttpGet]
        public ActionResult VerAsistencias()
        {
            List<AsistenciaTableViewModel> lst = null;
            using (var db = new AnubisGymNetFEntities())
            {

                lst = (from a in db.asistencia
                       join c in db.cliente
                       on a.idCliente equals c.id
                       select new AsistenciaTableViewModel
                       {
                           Id = a.id,
                           IdCliente = a.idCliente,
                           NombreCliente = c.nombre,
                           Fecha = a.fecha,
                           Hora = a.hora
                       }).ToList();
            }
            return View(lst);
        }

        [HttpPost]
        public ActionResult DeleteRegistroAsistencia(int Id)
        {
            using (var db = new AnubisGymNetFEntities())
            {
                var oAsist = (from d in db.asistencia
                              where d.id == Id
                              select d).FirstOrDefault();

                /*db.asistencia.Find(Id);*/


                db.asistencia.Remove(oAsist); //Eliminamos
                //db.Entry(oAsist).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

        [HttpGet]
        public ActionResult RenovacionMensual()
        {
            List<ClienteViewModel> lst = null;

            using (var db = new AnubisGymNetFEntities())
            {
                lst = (from d in db.cliente
                       select new ClienteViewModel
                       {
                           Nombre = d.nombre,
                           Id = d.id
                       }).ToList();
            }

            List<SelectListItem> clients = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Id + " - " + d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false,
                };
            });
            ViewBag.clients = clients;
            return View();
        }
        [HttpPost]
        public ActionResult RenovacionMensual(SuscripcionViewModel model)
        {
            using (var db = new AnubisGymNetFEntities())
            {
                if (model.PagoMensual <= 0)
                {
                    return Content("No se pueden agregar valores nulos o en 0");
                }
                else
                {
                    suscripcion_mensual oSM = new suscripcion_mensual();
                    //oAsist.nombre = model.Nombre;
                    oSM.idCliente = model.IdCliente;
                    oSM.fecha_inicio = model.FechaInicio;
                    oSM.fecha_fin = model.FechaFinal;
                    oSM.pago_mensual = model.PagoMensual;
                    //oAsist.asistencia1 = model.Asistencia;
                    db.suscripcion_mensual.Add(oSM);
                    db.SaveChanges();
                }
            }

            //return View();
            return Content("1");
        }

        public ActionResult RegistroEquipo()
        {
            return View();
        }
    }
}