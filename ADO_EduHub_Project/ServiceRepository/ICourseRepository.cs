using System.Data;

namespace ADO_EduHub_Project{
    internal interface ICourseRepository{
        // Select * from courses
        DataSet GetAllCourses();

        // Select * from courses where coursedid = @id
        Course GetCourseById(int id);

        // Select * from courses where userid = @id
        DataSet GetCoursesByUser(int userid);

        // insert into courses
        int AddCourse(Course course);
        int UpdateCourse(Course course);

    }
}