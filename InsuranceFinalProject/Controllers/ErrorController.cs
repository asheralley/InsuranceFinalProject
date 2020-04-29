using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceFinalProject.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ViewResult WrongAction()
        {
            return View();
        }

        public ViewResult NotFound()
        {
            return View();
        }
    }
}