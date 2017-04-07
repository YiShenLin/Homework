using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Repository
{
    public class DB_Repository
    {
        private const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Source\Repos\Homework\2.存取至資料庫\Eason\ConsoleApplication1\APP_Data\BookDB.mdf;Integrated Security=True";


        public void Create(List<Book.Model.Booklist> stations)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            foreach (var station in stations)
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
    }
}
