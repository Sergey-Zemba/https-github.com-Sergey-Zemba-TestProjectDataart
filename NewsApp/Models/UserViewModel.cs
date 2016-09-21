using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsApp.Models
{
    public class UserViewModel
    {
        //public int Id { get; set; }

        //[Required(ErrorMessage = "Username is empty")]
        //public string Username { get; set; }

        //[Required(ErrorMessage = "Password is empty")]
        //public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}