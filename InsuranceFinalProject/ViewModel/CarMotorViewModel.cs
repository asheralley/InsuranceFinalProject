using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceFinalProject.ViewModel
{
    public class CarMotorViewModel
    {
        public int CarId { get; set; }
        public int CarReg { get; set; }
        public int CarValue { get; set; }

        public Mode ModeofUse { get; set; }

        public int MotorId { get; set; }
        public int MotorReg { get; set; }
        public int MotorValue { get; set; }
    }

    public enum Mode
    {
        Personal,
        Business,
        Commercial
    }
}