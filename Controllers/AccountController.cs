using IdentetyPackageProject.Models;
using IdentetyPackageProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentetyPackageProject.Controllers {
    public class AccountController : Controller {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index() {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Register(string? returnUrl = null) {
            var response = new RegisterViewModel();
            response.ReturnUrl = returnUrl;
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string? returnUrl = null) {
            registerViewModel.ReturnUrl = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/");
            if (!ModelState.IsValid) {
                return View(registerViewModel);
            }
            AppUser newUser = new AppUser { Email = registerViewModel.EmailAddress, UserName = registerViewModel.UserName };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);
            if (newUserResponse.Succeeded) {
                await _signInManager.SignInAsync(newUser, isPersistent: false);
                // Persistent cookie will stay after closing the browser. This way we logout the user after the tab is closed.
                return LocalRedirect(returnUrl);
            }
            ModelState.AddModelError("Password", "User could not be created. Password not unique enough");
            return View(registerViewModel);
        }
    }
}
