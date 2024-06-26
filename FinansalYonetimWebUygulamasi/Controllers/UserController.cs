using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FinansalYonetimWebUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinansalYonetimWebUygulamasi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Name = model.Name, Email = model.Email, Password = model.Password };
                _userService.Register(user);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Authenticate(model.Email, model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid email or password");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserEmail");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userEmail = HttpContext.Session.GetString("UserEmail");
                var user = _userService.GetAll(u => u.Email == userEmail).FirstOrDefault();
                if (user != null && user.Password == model.CurrentPassword)
                {
                    user.Password = model.NewPassword;
                    _userService.Update(user);
                    ViewBag.Message = "Şifre değiştirme işleminiz başarıyla tamamlandı.";
                }
                else
                {
                    ModelState.AddModelError("", "Current password is incorrect.");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAccount()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var user = _userService.GetAll(u => u.Email == userEmail).FirstOrDefault();

            if (user != null)
            {
                _userService.Delete(user.Id);
                HttpContext.Session.Remove("UserEmail");
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Hesap silinemedi.");
            return RedirectToAction("ChangePassword");
        }
    }
}
