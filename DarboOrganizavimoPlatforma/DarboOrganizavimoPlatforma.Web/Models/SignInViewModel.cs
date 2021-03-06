﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Please Enter a valid Email")]
        [EmailAddress(ErrorMessage = "Incorrect Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter a valid Password")]
        [StringLength(15)]
        [DataType(DataType.Password, ErrorMessage = "Please Enter a valid Password")]
        public string Password { get; set; }
    }
}
