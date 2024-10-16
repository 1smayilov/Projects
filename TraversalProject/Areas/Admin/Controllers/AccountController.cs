using BusinessLayer.Abstract.AbstractUow;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalProject.Areas.Admin.Models;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {

            var valuesSender = _accountService.GetById(model.SenderId);
            var valuesReceiver = _accountService.GetById(model.ReceiverId);

            valuesSender.Balance -= model.Amount;  
            valuesReceiver.Balance += model.Amount;

            List<Account> modeifiedAccounts = new List<Account>()
            {
                valuesSender,
                valuesReceiver,
            };

            _accountService.MultiUpdate(modeifiedAccounts);

            return View();
        }
    }
}
