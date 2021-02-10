using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormAuthenticationInMvc5.Models.ViewModels
{
    public class RegisterViewModel
    {

        [Display(Name = "ایمیل")]
        public string UserMail { get; set; }
        [Display(Name ="کلمه عبور")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="کلمه عبور وارد شده یکسان نمی باشد.")]
        public string RePassword { get; set; }
    }
}