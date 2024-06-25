using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using EntityLayer;
using FinansalYonetimWebUygulamasi.Models;
using System.Linq;

namespace FinansalYonetimWebUygulamasi.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Login", "Users");
            }

            var user = _userService.GetAll(u => u.Email == userEmail).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Login", "Users");
            }

            var accounts = _accountService.GetAll(a => a.UserId == user.Id); // Burada UserId değil Id kullanıyoruz
            return View(accounts);
        }
    }
}
