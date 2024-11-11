// using System.Data.SqlClient;

// namespace ADO_Connection_Demo
// {
//     internal class Program2
//     {
//         // SqlConnection ==> - Establishes a communication channel between your application and the database server.
//         // - Requires a connection string to specify the server, database, authentication credentials, and other connection parameters.
//         private static SqlConnection con;

//         // SqlCommand ==> - Represents a Transact-SQL statement or stored procedure to be executed on a SQL Server database.
//         // - Can be used to execute queries, insert, update, or delete data, or execute stored procedures.
//         private static SqlCommand cmd;

//         // SqlDataReader ==> - A forward-only, read-only data stream used to read data from a SQL Server database.
//         // - Efficient for reading large datasets as it fetches data row by row, minimizing memory usage.
//         private static SqlDataReader rd;
//         static void Main(string[] args)
//         {

//             try
//             {
//                 con = new SqlConnection("data source =YISC1101240LT\\SQLEXPRESS; initial catalog = DB1; integrated security = true; trustservercertificate = true");
//                 System.Console.WriteLine("Server Connection successful");

//                 // intitializing command object
//                 cmd = new SqlCommand();

//                 // Associating SqlCommand with SqlConnection
//                 cmd.Connection = con;

//                 //SqlCommand.CommandText ==> - This is property of SqlCommand class used to define transact-SQL statements

//                 //Non-parameterized query ==> 
//                 cmd.CommandText = "Select prodcode, prodname, price, doe, category from products";

//                 // Parameterized query ==>
//                 SqlParameter p = new SqlParameter("@prodid", System.Data.SqlDbType.Int);
//                 int id;
//                 System.Console.WriteLine("Please enter product id");
//                 id = Convert.ToInt32(Console.ReadLine());
//                 p.Value = id;
//                 cmd.Parameters.Add(p);

//                 // cmd.commandType = CommandType.Text;
//             // select query is execute calling ExecuteReader() method
//                 con.Open();
//                 // 
//                 rd = cmd.ExecuteReader();

//                 while (rd.Read())
//                 {
//                     System.Console.WriteLine($"ProdCode: {rd[0]}\t ProdName: {rd[1]}\t Price: {rd[2]}\t DOE: {rd[3]}\t Category: {rd[4]}");
//                 }

//             }
//             catch (Exception ex)
//             {
//                 System.Console.WriteLine(ex.Message);
//             }
//             finally
//             {
//                 con.Close();
//                 System.Console.WriteLine("Database Connection is closed...");
//             }
//         }
//     }
// }