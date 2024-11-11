// using System.Data;
// using System.Data.SqlClient;

// namespace ADO_Connection_Demo
// {
//     internal class Program2
//     {
//         public static SqlDataAdapter da;
//         public static DataSet ds;
//         public static SqlConnection con;
//         public static SqlCommand cmd;
//         public static SqlDataReader rd;
//         public static DataTable dt1;
//         public static DataTable dt2;
//         public static SqlCommandBuilder cb;
//         static void Main(string[] args)
//         {
//             try
//             { 
//                 con = new SqlConnection("data source =YISC1101240LT\\SQLEXPRESS; initial catalog = DB1; integrated security = true; trustservercertificate = true");

//                 // Create dataAdapter object
//                 da = new SqlDataAdapter("select empid,fname,lname, salary from  employees",con);
//                 ds = new DataSet();

//                 // 
//                 da.Fill(ds);

//                 // Command builder needs a primary key in table
//                 cb = new SqlCommandBuilder();
//                 cb.DataAdapter = da;

//                 int id;
//                 System.Console.WriteLine("To update Employee: \n Enter Id");
//                 id = Convert.ToInt32(Console.ReadLine());

//                 foreach(DataRow row  in ds.Tables[0].Rows){
//                     if(Convert.ToInt32(row["empid"].ToString()) == id){
//                         ds.Tables[0].Rows.Remove(row);
//                         da.Update(ds.Tables[0]);
//                         System.Console.WriteLine("Record deleted successfully");
//                     }
//                     else{
//                         System.Console.WriteLine($"Record with id={id} not found");
//                         break;
//                     }
//                 }

//             }
//             catch (Exception ex)
//             {
//                 System.Console.WriteLine(ex.Message);
//             }
//             finally
//             {
//                 System.Console.WriteLine("Database Connection is closed...");
//             }
//         }
//     }
// }