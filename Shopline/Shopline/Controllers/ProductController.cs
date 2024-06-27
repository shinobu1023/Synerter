//using DatatablesGridDemo.Models;
using Model;
using Shopline.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopline.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDetilRepository _productRepository;
        public ProductController()
        {
            _productRepository = new ProductDetilRepository();
        }
        public ActionResult Index(int pageNumber, int pageSize)
        {
            var response = _productRepository.GetProducts().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return View(response);
        }
        public ActionResult Delete(Product product)
        {
            var response = _productRepository.DeleteProduct(product);
            return RedirectToAction("Index", response);
        }
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult Detail2()
        {
            return View();
        }

        public ActionResult Detail3()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();

        }

        public ActionResult ShoppingCartList()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        //public JsonResult GetSampleData()
        //{
        //    var data = new List<SampleData> {
        //        new SampleData { Id = 1, Name = "Item1", Description="Description1"},
        //        new SampleData { Id = 2, Name = "Item2", Description="Description2"},
        //        new SampleData { Id = 3, Name = "Item3", Description="Description3"},
        //    };
        //    return Json(new { data = data }, JsonRequestBehavior.Allowget); ;
        //}
    }
}