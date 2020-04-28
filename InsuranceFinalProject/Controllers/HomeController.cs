using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceFinalProject.Models;

namespace InsuranceFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private MessageEntities db = new MessageEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Message(string MsgName, string MsgEmail, string MsgPhone, string MsgSub, string MsgContent)
        {
            Message message = new Message();
            message.MsgName = MsgName;
            message.MsgEmail = MsgEmail;
            message.MsgPhone = MsgPhone;
            message.MsgSub = MsgSub;
            message.MsgContent = MsgContent;

            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                ViewBag.feedBack = "Your message has been sent";
                ModelState.Clear();
                return View("Contact");
            }
            else
            {
                ViewBag.feedBack = "There was an error sending your message, please try again";
                return View("Contact");
            }
            
        }
    }
}