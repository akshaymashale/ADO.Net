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
//                 // SqlCommand.CommandText ==> - This is property of SqlCommand class used to define transact-SQL statements
//                 cmd.CommandText = "select empid, fname, lname, salary from employees";

//                 // cmd.commandType = CommandType.Text;
//                 // select query is execute calling ExecuteReader() method

//                 // Establish connection between Console application and SQL Server database
//                 con.Open();

//                 rd = cmd.ExecuteReader();
//                 while (rd.Read())
//                 {
//                     System.Console.WriteLine($"Id: {rd[0]}\t First name: {rd[1]}\t Last Name: {rd[2]}\t salary: {rd[3]}");
//                 }
//             }
//             catch (SqlException ex)
//             {
//                 System.Console.WriteLine(ex.Message);
//             }
//             finally
//             {
//                 // Terminates the existing connection between your application adn the database server
//                 con.Close();
//             }

//         }
//     }
// }