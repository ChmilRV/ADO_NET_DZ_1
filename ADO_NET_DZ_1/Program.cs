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

            // Предыдущий вариант использования строки подключения

            // conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;
            //    Initial Catalog=Library;
            //    Integrated Security=SSPI;";

            // Для доступа к файлу конфигурации приложения из нашего кода
            // мы будем пользоваться классом ConfigurationManager,
            // определенным в пространстве имен System.Configuration.

            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString_DZ1"].ConnectionString;
        }



        static void Main(string[] args)
        {




            ReadKey();
        }
    }
}
