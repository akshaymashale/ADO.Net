//See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using System.Data;

namespace ADO_Connected_Demo
{

    internal class Program
    {

        private static SqlConnection con;
        private static SqlCommand cmd;
        private static SqlDataReader rd;
        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection("data source=YISC1101240LT\\SQLEXPRESS;initial catalog=DB1;integrated security=true;TrustServerCertificate=true");
                cmd = new SqlCommand();

                // associate con with cmd
                cmd.Connection = con;


                // To add New Employee
                System.Console.WriteLine("........... Add New Employee in Employees .......................");

                System.Console.WriteLine("Enter first name");
                string fname = Console.ReadLine();
                System.Console.WriteLine("Enter last name");
                string lname = Console.ReadLine();
                System.Console.WriteLine("Enter Salary:");
                decimal salary = Convert.ToDecimal(Console.ReadLine());

                cmd.CommandText = "insert into employees(fname,lname,salary) values (@fname, @lname, @salary)";
                con.Open();
                SqlParameter p1 = new SqlParameter("@fname",SqlDbType.VarChar);
                SqlParameter p2 = new SqlParameter("@lname",SqlDbType.VarChar);
                SqlParameter p3 = new SqlParameter("@salary",SqlDbType.Decimal);

                p1.Value = fname;
                p2.Value = lname;
                p3.Value = salary;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                int rows = cmd.ExecuteNonQuery();

                if(rows>0){
                    System.Console.WriteLine("Record added successfully");
                }
                else{
                    System.Console.WriteLine("Error while adding record");
                }
            }
            catch (SqlException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}