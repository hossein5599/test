using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormAuthenticationInMvc5.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string UserMail { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
[DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="به یاد داشته باش")]
        public bool RememberMe { get; set; }
    }
}