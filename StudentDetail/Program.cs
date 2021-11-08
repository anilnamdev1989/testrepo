using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please wait Connet to the server.......");
            try
            {
                string connection = "Data Source=.;Initial Catalog=Student_Registration;Integrated Security=True;";
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("CreateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                Console.WriteLine("enter your name");
                string name = Console.ReadLine();
                Console.WriteLine("enter your mobile number");
                string mobile = Console.ReadLine();
                Console.WriteLine("enter Gender");
                char gender = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Enter email id");
                string email = Console.ReadLine();
                Console.WriteLine("enter address");
                string add = Console.ReadLine();
                cmd.Parameters.AddWithValue("@Student_Name", name);
                cmd.Parameters.AddWithValue("@Student_Contact_Number", mobile);
                cmd.Parameters.AddWithValue("@Student_Gender", gender);
                cmd.Parameters.AddWithValue("@Student_Email", email);
                cmd.Parameters.AddWithValue("@Student_Address", add);
                int i=cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    Console.WriteLine("enter new record");
                }
                else
                {
                    Console.WriteLine("try again somethig went wrong");
                }
                con.Close();
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                Console.WriteLine(msg);
                Console.WriteLine("connection failed");
            }
    
            
            Console.ReadLine();
        }
    }
}
