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
            try
            {
                return View(messageDb.Messages.ToList());
            }
            catch(Exception ex)
            {
                TempData["err"] = ex.Message;
                TempData.Keep();
                return RedirectToAction("WrongAction", "Error");
            }
            
        }

        public ActionResult Users()
        {
            try
            {
                return View(insuranceDb.Users.ToList());
            }
            catch (Exception ex)
            {
                TempData["err"] = ex.Message;
                TempData.Keep();
                return RedirectToAction("WrongAction", "Error");
            }


        }

        public ActionResult Claims()
        {
            try
            {
                return View(insuranceDb.Claims.ToList());
            }

            catch (Exception ex)
            {
                TempData["err"] = ex.Message;
                TempData.Keep();
                return RedirectToAction("WrongAction", "Error");
            }
        }

        public ActionResult ClaimsUser(int? id)
        {
            try
            {
                return View(insuranceDb.Users.Find(id));
            }

            catch (Exception ex)
            {
                TempData["err"] = ex.Message;
                TempData.Keep();
                return RedirectToAction("WrongAction", "Error");
            }
        }
    }
}