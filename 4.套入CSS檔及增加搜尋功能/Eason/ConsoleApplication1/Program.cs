using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Book.Model;
using Book.Repository;
using ConsoleApplication1.Models.Service;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Booklist>list = new List<Booklist>();
            XmlLoad load = new XmlLoad();
            var Path = "http://isbn.ncl.edu.tw/NCL_ISBNNet/opendata/isbn.xml";
            list =   load.LoadBookXml(Path);


          //  var t=list.Count(x => x.Readability == null);
            var db = new DB_Repository();    
           
            db.Create(list);
            List<Booklist> DB_book = DB_Repository.FindAllBook();
            
            /*for (int i = 0; i < DB_book.Count; i++)
              {
                  Console.WriteLine("書名:" + DB_book[i].BookName);
                  Console.WriteLine("作者:" + DB_book[i].Author);
                  Console.WriteLine("出版日期:" + DB_book[i].Date);
                  Console.WriteLine("ISBN:" + DB_book[i].ISBN);
                  Console.WriteLine("ID:" + DB_book[i].ID);
            }*/
        }



        
    }

}
