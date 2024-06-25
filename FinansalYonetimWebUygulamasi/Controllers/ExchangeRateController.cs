using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinansalYonetimWebUygulamasi.Controllers
{
    public class ExchangeRateController : Controller
    {
        private readonly ExchangeRateService _exchangeRateService;

        public ExchangeRateController(ExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        public async Task<IActionResult> Index()
        {
            var exchangeRates = await _exchangeRateService.GetExchangeRates();
            return View(exchangeRates);
        }
    }
}
