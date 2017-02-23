using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PQS.UI_Api.Models.Home
{
    public class RegisterViewModel
    {
        [Required]
        public string Pseudo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RePassword { get; set; }

    }
}