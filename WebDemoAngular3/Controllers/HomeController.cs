using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemoAngular3.Models;

namespace WebDemoAngular3.Controllers
{
    public class HomeController : Controller
    {
        BookDBContext contextObj = new BookDBContext();
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        // GET: All books
        public JsonResult GetAllBooks()
        {
                var bookList = contextObj.book.ToList();
                return Json(bookList, JsonRequestBehavior.AllowGet);
        }
        //GET: Book by Id
        public JsonResult GetBookById(string id)
        {
                var bookId = Convert.ToInt32(id);
                var getBookById = contextObj.book.Find(bookId);
                return Json(getBookById, JsonRequestBehavior.AllowGet);
        }
        //Update Book
        public string UpdateBook(Book book)
        {
            if (book != null)
            {
                    int bookId = Convert.ToInt32(book.Id);
                    Book _book = contextObj.book.Where(b => b.Id == bookId).FirstOrDefault();
                    _book.Title = book.Title;
                    _book.Author = book.Author;
                    _book.Publisher = book.Publisher;
                    _book.Isbn = book.Isbn;
                    contextObj.SaveChanges();
                    return "Book record updated successfully";
            }
            else
            {
                return "Invalid book record";
            }
        }
        // Add book
        public string AddBook(Book book)
        {
            if (book != null)
            {
                contextObj.book.Add(book);
                contextObj.SaveChanges();
                return "Book record added successfully";
            }
            else
            {
                return "Invalid book record";
            }
        }
        // Delete book
        public string DeleteBook(string bookId)
        {

            if (!String.IsNullOrEmpty(bookId))
            {
                try
                {
                    int _bookId = Int32.Parse(bookId);
                    var _book = contextObj.book.Find(_bookId);
                    contextObj.book.Remove(_book);
                    contextObj.SaveChanges();
                    return "Selected book record deleted sucessfully";
                }
                catch (Exception)
                {
                    return "Book details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}