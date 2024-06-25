using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using EntityLayer;
using FinansalYonetimWebUygulamasi.Models;
using System.Linq;
using EntityLayer.Concrete;

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

        public IActionResult Details(int id)
        {
            var account = _accountService.GetById(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AccountViewModel model)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var user = _userService.GetAll(u => u.Email == userEmail).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Login", "Users");
            }

            if (ModelState.IsValid)
            {
                var account = new Account
                {
                    AccountName = model.AccountName,
                    Balance = model.Balance,
                    UserId = user.Id
                };
                _accountService.Create(account);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var account = _accountService.GetById(id);
            if (account == null)
            {
                return NotFound();
            }

            var model = new AccountViewModel
            {
                Id = account.Id,
                AccountName = account.AccountName,
                Balance = account.Balance,
                UserId = account.UserId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = _accountService.GetById(model.Id);
                if (account == null)
                {
                    return NotFound();
                }

                account.AccountName = model.AccountName;
                account.Balance = model.Balance;
                _accountService.Update(account);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var account = _accountService.GetById(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection form)
        {
            var account = _accountService.GetById(id);
            if (account != null)
            {
                _accountService.Delete(id);
            }
            return RedirectToAction(nameof(Index)); 
        }


    }
}
