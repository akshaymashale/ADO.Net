using System.Data;
using System.Data.SqlClient;

namespace ADO_EduHub_Project{
    internal class MaterialRepository : IMaterialRepository
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;
        public static DataSet ds;

        public MaterialRepository(){
            con = new SqlConnection("data source=YISC1101240LT\\SQLEXPRESS;initial catalog=EduHub;integrated security=true;TrustServerCertificate=true");
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public DataSet GetCourseMaterialById(int courseid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "Select materialid,title,description,URL,uploaddate,contenttype from material where courseid=@courseid";
            cmd.Parameters.AddWithValue("@courseid",courseid);
            da = new SqlDataAdapter();
            ds = new DataSet();

            da.SelectCommand = cmd;
            da.Fill(ds);

            return ds;
        }

        public int AddCourseMaterialById(Material material)
        {   
            cmd.Parameters.Clear();
            cmd.CommandText = "Insert into Material(courseid,title,description,URL,uploaddate,contenttype) values(@CourseId,@Title,@Description,@URL,@UploadDate,@ContentType)";
            cmd.Parameters.AddWithValue("@courseid",material.CourseId);
            cmd.Parameters.AddWithValue("@title",material.Title);
            cmd.Parameters.AddWithValue("@description",material.Description);
            cmd.Parameters.AddWithValue("@URL",material.URL);
            cmd.Parameters.AddWithValue("@uploaddate",DateTime.Now);
            cmd.Parameters.AddWithValue("@contenttype",material.ContentType);

            // da = new SqlDataAdapter();
            // ds = new DataSet();
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateMaterial(Material material)
        {
            throw new NotImplementedException();
        }
    }
}