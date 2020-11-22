using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ADO_NET_DZ_1
{



    class Program
    {
        SqlConnection connection = null;
        public Program()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString_DZ1"].ConnectionString;
        }


        public void ReadData()
        {
            int countBooks = 0;
            SqlDataReader dataReader = null;
            try
            {
                connection.Open();
                string sqlQuery_1 = "Select count(id) from Books;";
                SqlCommand sqlCommand_1 = new SqlCommand(sqlQuery_1,connection);
                countBooks = (Int32)sqlCommand_1.ExecuteScalar();
                //WriteLine($"Количество книг {countBooks}");
                string sqlQuery_2 = "Select Title, PRICE, PAGES from Books;";
                SqlCommand sqlCommand_2 = new SqlCommand(sqlQuery_2, connection);
                dataReader = sqlCommand_2.ExecuteReader();
                bool headLine = true;
                int pagesSumm = 0;
                int priceSumm = 0;
                //for (int i = 0; i < countBooks; i++)
                while (dataReader.Read())
                {
                    if (headLine)
                    {
                        for (int j = 0; j < dataReader.FieldCount; j++) Write(dataReader.GetName(j).ToString() + "\t\t\t");
                        WriteLine();
                    }
                    headLine = false;
                    string title = dataReader.GetString(0);
                    int price = dataReader.GetInt32(1);
                    int pages = dataReader.GetInt32(2);
                    priceSumm += price;
                    pagesSumm += pages;
                    WriteLine(title + "\t" + price + "\t\t\t" + pages);
                }
                WriteLine($"Сумарная цена всех книг: {priceSumm}.");
                WriteLine($"Сумарное количество страниц всех книг: {pagesSumm}.");
            }
            finally
            {
                if (dataReader != null) dataReader.Close();
                if (connection != null) connection.Close();
            }

        }

        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.ReadData();
            ReadKey();
        }
    }
}
