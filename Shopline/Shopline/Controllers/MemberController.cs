using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopline.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit() 
        {
            return View();
        }  
    }
}