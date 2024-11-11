using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace ADO_EduHub_Project{
    internal class EnrollmentRepository : IEnrollmentRepository
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;
        public static SqlDataReader dr;
        public static DataSet ds;
        public static DataTable dt;

        public EnrollmentRepository(){
            con = new SqlConnection("data source=YISC1101240LT\\SQLEXPRESS;initial catalog=EduHub;integrated security=true;TrustServerCertificate=true");
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

         public DataSet ShowAvailaibleCourses()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "Select courseid,title,coursestartdate,courseenddate from courses";
            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }

        public DataSet EnrolledCourses(int userid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "Select courseid,status,title,userid,enrollmentid,enrollmentdate from enrollment where userid = @userid";
            cmd.Parameters.AddWithValue("@userid",userid);
            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }

        public int EnrollInNewCourse(Enrollment enroll)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into Enrollment(userid,courseid,title,enrollmentdate,status) values(@userid,@courseid,@title,@enrollmentdate,@status)";

            // cmd.Parameters.AddWithValue("@enrollmentid",enroll.EnrollmentId);
            cmd.Parameters.AddWithValue("@userid",enroll.UserId);
            cmd.Parameters.AddWithValue("@courseid",enroll.CourseId);
            cmd.Parameters.AddWithValue("@title",enroll.Title);
            cmd.Parameters.AddWithValue("@enrollmentdate",DateTime.Now);
            cmd.Parameters.AddWithValue("@status",enroll.Status);   

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }


        public DataSet StudentsInCourse(int courseid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "Select userid,title,status from enrollment where courseid=@courseid";
            cmd.Parameters.AddWithValue("@courseid",courseid);
            da = new SqlDataAdapter();
            ds = new DataSet();

            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }

        public int UnEnrollCourse(User user)
        {
            throw new NotImplementedException();
        }
    }
}