using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ADO_EduHub_Project{
    internal class FeedbackRepository : IFeedbackRepository
    {
        public static SqlDataAdapter da;
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static DataSet ds;

        public FeedbackRepository(){
            con = new SqlConnection("data source=YISC1101240LT\\SQLEXPRESS;initial catalog=EduHub;integrated security=true;TrustServerCertificate=true");
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public int AddFeedback(Feedback feedback)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "Insert into Feedback(userid,courseid,feedmessage,date) values(@UserId,@CourseId,@FeedMessage,@Date)";
            cmd.Parameters.AddWithValue("@userid",feedback.UserId);
            cmd.Parameters.AddWithValue("@courseid",feedback.CourseId);
            cmd.Parameters.AddWithValue("@feedmessage",feedback.FeedMessage);
            cmd.Parameters.AddWithValue("@date",DateTime.Now);
    
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }

        public DataSet GetFeedbackByCourseID(int courseid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select feedbackid,userid,courseid,feedmessage,date from feedback where courseid = @courseid";
            cmd.Parameters.AddWithValue("@courseid",courseid);
            da = new SqlDataAdapter();
            ds = new DataSet();

            da.SelectCommand = cmd;
            da.Fill(ds);

            return ds;
        }

        public DataSet GetFeedbackByUserId(int userid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select feedbackid,userid,feedmessage,date from feedback where userid = @userid ";
            cmd.Parameters.AddWithValue("@userid",userid);
            da = new SqlDataAdapter();
            ds = new DataSet();

            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
            
        }
    }
}