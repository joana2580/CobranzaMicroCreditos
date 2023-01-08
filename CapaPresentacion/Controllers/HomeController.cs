using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaDatos;

namespace CapaPresentacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }
        
        [HttpGet] //url que devuelve datos
        public JsonResult ListarDeudores()  
        {
            List<Deudores> oLista = new List<Deudores>();

            oLista = new C_Deudores().Listar();

            return Json(new { data = oLista} ,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarDeudor(Deudores objeto)
        {
            object resultado;

            string mensaje = string.Empty;
            
            if(objeto.IdDeudor == 0)
            {
                resultado = new C_Deudores().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new C_Deudores().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarDeudor(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new C_Deudores().Eliminar(id,out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}