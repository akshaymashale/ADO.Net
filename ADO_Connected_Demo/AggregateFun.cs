// // See https://aka.ms/new-console-template for more information
// using System.Runtime.CompilerServices;
// using System.Data.SqlClient;
// using System.Runtime.Intrinsics.Arm;

// namespace ADO_Connected_Demo
// {

//     internal class Program
//     {

//         private static SqlConnection con;
//         private static SqlCommand cmd;
//         private static SqlDataReader rd;
//         static void Main(string[] args)
//         {
//             try
//             {
//                 con = new SqlConnection("data source=YISC1101240LT\\SQLEXPRESS;initial catalog=DB1;integrated security=true;TrustServerCertificate=true");

//                 System.Console.WriteLine("Connection successful");

//                 cmd = new SqlCommand();

//                 // associate con with cmd
//                 cmd.Connection = con;

//                 cmd.CommandText = "select count(salary) from employees";

//                 // cmd.commandType = CommandType.Text;
//                 // select query is execute calling ExecuteReader() method

//                 con.Open();
//                 int count =(int)cmd.ExecuteScalar();
//                 System.Console.WriteLine($"Total Number of Employees: {count}");
            
//             }
//             catch (SqlException ex)
//             {
//                 System.Console.WriteLine(ex.Message);
//             }
//             finally
//             {
//                 con.Close();
//             }

//         }
//     }
// }