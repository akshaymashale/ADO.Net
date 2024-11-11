using System.Data;
using System.Runtime.InteropServices;

namespace ADO_EduHub_Project{
    internal interface IEnrollmentRepository{
        DataSet ShowAvailaibleCourses();
        int EnrollInNewCourse(Enrollment enroll);
        int UnEnrollCourse(User user);
        DataSet EnrolledCourses(int userid);
        DataSet StudentsInCourse(int courseid);
    }
}