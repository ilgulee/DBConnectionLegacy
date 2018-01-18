using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionLegacy
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection=new SqlConnection("Data Source=LEE;Initial Catalog=StudentTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                connection.Open();
                SqlDataReader reader = null;
                var command=new SqlCommand("SELECT * FROM STUDENTS",connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1}", 
                            reader["FirstName"].ToString(), 
                            reader["LastName"].ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No data available");
                }
                
                reader.Close();
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            Console.ReadKey();
        }
    }
}
