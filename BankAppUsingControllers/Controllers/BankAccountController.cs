using Microsoft.AspNetCore.Mvc;
using BankAppUsingControllers.Controllers.Models;

namespace BankAppUsingControllers.Controllers
{
    public class BankAccountController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            if (Request.Method == "GET")
            {
                return Content("<h1>Welcome to the Best Bank</h2>", "text/html");
            }
            else
                return Content("Bad request method");
        }

        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            if (Request.Method == "GET")
            {
                AccountManagement accountManagement = new AccountManagement() { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = "5000" };
                return new JsonResult(accountManagement);
            }
            else
                return Content("Bad request method");
        }
        [Route("account-statement")]
        public IActionResult AccountStatement()
        {
            if (Request.Method == "GET")
            {
                return File("MichalBonczakCVPL.pdf","application/pdf");
            }
            else
                return Content("Bad request method");
        }
        [Route("/get-current-balance/{accountNumber:int}")]
        public IActionResult AccountNumberResult()
        {
            int accountNumber = Convert.ToInt32(Request.RouteValues["accountNumber"]);
            if (Request.Method == "GET")
            {
                if (accountNumber==1001)
                {
                    return Content("5000");
                }
                else
                    return BadRequest("Account Number should be 1001");
            }
            else
                return Content("Bad request method");
        }
        [Route("/get-current-balance")]
        public IActionResult AccountNumberNotSupplied()
        {
            if (Request.Method == "GET")
            {
                return NotFound("Account number should be supplied");
            }
            else
                return Content("Bad request method");
        }

    }
}
