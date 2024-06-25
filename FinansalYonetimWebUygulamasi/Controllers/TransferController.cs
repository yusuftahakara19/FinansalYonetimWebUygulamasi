using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FinansalYonetimWebUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinansalYonetimWebUygulamasi.Controllers
{
    public class TransferController : Controller
    {
        private readonly ITransferService _transferService;
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public TransferController(ITransferService transferService, IUserService userService, IAccountService accountService)
        {
            _transferService = transferService;
            _userService = userService;
            _accountService = accountService;
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

            var transfers = _transferService.GetAll(t => t.SenderUserId == user.Id);
            return View(transfers);
        }


        public IActionResult Create()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var user = _userService.GetAll(u => u.Email == userEmail).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Login", "Users");
            }

            var senderAccounts = _accountService.GetAll(a => a.UserId == user.Id).ToList();
            var recipientAccounts = _accountService.GetAll(a => a.UserId == user.Id || a.UserId != user.Id).ToList();

            var model = new TransferViewModel
            {
                SenderAccounts = senderAccounts,
                RecipientAccounts = recipientAccounts,
                Date = DateTime.Now
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TransferViewModel model)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var user = _userService.GetAll(u => u.Email == userEmail).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Login", "Users");
            }

            if (model.SenderAccountId == model.RecipientAccountId)
            {
                ModelState.AddModelError("", "Gönderen ve alıcı hesapları aynı olamaz.");
            }

            if (ModelState.IsValid)
            {
                var senderAccount = _accountService.GetById(model.SenderAccountId);
                if (senderAccount.Balance < model.Amount)
                {
                    ModelState.AddModelError("", "Bütçeniz yetersiz.");
                    model.SenderAccounts = _accountService.GetAll(a => a.UserId == user.Id).ToList();
                    model.RecipientAccounts = _accountService.GetAll(a => a.UserId == user.Id || a.UserId != user.Id).ToList();
                    return View(model);
                }

                senderAccount.Balance -= model.Amount;
                _accountService.Update(senderAccount);

                var recipientAccount = _accountService.GetById(model.RecipientAccountId);
                recipientAccount.Balance += model.Amount;
                _accountService.Update(recipientAccount);

                var transfer = new Transfer
                {
                    SenderUserId = user.Id,
                    RecipientUserId = recipientAccount.UserId,
                    Amount = model.Amount,
                    Date = model.Date,
                    Description = model.Description
                };
                _transferService.Create(transfer);
                return RedirectToAction(nameof(Index));
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            ViewBag.Errors = errors;

            model.SenderAccounts = _accountService.GetAll(a => a.UserId == user.Id).ToList();
            model.RecipientAccounts = _accountService.GetAll(a => a.UserId == user.Id || a.UserId != user.Id).ToList();
            return View(model);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(TransferViewModel model)
        //{
        //    var userEmail = HttpContext.Session.GetString("UserEmail");
        //    var user = _userService.GetAll(u => u.Email == userEmail).FirstOrDefault();
        //    if (user == null)
        //    {
        //        return RedirectToAction("Login", "Users");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var senderAccount = _accountService.GetById(model.SenderAccountId);
        //        if (senderAccount.Balance < model.Amount)
        //        {
        //            ModelState.AddModelError("", "Bütçeniz yetersiz.");
        //            model.SenderAccounts = _accountService.GetAll(a => a.UserId == user.Id).ToList();
        //            model.RecipientAccounts = _accountService.GetAll(a => a.UserId == user.Id || a.UserId != user.Id).ToList();
        //            return View(model);
        //        }

        //        senderAccount.Balance -= model.Amount;
        //        _accountService.Update(senderAccount);

        //        var recipientAccount = _accountService.GetById(model.RecipientAccountId);
        //        recipientAccount.Balance += model.Amount;
        //        _accountService.Update(recipientAccount);

        //        var transfer = new Transfer
        //        {
        //            SenderUserId = user.Id,
        //            RecipientUserId = recipientAccount.UserId,
        //            Amount = model.Amount,
        //            Date = model.Date,
        //            Description = model.Description
        //        };
        //        _transferService.Create(transfer);
        //        return RedirectToAction(nameof(Index));
        //    }

        //    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
        //    ViewBag.Errors = errors;

        //    model.SenderAccounts = _accountService.GetAll(a => a.UserId == user.Id).ToList();
        //    model.RecipientAccounts = _accountService.GetAll(a => a.UserId == user.Id || a.UserId != user.Id).ToList();
        //    return View(model);
        //}

    }
}
