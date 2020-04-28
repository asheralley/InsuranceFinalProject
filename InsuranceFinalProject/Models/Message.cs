//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsuranceFinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Message
    {
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string MsgName { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address")]
        [DataType(DataType.EmailAddress)]
        public string MsgEmail { get; set; }

        [Required(ErrorMessage = "Please enter a phone number")]
        public string MsgPhone { get; set; }

        [Required(ErrorMessage = "Please enter a message subject")]
        public string MsgSub { get; set; }

        [Required(ErrorMessage = "Please enter a message")]
        public string MsgContent { get; set; }
    }
}
