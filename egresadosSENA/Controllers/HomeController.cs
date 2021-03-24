using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using egresadosSENA.Models;

namespace egresadosSENA.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = ma.RecuperarPorDocumento(id);
            return View(usu);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = new usuario
            {
                documento = collection["documento"].ToString(),
                tipo_doc = collection["tipo_doc"].ToString(),
                nombre = collection["nombre"].ToString(),
                celular = collection["celular"].ToString(),
                email = collection["email"].ToString(),
                genero = collection["genero"].ToString(),
                aprendiz = collection["aprendiz"].ToString(),
                egresado = collection["egresado"].ToString(),
                areaformacion = collection["areaformacion"].ToString(),
                fechaegresado = collection["fechaegresado"].ToString(),
                direccion = collection["direccion"].ToString(),
                barrio = collection["barrio"].ToString(),
                ciudad = collection["ciudad"].ToString(),
                departamento = collection["departamento"].ToString(),
                fecharegistro = collection["fecharegistro"].ToString()
            };
            ma.Alta(usu);
            return RedirectToAction("Index");
        }

        public ActionResult BuscarTodos()
        {
            mantenimientousuario ma = new mantenimientousuario();
            return View(ma.RecuperarTodos());
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = ma.Recuperar(id);
            return View(usu);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = new usuario
            {
                id = id,
                documento = collection["documento"].ToString(),
                tipo_doc = collection["tipodoc"].ToString(),
                nombre = collection["nombre"].ToString(),
                celular = collection["celular"].ToString(),
                email = collection["email"].ToString(),
                genero = collection["genero"].ToString(),
                aprendiz = collection["aprendiz"].ToString(),
                egresado = collection["egresado"].ToString(),
                areaformacion = collection["areaformacion"].ToString(),
                fechaegresado = collection["fechaegresado"].ToString(),
                direccion = collection["direccion"].ToString(),
                barrio = collection["barrio"].ToString(),
                ciudad = collection["ciudad"].ToString(),
                departamento = collection["departamento"].ToString(),
                fecharegistro = collection["fecharegistro"].ToString()
            };
            ma.Modificar(usu);
            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = ma.RecuperarPorDocumento(id);
            return View(usu);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            mantenimientousuario ma = new mantenimientousuario();
            ma.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}