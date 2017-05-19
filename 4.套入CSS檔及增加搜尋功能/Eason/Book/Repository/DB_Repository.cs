using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Repository
{
    public class DB_Repository
    {
        private const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\new\4.套入CSS檔及增加搜尋功能\Eason\ConsoleApplication1\APP_Data\BookDB.mdf;Integrated Security=True";


        public void Create(List<Book.Model.Booklist> Book)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            foreach (var station in Book)
            {
                var command = new System.Data.SqlClient.SqlCommand("", connection);
                command.CommandText = string.Format(@"
INSERT        INTO    Tablee(ISBN, BookName,Author,Date)
VALUES          (N'{0}',N'{1}',N'{2}',N'{3}')
", station.ISBN.Replace("'", "''"), station.BookName.Replace("'", "''"), station.Author.Replace("'", "''"), station.Date);


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
                result.Add(item);
            }
            connection.Close();


            return result;
        }
    }

}
