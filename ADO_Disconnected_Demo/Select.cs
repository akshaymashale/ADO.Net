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
//         static void Main(string[] args)
//         {
//             try
//             { 
//                 con = new SqlConnection("data source =YISC1101240LT\\SQLEXPRESS; initial catalog = DB1; integrated security = true; trustservercertificate = true");

//                 // Create dataAdapter object
//                 da = new SqlDataAdapter("select empid,fname,lname, salary from  employees; select prodid, prodcode, price from products",con);
//                 ds = new DataSet();

//                 da.Fill(ds);

//                 dt1 = new DataTable();
//                 dt1 = ds.Tables[0];

//                 foreach(DataRow dr in dt1.Rows){
//                     System.Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]}");
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