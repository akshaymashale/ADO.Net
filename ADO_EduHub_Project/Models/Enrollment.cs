using System.Globalization;

namespace ADO_EduHub_Project{
    internal class Enrollment{
        public int EnrollmentId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
    }
}