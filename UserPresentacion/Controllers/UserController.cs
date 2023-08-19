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

        // Index(): Solo renderiza la vista
        public ActionResult Index()
        {
            return View();
        }

        // ListUsers(): Solo renderiza la vista
        public ActionResult ListUsers()
        {
            return View();
        }


        // Create(): Recibe objeto User, devuelve JSON con mensaje
        [HttpPost]
        public JsonResult Create(Model.User usuario)
        {
            
           
            bool result = serviceUser.CreateUser(usuario);
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


        // Users(): No recibe nada, devuelve lista de usuarios en JSON 
        public JsonResult Users()
        {
            List<Model.User> usuario = serviceUser.ReadUsers();
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }
        // SearchUser(): Recibe nombre, devuelve lista filtrada en JSON
        public JsonResult SearchUser(string name)
        {
            List<Model.User> usuario = serviceUser.SearchUser(name);
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }
        // SearchUserId(): Recibe ID, devuelve usuario por ID en JSON
        public JsonResult SearchUserId(int id)
        {
            List<Model.User> usuario = serviceUser.SearchUserId(id);
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }

        // Delete(): Recibe ID, devuelve JSON con mensaje
        public JsonResult Delete(int id)
        {
            bool result = serviceUser.DeleteUser(id);
            if (result)
            {
                return Json(new { message = "Usuario eliminado exitosamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = "Error al eliminar el usuario" }, JsonRequestBehavior.AllowGet);
            }
        }

        // UpUser(): Recibe objeto User, devuelve JSON con mensaje
        public JsonResult UpUser (Model.User usuario)
        {
            bool result = serviceUser.UpdateUser(usuario);
            if (result)
            {
                return Json(new { message = "Usuario actualizado exitosamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = usuario }, JsonRequestBehavior.AllowGet);
            }
        }

       
    }
}
