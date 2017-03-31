using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> list = new List<Book>();
            XDocument xml = XDocument.Load("D:/isbn.xml");
            var booknodes = xml.Descendants("Book");
            foreach (var bookNode in booknodes)
            {
                var item = new Book();

                item.BookName=bookNode.Element("書名").Value.Trim();
                item.Author = bookNode.Element("作者").Value.Trim();
                item.Date = bookNode.Element("出版年月").Value.Trim();
                item.ISBN = bookNode.Element("ISBN").Value.Trim();
                list.Add(item);

            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("書名:"+list[i].BookName);
                Console.WriteLine("作者:"+list[i].Author);
                Console.WriteLine("出版日期:"+list[i].Date);
                Console.WriteLine("ISBN:"+list[i].ISBN);
            }
        }
    }
}
