// //See https://aka.ms/new-console-template for more information
// using System.Runtime.CompilerServices;
// using System.Data.SqlClient;
// using System.Runtime.Intrinsics.Arm;
// using System.Data;

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

//                 // To add New Employee
//                 System.Console.WriteLine("........... update Employee Id in Employees .......................");

//                 System.Console.WriteLine("Enter Employee Id whose ID is Updating ");
//                 int id = Convert.ToInt32(Console.ReadLine());
//                 System.Console.WriteLine("Enter deptid:");
//                 int deptid = Convert.ToInt32(Console.ReadLine());

//                 cmd.CommandText = "update employees set deptid=@deptid where empid = @id";
//                 con.Open();
//                 SqlParameter p1 = new SqlParameter("@id",SqlDbType.Int);
//                 SqlParameter p2 = new SqlParameter("@deptid",SqlDbType.Int);

//                 p1.Value = id;
//                 p2.Value = deptid;
                

//                 cmd.Parameters.Add(p1);
//                 cmd.Parameters.Add(p2);
                

//                 int rows = cmd.ExecuteNonQuery();

//                 if(rows>0){
//                     System.Console.WriteLine("Record added successfully");
//                 }
//                 else{
//                     System.Console.WriteLine("Error while adding record");
//                 }
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