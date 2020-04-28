using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceFinalProject.ViewModel
{
    public class UserCarMotorModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CarId { get; set; }
        public int CarReg { get; set; }
        public int CarValue { get; set; }

        public Mode ModeofUse { get; set; }

        public int MotorId { get; set; }
        public int MotorReg { get; set; }
        public int MotorValue { get; set; }
    }
}