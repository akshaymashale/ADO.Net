using System.Data;

namespace ADO_EduHub_Project{
    internal interface IFeedbackRepository{
        int AddFeedback(Feedback feedback);
        DataSet GetFeedbackByUserId(int userid);
        DataSet GetFeedbackByCourseID(int courseid);
    }
}