using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using InsuranceFinalProject.Models;
using InsuranceFinalProject.ViewModel;

namespace InsuranceFinalProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private InsuranceEntities db = new InsuranceEntities();

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(UserView U, char VehicleType)
        {
            int sx = db.Users.Where(x => x.UserName == U.UserName).Count();

            if(ModelState.IsValid && sx == 0)
            {
                TempData["user"] = U;
                TempData.Keep();
                if (VehicleType == 'c')
                {
                    return RedirectToAction("RegCar");
                }
                else if (VehicleType == 'm')
                {
                    return RedirectToAction("RegMotor");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewBag.msg = "UserName already exists...";
                return View(U);
            }     
        }

        // Register a car, passed from main registration page
        public ActionResult RegCar()
        {
            // not catching the exeption???
            // may try to add if statement
            if(Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
           
            UserCarMotorModel userCarMotor = new UserCarMotorModel();
            UserView userView = (UserView)TempData["user"];
            userCarMotor.FirstName = userView.FirstName;
            userCarMotor.LastName = userView.LastName;
            userCarMotor.UserName = userView.UserName;
            userCarMotor.Password = userView.Password;


            return View(userCarMotor);
            
        
        }

        [HttpPost]
        public ActionResult RegCar(UserCarMotorModel UCM)
        {
            // Create User reference
            string tempPW = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(UCM.Password)));

            User user = new User
            {
                FirstName = UCM.FirstName,
                LastName = UCM.LastName,
                UserName = UCM.UserName,
                Password = tempPW
            };

            // Create car reference
            Car car = new Car
            {
                CarReg = UCM.CarReg,
                CarValue = UCM.CarValue,
                ModeofUse = UCM.ModeofUse.ToString()
            };

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                car.UserId = user.UserId;
                db.Cars.Add(car);
                db.SaveChanges();

                return RedirectToAction("PleaseLogin", "User");
            }

            // exeption handling here?...
            // Existing user regersting a new vehicle?
            
            return View();
        }

        public ActionResult RegMotor()
        {
            // not catching the exeption???
            // may try to add if statement

            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            
            UserCarMotorModel userCarMotor = new UserCarMotorModel();
            UserView userView = (UserView)TempData["user"];
            userCarMotor.FirstName = userView.FirstName;
            userCarMotor.LastName = userView.LastName;
            userCarMotor.UserName = userView.UserName;
            userCarMotor.Password = userView.Password;


            return View(userCarMotor);
            
        }

        [HttpPost]
        public ActionResult RegMotor(UserCarMotorModel UCM)
        {
            // Create User reference
            string tempPW = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(UCM.Password)));

            User user = new User
            {
                FirstName = UCM.FirstName,
                LastName = UCM.LastName,
                UserName = UCM.UserName,
                Password = tempPW
            };

            // Create car reference
            MotorBike motorBike = new MotorBike
            {
                MotorReg = UCM.MotorReg,
                MotorValue = UCM.MotorValue,
                ModeofUse = UCM.ModeofUse.ToString()
            };

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                motorBike.UserId = user.UserId;
                db.MotorBikes.Add(motorBike);
                db.SaveChanges();

                return RedirectToAction("PleaseLogin", "User");
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserView user)
        {
            //convert password to encrypted characters
            user.Password = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(user.Password)));
            // find instances of users where username and password match
            int sx = db.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).ToList().Count();

            if (sx != 0)
            {
                var User = db.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                // Create session
                Session["UserId"] = User.UserId;
                Session["UserName"] = User.UserName;
                Session["FirstName"] = User.FirstName;
                Session["LastName"] = User.LastName;

                // admin redirection for user with id 10
                if(User.UserId == 10)
                {
                    return RedirectToAction("Index", "Admin");
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.msg = "Check your username and Password";
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // Redirects to special login screen once user has registered a vehicle and their details
        public ActionResult PleaseLogin()
        {
            return View();
        }

        public ActionResult Claim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Claim(Claim customerClaim)
        {
            // exception here?
            customerClaim.UserId = Convert.ToInt32(Session["UserId"]);
            if (ModelState.IsValid)
            {
                db.Claims.Add(customerClaim);
                db.SaveChanges();
                ViewBag.claimMsg = "Your claim has been submitted";
            }
            
            return View();
        }

        public ActionResult MyDetails()
        {
            // handle exemption here!!!
            try
            {
                User user = db.Users.Find(Convert.ToInt32(Session["UserId"]));

                if (user == null)
                {
                    return RedirectToAction("Login", "User");
                }

                var userId = (int)Session["UserId"];

                ViewBag.userFirstName = user.FirstName;
                ViewBag.userLastName = user.LastName;
                ViewBag.userUserName = user.UserName;

                // Find all instances of Cars with a specific userid
                List<Car> carList = db.Cars.Where(x => x.UserId == userId).ToList();
                List<MotorBike> motoList = db.MotorBikes.Where(x => x.UserId == userId).ToList();

                // had to make a specific class to handle enumerating over car and motorcyle lists
                var tables = new CarMotorDetails
                {
                    CarDetails = carList,
                    MotorBikeDetails = motoList
                };

                return View(tables);
            }
            catch(Exception ex)
            {
                TempData["err"] = ex.Message;
                TempData.Keep();
                return RedirectToAction("WrongAction", "Error");
            }
  
        }

        // exisiting user can register another vehicle to their account
        public ActionResult RegisterVehicle()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        [HttpPost]
        public ActionResult RegisterVehicle(char newVehicleType)
        {
            if (newVehicleType == 'c')
            {
                return RedirectToAction("NewRegCar");
            }
            else if (newVehicleType == 'm')
            {
                return RedirectToAction("NewRegMotor");
            }
            else
            {
                return View();
            }
        }

        public ActionResult NewRegCar()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        [HttpPost]
        public ActionResult NewRegCar(CarMotorViewModel newCarMotor)
        {
            
            Car newCar = new Car();
            newCar.UserId = (int)Session["UserId"];
            newCar.CarReg = newCarMotor.CarReg;
            newCar.CarValue = newCarMotor.CarValue;
            newCar.ModeofUse = newCarMotor.ModeofUse.ToString();
            if (ModelState.IsValid)
            {
                db.Cars.Add(newCar);
                db.SaveChanges();
            }
            
            return View();
        }

        public ActionResult NewRegMotor()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        [HttpPost]
        public ActionResult NewRegMotor(CarMotorViewModel newCarMotor)
        {
            MotorBike newMoto = new MotorBike();
            newMoto.UserId = (int)Session["UserId"];
            newMoto.MotorReg = newCarMotor.MotorReg;
            newMoto.MotorValue = newCarMotor.MotorValue;
            newMoto.ModeofUse = newCarMotor.ModeofUse.ToString();
            if (ModelState.IsValid)
            {
                db.MotorBikes.Add(newMoto);
                db.SaveChanges();
            }

            return View();
        }

        public ActionResult EditDetails()
        {
            try
            {
                User userEdit = db.Users.Find(Convert.ToInt32(Session["UserId"]));

                UserView userViewEdit = new UserView();

                userViewEdit.FirstName = userEdit.FirstName;
                userViewEdit.LastName = userEdit.LastName;
                userViewEdit.UserName = userEdit.UserName;
                userViewEdit.Password = userEdit.Password;

                return View(userViewEdit);
            }
            catch(Exception ex)
            {
                TempData["err"] = ex.Message;
                TempData.Keep();
                return RedirectToAction("WrongAction", "Error");
            }
            
        }

        [HttpPost]
        public ActionResult EditDetails(UserView userView)
        {
            if (ModelState.IsValid)
            {
                User userUpdate = new User();
                userUpdate.UserId = Convert.ToInt32(Session["UserId"]);
                userUpdate.Password = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(userView.Password)));
                userUpdate.FirstName = userView.FirstName;
                userUpdate.LastName = userView.LastName;
                userUpdate.UserName = userView.UserName;

                db.Entry(userUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.successMsg = "Your details have been updated!";
                return View();
            }
            else
            {
                ViewBag.errorMsg = "Username already exists";
                return View(userView);
            }

        }
    }
}