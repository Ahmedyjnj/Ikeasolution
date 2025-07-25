﻿using System.ComponentModel.DataAnnotations;

namespace Ikea.PL.ViewModel.Identify
{
    public class SignupViewModel
    {


        [Display(Name ="First name")]
        public string FirstName { get; set; } =null!;

        [Display(Name ="Last Name")]
        public string LastName { get; set; } = null!;


        public string UserName { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;


        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;


        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name ="Is Agree")]
        public bool IsAgree { get; set; } 

    }
}
