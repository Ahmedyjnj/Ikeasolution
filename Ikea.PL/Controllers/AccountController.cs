using Ikea.PL.ViewModel.Identify;
using IKEa.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ikea.PL.Controllers
{
    public class AccountController : Controller
    {



        #region Services
        public UserManager<ApplicationUser> UserManager ;
        private readonly SignInManager<ApplicationUser> signInManager ;
        public AccountController(UserManager<ApplicationUser> userManager ,SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            this.signInManager = signInManager;
        }




        #endregion


        #region SignUp


        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupViewModel signupView)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var User =await UserManager.FindByNameAsync(signupView.UserName);

            //this user name is already  in use for other account

            if (User is not null)
            {
                ModelState.AddModelError(nameof(signupView.UserName),"this user name is already in use for another account");
                return View(signupView);
            }

            User=new ApplicationUser()
            {
               FName = signupView.FirstName,
                LName = signupView.LastName,
                UserName = signupView.UserName,
                Email = signupView.Email,
                IsAgree = signupView.IsAgree

            };

            var result = await UserManager.CreateAsync(User, signupView.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(LogIn));
            }
            
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(signupView);

            //  Ahmed9ed

        }


        #endregion



        #region LogIn

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel logInViewModel)
        {
          if(!ModelState.IsValid) return BadRequest();

          var user =await UserManager.FindByEmailAsync(logInViewModel.Email);

            if (user is not null)
            {
                var result = await signInManager.PasswordSignInAsync(user, logInViewModel.Password,logInViewModel.RememberMe,true);
                
                //that authentication that will make a token 
                
                //true mean he will count number of faileur lockout

                //is persistance will save the token remember or not for browser

                if (result.IsNotAllowed)
                    ModelState.AddModelError(string.Empty, "this account is not allowed to login");

                if (result.IsLockedOut)
                    ModelState.AddModelError(string.Empty, "this account is locked out");

                if (result.Succeeded)
                {
                    
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }

            }

            ModelState.AddModelError(string.Empty, " invalid  login attempt ");
            return View(logInViewModel);

        }

        //now we will make sign out just delete token 





        #endregion

        #region SignOut
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(LogIn));
        }
        #endregion





    }
}
