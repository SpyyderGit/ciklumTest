using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.Id = id;

            foreach (var t in db.Books)
            {
                if (t.Id == id)
                {
                    ViewBag.Name = t.Name;
                    ViewBag.Author = t.Author;
                    ViewBag.Price = t.Price;
                    ViewBag.Remark = t.Remark;
                }
            }

            return View();
        }
    }
}