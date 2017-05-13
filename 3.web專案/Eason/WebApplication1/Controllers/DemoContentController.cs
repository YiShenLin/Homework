using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DemoContentController : Controller
    {
        // GET: DemoContent
        public ActionResult Index()
        {
            var BookRepository =new Book.Repository.DB_Repository();
            var AllBook = Book.Repository.DB_Repository.FindAllBook();
            var message = string.Format("共收到{0}書籍",AllBook.Count);
            AllBook.ForEach(x => message += string.Format("ISBN：{0}    , 書名:{1}    , 作者:{2}<br/>發佈時間:{3}<br/><br/>",x.ISBN,x.BookName,x.Author,x.Date));
            return View(AllBook);
        }
    }
}