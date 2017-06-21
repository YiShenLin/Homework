using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DemoContentController : Controller
    {
        // GET: DemoContent
        [HttpGet]
        public ActionResult Index()
        {
            var BookRepository =new Book.Repository.DB_Repository();
            var AllBook = Book.Repository.DB_Repository.FindAllBook();
            var message = string.Format("共收到{0}書籍",AllBook.Count);
            AllBook.ForEach(x => message += string.Format("ISBN：{0}    , 書名:{1}    , 作者:{2}<br/>發佈時間:{3}<br/><br/>",x.ISBN,x.BookName,x.Author,x.Date));
            ViewBag.ResultCount = AllBook.Count;
            return View(AllBook);
        }
        [HttpPost]
        public ActionResult Index(string Search="")
        {
            var BookRepository = new Book.Repository.DB_Repository();
            var AllBook = Book.Repository.DB_Repository.FindAllBook();     
            List<Book.Model.Booklist> SreachResult = AllBook.Where(x => x.BookName.Contains(Search) || x.ISBN.Contains(Search) || x.Author.Contains(Search)).ToList();
            ViewBag.SearchString=Search;
            ViewBag.ResultCount =SreachResult.Count;
            return View(SreachResult);
        }
        [HttpGet]
        public ActionResult BookInfo(string BookID = "")
        {
            var BookRepository = new Book.Repository.DB_Repository();
            List<Book.Model.Booklist> AllBook = Book.Repository.DB_Repository.FindAllBook();
            Book.Model.Booklist Info = new Book.Model.Booklist();
            for (int i = 0; i < AllBook.Count; i++)
            {
                if (AllBook[i].ID.CompareTo(BookID) == 0)
                {
                    Info.ISBN = AllBook[i].ISBN;
                    Info.BookName = AllBook[i].BookName;
                    Info.Author = AllBook[i].Author;
                    Info.Date = AllBook[i].Date;
                    Info.ClassMark = AllBook[i].ClassMark;
                    Info.Editon = AllBook[i].Editon;
                    Info.PublishingHouse = AllBook[i].PublishingHouse;
                    Info.Readability = AllBook[i].Readability;
                    Info.Title = AllBook[i].Title;
                    Info.Image = AllBook[i].Image;
                    Info.ID = BookID;
                    break;
                }
            }

            return View(Info);
        }
        [HttpGet]
        public ActionResult Edit(string BookID = "")
        {
            var BookRepository = new Book.Repository.DB_Repository();
            List<Book.Model.Booklist> AllBook = Book.Repository.DB_Repository.FindAllBook();
            Book.Model.Booklist Info = new Book.Model.Booklist();
            for (int i = 0; i < AllBook.Count; i++)
            {
                if (AllBook[i].ID.CompareTo(BookID) == 0)
                {
                    Info.ISBN = AllBook[i].ISBN;
                    Info.BookName = AllBook[i].BookName;
                    Info.Author = AllBook[i].Author;
                    Info.Date = AllBook[i].Date;
                    Info.ClassMark = AllBook[i].ClassMark;
                    Info.Editon = AllBook[i].Editon;
                    Info.PublishingHouse = AllBook[i].PublishingHouse;
                    Info.Readability = AllBook[i].Readability;
                    Info.Title = AllBook[i].Title;
                    Info.Image= AllBook[i].Image;
                    Info.ID = BookID; 
                    break;
                }
            }
            return View(Info);
        }
        [HttpPost]
        public ActionResult Edit(Book.Model.Booklist EditedBook,string ImageData)
        {
            var storagePath = Server.MapPath("~/Image/");
            var contentPath = Url.Content("~/Image/");
            var BookRepository = new Book.Repository.DB_Repository();
            try
            {
                var base64Data = Regex.Match(ImageData, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                var binData = Convert.FromBase64String(base64Data);


                var stream = new System.IO.MemoryStream(binData);
                var Image = new Bitmap(stream);
                var filename = System.IO.Path.Combine(storagePath, string.Format("{0}.jpg",EditedBook.ID));
                Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                EditedBook.Image = System.IO.Path.Combine(contentPath, string.Format("{0}.jpg", EditedBook.ID));
            }
            catch (Exception ex)
            {
                return View();
            }
            BookRepository.Update(EditedBook);
            return RedirectToAction("Index");
        }
    }
}