using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace ADO_EduHub_Project
{
    internal class UserRepository : IUserRepository
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static SqlDataReader dr;
        public static DataTable dt;
        public UserRepository()
        {
            con = new SqlConnection("data source=YISC1101240LT\\SQLEXPRESS;initial catalog=EduHub;integrated security=true;TrustServerCertificate=true");
            System.Console.WriteLine("Connection successful");
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public User LogIn(string? username, string password)
        {
            User loginuser = new User();

            cmd.Parameters.Clear();
            cmd.CommandText = "Select userid,username,password,email,mobilenumber,userrole from users where username = @UserName and password = @Password";
            cmd.Parameters.AddWithValue("@username",username);
            cmd.Parameters.AddWithValue("@Password",password);

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            dt = ds.Tables[0];
            if(dt.Rows.Count == 1){
                loginuser.UserId = (int)dt.Rows[0]["UserId"];
                loginuser.UserName = dt.Rows[0]["UserName"].ToString();
                loginuser.Password = dt.Rows[0]["Password"].ToString();
                loginuser.Email = dt.Rows[0]["Email"].ToString();
                loginuser.MobileNumber = dt.Rows[0]["MobileNumber"].ToString();

                // Assignment ==> apply switch cases for different roles and show menu for that particular role inside the switch case
                loginuser.UserRole = dt.Rows[0]["UserRole"].ToString();
                return loginuser;
            }
            else return loginuser;
        }
        public int AddUser(User newuser)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Insert into users(username,password,email,mobilenumber,userrole,profileimage) values (@username,@password,@email,@mobilenumber,@userrole,@profileimage)";

                cmd.Parameters.AddWithValue("@username", newuser.UserName);
                cmd.Parameters.AddWithValue("@password", newuser.Password);
                cmd.Parameters.AddWithValue("@email", newuser.Email);
                cmd.Parameters.AddWithValue("@mobilenumber", newuser.MobileNumber);
                cmd.Parameters.AddWithValue("@userrole", newuser.UserRole);
                cmd.Parameters.AddWithValue("@profileimage", newuser.ProfileImage);

                con.Open();

                // For insert update delete queries
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
            
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return 0;
            
        }

        public DataSet GetAllStudents()
        {
            string SqlQuery = "select userid,username,email,mobilenumber,userrole,profileimage from users where userrole = " + "'Student'";
            da = new SqlDataAdapter(SqlQuery,con);
            ds = new DataSet();
            da.Fill(ds);

            return ds;
        }

        public DataSet GetAllTeachers()
        {
            string SqlQuery = "select userid,username,email,mobilenumber,userrole,profileimage" + " from users where UserRole = " + "'Educator'";
            
            da = new SqlDataAdapter(SqlQuery,con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;   
        }

        public int GetNewUserId()
        {
            throw new NotImplementedException();
        }


        public int UpdateProfile(User user)
        {
            try{
                cmd.Parameters.Clear();
                cmd.CommandText = "update users set username = @username, Email = @email, mobilenumber = @mobilenumber, profileimage = @profileimage";
                cmd.Parameters.AddWithValue("@username",user.UserName);
                cmd.Parameters.AddWithValue("@email",user.Email);
                cmd.Parameters.AddWithValue("@mobilenumber",user.MobileNumber);
                cmd.Parameters.AddWithValue("@profileimage",user.ProfileImage);
                con.Open();

                // ExecuteNonQuery() ==> Used to execute SQL statements that return integer value representing the number of rows affected by the command
                int result = cmd.ExecuteNonQuery();

                return result;

            }
            catch(Exception ex){
                System.Console.WriteLine(ex.Message);
            }
            finally{
                con.Close();
            }

            return 0;
        }

        public bool UserExists(string username)
        {
            bool isData;
            cmd.Parameters.Clear();
            cmd.CommandText = "Select userid from users where username = @UserName";
            cmd.Parameters.AddWithValue("@UserName",username);
            con.Open();
            dr = cmd.ExecuteReader();
            isData = dr.Read();

            System.Console.WriteLine(isData);
            con.Close();

            if(isData){
                return true;
            }
            else{
                return false;
            }
        }
    }
}