using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conStr = "Server = Database Engine; Database = My_Learn_ADO_NET; User Id = DESKTOP-JACK228; Password = ";
            SqlConnection con = new SqlConnection(conStr);

            try
            {
                con.Open();
                Console.WriteLine(con.State);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { 
                con.Close();
                Console.WriteLine(con.State);
            }
        }
    }
}
