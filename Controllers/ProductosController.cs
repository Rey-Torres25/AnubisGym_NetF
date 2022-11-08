using GymAnubisNetF.Models;
using GymAnubisNetF.Models.TableViewModels;
using GymAnubisNetF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymAnubisNetF.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            //var lst = new List<VentaProductoTableViewModel>();
            List<VentaProductoTableViewModel> lst = null;

            //var Nombre = Session["Nombre"];
            using (var db = new AnubisGymNetFEntities())
            {
                lst = (from d in db.venta_prod
                       //where d.idStatus == 1
                       select new VentaProductoTableViewModel
                       {
                           Id = d.id,
                           Cliente = d.cliente,
                           Producto = d.producto,
                           Cantidad = d.cantidad,
                           Precio = d.precio,
                           FechaCompra = d.fecha,
                           Total = d.total
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult SellProducto()
        {
            List<ClienteViewModel> lst = null;
            using (Models.AnubisGymNetFEntities db = new Models.AnubisGymNetFEntities())
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
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });
            //--------------------------------------------------------------------------------
            List<ProductoViewModel> lst1 = null;
            using (Models.AnubisGymNetFEntities db = new Models.AnubisGymNetFEntities())
            {
                lst1 = (from d in db.producto
                        select new ProductoViewModel
                        {
                            NombreProd = d.nombre,
                            Precio = d.precio,
                            Id = d.id
                        }).ToList();
            }

            List<SelectListItem> prods = lst1.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.NombreProd.ToString(),
                    Value = d.Precio.ToString(),
                    Selected = false
                };
            });
            ViewBag.prods = prods;
            ViewBag.clients = clients;
            return View();
        }

        [HttpGet]
        public ActionResult AddProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProducto(ProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var Tiempo = DateTime.Now.ToString("yyyy-MM-dd");
            string TiempoString = Convert.ToString(Tiempo);

            using (var db = new AnubisGymNetFEntities())
            {
                producto oProd = new producto();

                oProd.nombre = model.NombreProd;
                oProd.stock = model.Stock;
                oProd.precio = model.Precio;
                oProd.fecha_registro = TiempoString;
                if (oProd.stock < 0 || oProd.precio < 0)
                {
                    ViewBag.Alert = "No se pueden agregar valores menores a 0";
                    /*Json("No se pueden agregar valores en 0");*/
                    return View("AddProducto");
                }
                else
                {
                    db.producto.Add(oProd);
                    db.SaveChanges();
                }
            }
            return Redirect(Url.Content("~/Productos/Inventario"));
        }
        [HttpGet]
        public ActionResult EditProducto(int Id)
        {
            EditProductoViewModel model = new EditProductoViewModel();

            using (var db = new AnubisGymNetFEntities())
            {
                var oProd = db.producto.Find(Id);

                model.NombreProd = oProd.nombre;
                model.Precio = oProd.precio;
                model.Stock = oProd.stock;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProducto(EditProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new AnubisGymNetFEntities())
            {
                var oProd = db.producto.Find(model.Id);

                oProd.nombre = model.NombreProd;
                oProd.precio = model.Precio;
                oProd.stock = model.Stock;

                if (model.Stock < 0 || model.Precio < 0)
                {
                    ViewBag.Alert2 = "No se pueden agregar valores menores a 0";
                    /*Json("No se pueden agregar valores en 0");*/
                    return View("EditProducto");
                }
                else
                {
                    db.Entry(oProd).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Redirect(Url.Content("~/Productos/Inventario"));
        }

        [HttpPost]
        public ActionResult DeleteProducto(int Id)
        {
            using (var db = new AnubisGymNetFEntities())
            {
                var oProd = db.producto.Find(Id);
                oProd.idStatus = 3; //Eliminamos
                db.Entry(oProd).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

        public ActionResult Inventario()
        {
            List<ProductoTableViewModel> lst = null;
            using (AnubisGymNetFEntities db = new AnubisGymNetFEntities())
            {
                lst = (from d in db.producto
                       where d.idStatus == 1
                       select new ProductoTableViewModel
                       {
                           Id = d.id,
                           NombreProd = d.nombre,
                           Stock = d.stock,
                           Precio = d.precio,
                           FechaRegistro = d.fecha_registro,
                       }).ToList();
            }
            return View(lst);

        }
        [HttpPost]
        public ActionResult ProductosPost(List<VentaProdViewModel> ventaprod)
        {
            //List<string> XD = ventaprod.RemoveAll(item => item == null);
            //List<VentaProdViewModel> XD = ventaprod.Where(x => x != null).ToList();
            //ventaprod.Where(x => x != null).ToList();
            try
            {
                using (AnubisGymNetFEntities db = new AnubisGymNetFEntities())
                {

                    var oProduct = new venta_prod();
                    //int ProdStock;
                    //Convert.ToString(product.Numero_Pedido);

                    foreach (var product in ventaprod)
                    {
                        int Cant = Int32.Parse(product.Cantidad);
                        if (product.Cantidad == null || Cant == 0)
                        {
                            return Content("No se permiten agregar espacios vacios o espacios en blanco");
                        }
                        else
                        {
                            var GetProd = db.producto.Single(d => d.nombre == product.Producto);
                            GetProd.stock -= Int32.Parse(product.Cantidad);

                            if (GetProd.stock <= 0)
                            {
                                return Content("Se exceden las existencias");
                            }
                            else
                            {
                                oProduct.cliente = product.Cliente;
                                oProduct.producto = product.Producto;
                                oProduct.cantidad = product.Cantidad;
                                oProduct.precio = product.Precio;
                                oProduct.fecha = product.Fecha;
                                oProduct.total = product.Total;
                                db.venta_prod.Add(oProduct);
                                db.SaveChanges();
                            }


                        }
                    }
                    return Content("1");
                }
            }
            catch
            {
                return Content("No se puede enviar los productos");
            }

        }
    }
}