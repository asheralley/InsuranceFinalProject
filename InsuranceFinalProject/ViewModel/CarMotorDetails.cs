using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsuranceFinalProject.Models;

namespace InsuranceFinalProject.ViewModel
{
    public class CarMotorDetails
    {
        public IEnumerable<User> UserDetails { get; set; }
        public IEnumerable<Car> CarDetails { get; set; }
        public IEnumerable<MotorBike> MotorBikeDetails{ get; set; }
    }
}