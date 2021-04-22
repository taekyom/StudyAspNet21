using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;
using MyPortpolio.Data;

namespace MyPortfolio.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var account = new Account();
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email, Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                var result = CheckAccount(account.Email, account.Password);
                if(result == null) //계정없음
                { //계정이 없으므로 화면을 Home/Index로 이동
                    ViewBag.Message = "해당 계정이 없습니다.";
                    return View("Login");
                }
                else
                { //로그인을 시켜줌
                    HttpContext.Session.SetString("UserEmail", result.Email);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Login");
        }

        private Account CheckAccount(string email, string password)
        {
            return _context.Account.SingleOrDefault(a => a.Email.Equals(email) && a.Password.Equals(password));
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
