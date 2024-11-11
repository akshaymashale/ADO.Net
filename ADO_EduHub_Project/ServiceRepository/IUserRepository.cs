using System.Data;

namespace ADO_EduHub_Project{
    internal interface IUserRepository{
        DataSet GetAllTeachers();
        DataSet GetAllStudents();

        int UpdateProfile(User user);
        // User GetUserById (int id);
        bool UserExists(string username);
        int AddUser(User newuser);
        int GetNewUserId();
        User LogIn(string username, string password);
    }
}