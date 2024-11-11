using System.Data;
using System.Data.SqlClient;

namespace ADO_Connection_Demo
{
    internal class Program2
    {
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader rd;
        public static DataTable dt1;
        public static DataTable dt2;
        public static SqlCommandBuilder cb;
        static void Main(string[] args)
        {
            try
            { 
                con = new SqlConnection("data source =YISC1101240LT\\SQLEXPRESS; initial catalog = DB1; integrated security = true; trustservercertificate = true");

                // Create dataAdapter object
                da = new SqlDataAdapter("select empid,fname,lname, salary from  employees",con);
                ds = new DataSet();

                da.Fill(ds);

                dt1 = new DataTable();
                dt1 = ds.Tables[0];

                // Command builder needs a primary key in table
                cb = new SqlCommandBuilder();
                cb.DataAdapter = da;

                string fname,lname;
                decimal salary;

                System.Console.WriteLine("To update Employee: \n Enter firstname");
                fname = Console.ReadLine();

                System.Console.WriteLine("To update Employee: \n Enter last name");
                lname = Console.ReadLine();

                System.Console.WriteLine("To update Employee: \n Enter Salary");
                salary = Convert.ToDecimal(Console.ReadLine());

                DataRow row = dt1.NewRow();
                
                row["fname"]=fname;
                row["lname"]=lname;
                row["salary"]=salary;
                        
                dt1.Rows.Add(row);
                da.Update(dt1);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                System.Console.WriteLine("Database Connection is closed...");
            }
        }
    }
}