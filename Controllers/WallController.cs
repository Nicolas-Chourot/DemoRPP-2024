using DemoRPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace DemoRPP.Controllers
{
    public class WallController : Controller
    {
        public ActionResult GetMessages(bool forceRefresh = false)
        {
            if (forceRefresh || DB.Messages.HasChanged)
            {
                return PartialView(DB.Messages.ToList().OrderBy(m => m.PublishedTime));
            }
            return null;
        }
        public ActionResult GetMessage(int id)
        {
            string text = "";
            Models.Message message = DB.Messages.Get(id);
            if (message != null)
                text = message.Text;
            return Json(text, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateMessage(string message)
        {
            return Json(DB.Messages.Add(new Models.Message { Text = message }) != 0, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateMessage(int id, string message)
        {
            Models.Message messageToUpdate = DB.Messages.Get(id);
            if (messageToUpdate != null)
            {
                messageToUpdate.Text = message;
                return Json(DB.Messages.Update(messageToUpdate), JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteMessage(int id)
        {
            return Json(DB.Messages.Delete(id), JsonRequestBehavior.AllowGet);
        }
        // GET: Wall
        public ActionResult Index()
        {
            return View();
        }
    }
}