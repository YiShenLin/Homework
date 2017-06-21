using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Repository
{
    public class DB_Repository
    {
        private const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LEO\Desktop\Homework\4.套入CSS檔及增加搜尋功能\Eason\ConsoleApplication1\APP_Data\BookDB.mdf;Integrated Security=True";


        public void Create(List<Book.Model.Booklist> BookList)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            foreach (var Book in BookList)
            {
                var command = new System.Data.SqlClient.SqlCommand("", connection);
                command.CommandText = string.Format(@"
INSERT        INTO    Tablee(ISBN, BookName,Author,Date,PublishingHouse,Editon,Title,Readability,ClassMark)
VALUES          (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}')
", Book.ISBN.Replace("'", "''"), Book.BookName.Replace("'", "''"), Book.Author.Replace("'", "''"), Book.Date, Book.PublishingHouse.Replace("'", "''"), Book.Editon.Replace("'", "''"), Book.Title.Replace("'", "''"), Book.Readability.Replace("'", "''"), Book.ClassMark.Replace("'", "''"));


               command.ExecuteNonQuery();
            }



            connection.Close();
        }

        public static List<Book.Model.Booklist> FindAllBook()
        {
            var result = new List<Book.Model.Booklist>();
            var connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = @"
Select * from Tablee";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Book.Model.Booklist item = new Book.Model.Booklist();
                item.BookName = reader["BookName"].ToString();
                item.Author = reader["Author"].ToString();
                item.Date= reader["Date"].ToString();
                item.ISBN = reader["ISBN"].ToString();
                item.ID = reader["ID"].ToString();
                item.PublishingHouse = reader["PublishingHouse"].ToString();
                item.Editon = reader["Editon"].ToString();
                item.Title = reader["Title"].ToString();
                item.Readability = reader["Readability"].ToString();
                item.ClassMark = reader["ClassMark"].ToString();
                item.Image= reader["Image"].ToString();
                result.Add(item);
            }
            connection.Close();


            return result;
        }

        public void Update(Book.Model.Booklist Book)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("",connection);
            command.CommandText = string.Format(@"UPDATE [dbo].[Tablee]
   SET 
       [BookName]=N'{0}'
      ,[Author]=N'{1}'
      ,[Date]=N'{2}'
      ,[ISBN]=N'{3}'
      ,[PublishingHouse]=N'{4}'
      ,[Editon]=N'{5}'
      ,[Title]=N'{6}'
      ,[Readability]=N'{7}'
      ,[ClassMark]=N'{8}'
      ,[Image]=N'{9}'
 WHERE [ID] = N'{10}'", Book.BookName,Book.Author, Book.Date, Book.ISBN, Book.PublishingHouse, Book.Editon, Book.Title, Book.Readability, Book.ClassMark,Book.Image,Book.ID);


            command.ExecuteNonQuery();
            connection.Close();

        }
    }
    
}
