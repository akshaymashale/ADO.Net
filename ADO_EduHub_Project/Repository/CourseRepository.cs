using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;

namespace ADO_EduHub_Project{
    internal class CourseRepository : ICourseRepository
    {
       public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static SqlDataReader dr;
        public static DataTable dt;

        public CourseRepository()
        {
            con = new SqlConnection("data source=YISC1101240LT\\SQLEXPRESS;initial catalog=EduHub;integrated security=true;TrustServerCertificate=true");
            System.Console.WriteLine("Connection successful");
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public int AddCourse(Course course)
        {
            cmd.Parameters.Clear();
                cmd.CommandText = "Insert into courses(title,description,coursestartdate,courseenddate,userid,category,level) values (@Title,@Description,@CourseStartDate,@CourseEndDate,@UserId,@Category,@Level)";

                cmd.Parameters.AddWithValue("@title", course.Title);
                cmd.Parameters.AddWithValue("@description", course.Description);
                cmd.Parameters.AddWithValue("@coursestartdate", course.CourseStartDate);
                cmd.Parameters.AddWithValue("@courseenddate", course.CourseEndDate);
                cmd.Parameters.AddWithValue("@userid", course.UserId);
                cmd.Parameters.AddWithValue("@category", course.Category);
                cmd.Parameters.AddWithValue("@level", course.Level);

                con.Open();

                // For insert update delete queries
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
        }

        public DataSet GetAllCourses()
        {
            string SqlQuery = "select courseid,title,description,userid,category,level from courses";
            da = new SqlDataAdapter(SqlQuery,con);
            ds = new DataSet();

            // cmd.CommandText = "select courseid,title,description,userid,category,level from courses";
            // da = new SqlDataAdapter();
            // da.SelectCommand = cmd;
            // ds = new DataSet();
            da.Fill(ds);
            return ds;
        }



        public Course GetCourseById(int id)
        {
            throw new NotImplementedException();
        }

        public DataSet GetCoursesByUser(int userid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select courseid,title,description,userid,category,level from courses where userid = @userid";
            cmd.Parameters.AddWithValue("@userid",userid);
            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            return ds;

        }

        public int UpdateCourse(Course course)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "Update courses set title=@Title, description=@Description, coursestartdate=@CourseStartDate, courseenddate=@CourseStartDate, Category=@Category, level=@Level where courseid=@CourseId";
            cmd.Parameters.AddWithValue("@Title", course.Title);
            cmd.Parameters.AddWithValue("@Description", course.Description);
            cmd.Parameters.AddWithValue("@CourseStartDate", course.CourseStartDate);
            cmd.Parameters.AddWithValue("@CourseEndDate", course.CourseEndDate);
            cmd.Parameters.AddWithValue("@Category", course.Category);
            cmd.Parameters.AddWithValue("@Level", course.Level);
            cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
            
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }
    }
}