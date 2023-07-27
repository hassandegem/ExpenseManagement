using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManagement.Models
{
    public class UserProfile
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        [MinLength(3,ErrorMessage ="First Name is too short")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        [MinLength(3, ErrorMessage = "Last Name is too short")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress]
        [MinLength(3, ErrorMessage = "Email  is too short")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
       
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}
