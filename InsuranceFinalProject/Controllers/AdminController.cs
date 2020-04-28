using InsuranceFinalProject.Models;
using InsuranceFinalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace InsuranceFinalProject.Controllers
{
    public class AdminController : Controller
    {
        private MessageEntities messageDb = new MessageEntities();

        private InsuranceEntities insuranceDb = new InsuranceEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Messages()
        {
            return View(messageDb.Messages.ToList());
        }

        public ActionResult Users()
        {
            return View(insuranceDb.Users.ToList());
        }

        public ActionResult Claims()
        {
            return View(insuranceDb.Claims.ToList());
        }

        public ActionResult ClaimsUser(int? id)
        {
            return View(insuranceDb.Users.Find(id));
        }
    }
}