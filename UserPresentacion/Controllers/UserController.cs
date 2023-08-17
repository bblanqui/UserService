using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserPresentacion.ServiceUser;
using UserService;
namespace UserPresentacion.Controllers
{
    public class UserController : Controller
    {
        UserConsumer serviceUser = new UserConsumer();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public JsonResult Create(Model.User usuario)
        {
            string dateString = usuario.Birthdate;
            DateTime parsedDate = DateTime.Parse(dateString);
            bool result = serviceUser.CreateUser(usuario.NameUser, usuario.GenderUser, parsedDate);
            if (result)
            {
                return Json(new { message = "Usuario creado exitosamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = "Error al crear el usuario" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public JsonResult Users(int id)
        {
            List<Model.User> usuario = serviceUser.ReadUsers();
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }


        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
