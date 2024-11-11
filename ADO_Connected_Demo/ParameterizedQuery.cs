// // See https://aka.ms/new-console-template for more information
// using System.Runtime.CompilerServices;
// using System.Data.SqlClient;
// using System.Runtime.Intrinsics.Arm;

// namespace ADO_Connected_Demo{
     
//     internal class Program{

//         private static SqlConnection con;
//         private static SqlCommand cmd;
//         private static SqlDataReader rd;
//         static void Main(string[] args){
            

//             try{
//             con = new SqlConnection("data source=YISC1101240LT\\SQLEXPRESS;initial catalog=Db1;integrated security=true;TrustServerCertificate=true");

//             System.Console.WriteLine("Connection successful");

//             cmd = new SqlCommand();

//             // associate con with cmd
//             cmd.Connection = con;

//             cmd.CommandText = "select empid, fname, lname, salary from employees where empId = @id";
            
//             // parameterized query
//             SqlParameter p = new SqlParameter("@id",System.Data.SqlDbType.Int);
//             int id;
//             System.Console.WriteLine("Please enter id");
//             id = Convert.ToInt32(Console.ReadLine());
//             p.Value = id;
//             cmd.Parameters.Add(p);

//             // cmd.commandType = CommandType.Text;
//             // select query is execute calling ExecuteReader() method

//             con.Open();
            
//             rd = cmd.ExecuteReader();
//             while(rd.Read()){
//                 System.Console.WriteLine($"empId: {rd[0]}\t First name: {rd[1]}\t Last name: {rd[2]}\t salary: {rd[3]}");
//             }  
//             }
//             catch(SqlException ex){
//                 System.Console.WriteLine(ex.Message);
//             }     
//             finally{
//                 con.Close();

//             } 

//         }
//     }
// }