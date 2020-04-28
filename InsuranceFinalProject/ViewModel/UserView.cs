using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceFinalProject.ViewModel
{
    public class UserView
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Please enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a username")]
        [MinLength(4, ErrorMessage = "Username must be greater than 4 characters"), MaxLength(15, ErrorMessage ="Username must be less than 15 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="Password must be longer than 6 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please re-enter your password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}