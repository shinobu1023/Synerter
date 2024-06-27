using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopline.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginRepository _loginRepository;
        public AccountController()
        {
            _loginRepository = new LoginRepository();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }



        /// <summary>
        /// 範例用法
        /// </summary>
        /// <returns></returns>
        public ActionResult GetLogin()
        {
            var users = _loginRepository.GetAllUsers();
            return View(users);
        }
    }
}