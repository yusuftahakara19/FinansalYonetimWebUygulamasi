using BusinessLayer.Abstract;
using FinansalYonetimWebUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;

namespace FinansalYonetimWebUygulamasi.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;

        public TransactionController(ITransactionService transactionService, IUserService userService)
        {
            _transactionService = transactionService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Login", "User");
            }

            var user = _userService.GetAll(u => u.Email == userEmail).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            var transactions = _transactionService.GetAll(t => t.UserId == user.Id);
            return View(transactions);
        }

        public IActionResult Create()
        {
            var model = new TransactionViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TransactionViewModel model)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var user = _userService.GetAll(u => u.Email == userEmail).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (ModelState.IsValid)
            {
                var transaction = new Transaction
                {
                    Description = model.Description,
                    Amount = model.Amount,
                    Date = model.Date,
                    Category = model.Category,
                    UserId = user.Id
                };
                _transactionService.Create(transaction);
                return RedirectToAction(nameof(Index));
            }
            model.Categories = new List<string>
    {
        "Gıda", "Ulaşım", "Eğitim", "Sağlık", "Eğlence", "Kira", "Diğer"
    };
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var transaction = _transactionService.GetById(id);
            if (transaction == null)
            {
                return NotFound();
            }

            var model = new TransactionViewModel
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Category = transaction.Category,
                UserId = transaction.UserId,
                Categories = new List<string>
        {
            "Gıda", "Ulaşım", "Eğitim", "Sağlık", "Eğlence", "Kira", "Diğer"
        }
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var transaction = _transactionService.GetById(model.Id);
                if (transaction == null)
                {
                    return NotFound();
                }

                transaction.Description = model.Description;
                transaction.Amount = model.Amount;
                transaction.Date = model.Date;
                transaction.Category = model.Category;
                _transactionService.Update(transaction);

                return RedirectToAction(nameof(Index));
            }
            model.Categories = new List<string>
    {
        "Gıda", "Ulaşım", "Eğitim", "Sağlık", "Eğlence", "Kira", "Diğer"
    };
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var transaction = _transactionService.GetById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection form)
        {
            var transaction = _transactionService.GetById(id);
            if (transaction != null)
            {
                _transactionService.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult History(string selectedCategory, DateTime? startDate, DateTime? endDate)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Login", "User");
            }

            var user = _userService.GetAll(u => u.Email == userEmail).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            var transactions = _transactionService.GetAll(t => t.UserId == user.Id);

            if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "Tümü")
            {
                transactions = transactions.Where(t => t.Category == selectedCategory).ToList();
            }

            if (startDate.HasValue)
            {
                transactions = transactions.Where(t => t.Date >= startDate.Value).ToList();
            }

            if (endDate.HasValue)
            {
                transactions = transactions.Where(t => t.Date <= endDate.Value).ToList();
            }

            var model = new TransactionHistoryViewModel
            {
                Transactions = transactions.Select(t => new TransactionViewModel
                {
                    Id = t.Id,
                    Description = t.Description,
                    Amount = t.Amount,
                    Date = t.Date,
                    Category = t.Category,
                    UserId = t.UserId
                }).ToList(),
                Categories = new List<string>
        {
            "Tümü", "Gıda", "Ulaşım", "Eğitim", "Sağlık", "Eğlence", "Kira", "Diğer"
        },
                SelectedCategory = selectedCategory,
                StartDate = startDate ?? DateTime.Now.AddMonths(-1), // Varsayılan olarak son 1 ayı göster
                EndDate = endDate ?? DateTime.Now
            };

            return View(model);
        }

    }
}
