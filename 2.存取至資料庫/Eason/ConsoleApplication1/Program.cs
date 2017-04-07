using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Book.Model;
using Book.Repository;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Booklist> list = new List<Booklist>();
            XDocument xml = XDocument.Load("C:/isbn.xml");
            var db = new Book.Repository.DB_Repository();
           /* var booknodes = xml.Descendants("Book");
            foreach (var bookNode in booknodes)
            {
                var item = new Booklist();

                item.BookName = bookNode.Element("書名").Value.Trim();
                item.Author = bookNode.Element("作者").Value.Trim();
                item.Date = bookNode.Element("出版年月").Value.Trim();
                item.ISBN = bookNode.Element("ISBN").Value.Trim();
                list.Add(item);

            }*/
           
            db.Create(list);
            List<Booklist> DB_book = db.FindAllBook();
            
            for (int i = 0; i < DB_book.Count; i++)
              {
                  Console.WriteLine("書名:" + DB_book[i].BookName);
                  Console.WriteLine("作者:" + DB_book[i].Author);
                  Console.WriteLine("出版日期:" + DB_book[i].Date);
                  Console.WriteLine("ISBN:" + DB_book[i].ISBN);
              }
        }



        
    }

}
