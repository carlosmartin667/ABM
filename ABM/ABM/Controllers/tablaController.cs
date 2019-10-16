using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABM.Models;
using ABM.Models.viewModels;

namespace ABM.Controllers
{
    public class tablaController : Controller
    {
        // GET: tabla
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using(TablaEntities1 db= new TablaEntities1())
            {
                 lst = (from d in db.tabla
                            select new ListTablaViewModel
                            {
                                Id = d.Id,
                                sueldo = d.sueldo,
                                nombre = d.nombre,
                                correo = d.correo,
                                //fecha_nacimiento = d.fecha_nacimiento,
                            }).ToList();
            }



            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Nuevo(TablaaViewModel model)
        {

            try
            {

                //validacion 
                if (ModelState.IsValid)
                {
                    using(TablaEntities1 db = new TablaEntities1())
                    {
                        var oTabla = new tabla();
                        oTabla.correo = model.correo;
                        oTabla.sueldo = model.sueldo;
                        oTabla.nombre = model.nombre;
                        //oTabla.fecha_nacimiento = model.fecha_nacimiento;

                        db.tabla.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/tabla/");
                }
                return View(model);
             
            }
            catch (Exception ex)
            {

               throw new Exception(ex.Message);
            }

        }
        public ActionResult Editar(int Id)
        {
             tabla model = new tabla();
            using (TablaEntities1 db = new TablaEntities1() )
            {
                var oTabla = db.tabla.Find(Id);
                model.Id = oTabla.Id;
                model.sueldo = oTabla.sueldo;
                model.nombre = oTabla.nombre;
                model.correo = oTabla.correo;
              
            }
            return View();
        }


        [HttpPost]
        public ActionResult Editar(TablaaViewModel model)
        {

            try
            {

                //validacion 
                if (ModelState.IsValid)
                {
                    using (TablaEntities1 db = new TablaEntities1())
                    {
                        var oTabla = db.tabla.Find(model.Id);
                        oTabla.correo = model.correo;
                        oTabla.nombre = model.nombre;
                        //oTabla.fecha_nacimiento = model.fecha_nacimiento;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/tabla/");
                }
                return View(model);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            TablaEntities1 model = new TablaEntities1();
            using (TablaEntities1 db = new TablaEntities1())
            {
              
                var oTabla = db.tabla.Find(Id);
                db.tabla.Remove(oTabla); 
                db.SaveChanges();
            }
            return Redirect("~/tabla/");
        }
    }
}