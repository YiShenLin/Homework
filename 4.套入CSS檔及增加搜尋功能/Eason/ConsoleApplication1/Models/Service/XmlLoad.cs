using Book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1.Models.Service
{
    class XmlLoad
    {
        public  List<Book.Model.Booklist> LoadBookXml(string path)
        {
            List<Booklist> BookList = new List<Booklist>();
            XDocument xml = XDocument.Load(path);
            var list = xml.Descendants("Book").ToList();
            list
                 .Where(x => !x.IsEmpty).ToList()
                 .ForEach(BookNode =>
                 {
                     var BookName = BookNode.Element("書名").Value.Trim();
                     var Author = BookNode.Element("作者").Value.Trim();
                     var Date = BookNode.Element("出版年月").Value.Trim();
                     var ISBN = BookNode.Element("ISBN").Value.Trim();
                     var PublishingHouse = BookNode.Element("出版單位").Value.Trim() ?? "";
                     var Title = BookNode.Element("標題").Value.Trim()?? "";
                     var Readability = BookNode.Element("適讀對象").Value.Trim() ?? ""; 
                     var ClassMark = BookNode.Element("類號").Value.Trim() ?? "";
                     var Editon = BookNode.Element("版次").Value.Trim() ?? "";
                     Booklist Book = new Booklist();
                     Book.BookName = BookName;
                     Book.Author = Author;
                     Book.Date = Date;
                     Book.ISBN = ISBN;
                     Book.ClassMark = ClassMark;
                     Book.Editon = Editon;
                     Book.PublishingHouse = PublishingHouse;
                     Book.Title = Title;
                     Book.Readability = Readability;
                     if (BookList.All(x => x.ISBN != ISBN))
                         BookList.Add(Book);

                 });
            return BookList;
        }
    }
}
