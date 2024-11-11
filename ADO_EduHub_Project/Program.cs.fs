using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace ADO_EduHub_Project
{
    internal class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static DataSet ds;
        public static SqlDataAdapter da;
        static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository();

            bool Continue = true;
            while (Continue)
            {
                System.Console.WriteLine("Press 1: For Registration\nPress 2: For Log In");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        System.Console.WriteLine("--------------------- User Registration ---------------------");
                        User user = new User();
                        System.Console.WriteLine("---- Enter User Details -----");

                        UserRepository userRepo = new UserRepository();
                        System.Console.WriteLine("Enter UserName");
                        string username = Console.ReadLine();
                        bool res = userRepo.UserExists(username);

                        if (res)
                        {
                            System.Console.WriteLine("UserName already exists");
                            break;
                        }
                        else
                        {
                            user.UserName = username;

                            System.Console.WriteLine("Enter Email");
                            user.Email = Console.ReadLine();

                            System.Console.WriteLine("Enter Password");
                            user.Password = Console.ReadLine();

                            System.Console.WriteLine("Enter MobileNumber");
                            user.MobileNumber = Console.ReadLine();

                            System.Console.WriteLine("Enter UserRole");
                            user.UserRole = Console.ReadLine();

                            System.Console.WriteLine("Enter ProfileImage");
                            user.ProfileImage = Console.ReadLine();

                            int RowsAffected = userRepo.AddUser(user);

                            if (RowsAffected > 0)
                            {
                                System.Console.WriteLine("User Added Successfully");
                            }
                            else
                            {
                                System.Console.WriteLine("User cannot be added");
                            }
                        }
                        break;
                    case 2:
                        System.Console.WriteLine("------------------------------ USER LOGIN --------------------------------");
                        System.Console.Write("Enter Username: ");
                        username = Console.ReadLine();

                        System.Console.Write("Enter Password: ");
                        string password = Console.ReadLine();

                        user = userRepository.LogIn(username, password);

                        string role = string.Empty;

                        if (user != null)
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine($"{user.UserName}-{user.Password}-{user.Email}-{user.UserId}-{user.UserRole}");
                            role = user.UserRole;
                            if (role == "Educator")
                            {
                                EducatorDashboard(user);
                            }
                            else if (role == "Student")
                            {
                                StudentDashBoard(user);
                            }
                            else
                            {
                                System.Console.WriteLine("User Role Does not exist");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("User Does not exist");
                        }
                        break;
                }
                Console.WriteLine("Do you want to continue? Y/N");
                char reply = Convert.ToChar(Console.ReadLine());
                if (reply == 'Y')
                    Continue = true;
                else if (reply == 'N')
                {
                    Environment.Exit(0);
                }
            }

        }


        public static void EducatorDashboard(User user)
        {

            CourseRepository courseobj = new CourseRepository();
            EnrollmentRepository enrollment = new EnrollmentRepository();
            bool Continue = true;

            while (Continue)
            {
                System.Console.WriteLine("Press 1: Show All courses");
                System.Console.WriteLine("Press 2: Show Educators Courses");
                System.Console.WriteLine("Press 3: Add new course");
                System.Console.WriteLine("Press 4: Add course Material");
                System.Console.WriteLine("Press 5: Get course Material");
                System.Console.WriteLine("Press 6: Update Course");
                System.Console.WriteLine("Press 7: See Enrolled Students");
                System.Console.WriteLine("Press 8: See Enquiries related to courses");
                System.Console.WriteLine("Press 9: See Feedback List");
                System.Console.WriteLine();
                System.Console.WriteLine("Enter Menu");
                int menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        System.Console.WriteLine("Show all courses");
                        DataSet ds = new DataSet();
                        ds = courseobj.GetAllCourses();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"Id :{row["courseid"]} Teacher name : {row["title"]}");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("No Courses");
                        }

                        break;

                    case 2:
                        System.Console.WriteLine("---------------- Educators Courses --------------");
                        ds = courseobj.GetCoursesByUser(user.UserId);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"CourseId: {row["CourseId"]} Title: {row["Title"]} - Category: {row["Category"]} - Level: {row["Level"]}");
                            }
                        }

                        break;

                    case 3:
                        System.Console.WriteLine("------------------ Enter New Course Details --------------");
                        Course course = new Course();

                        System.Console.WriteLine("Enter Title");
                        string coursename = Console.ReadLine();
                        course.Title = coursename;

                        System.Console.WriteLine("Enter Course Description");
                        string description = Console.ReadLine();
                        course.Description = description;


                        System.Console.WriteLine("Enter Course Start Date");
                        DateTime coursestartdate = Convert.ToDateTime(Console.ReadLine());
                        course.CourseStartDate = coursestartdate;


                        System.Console.WriteLine("Enter Course End Date");
                        DateTime courseenddate = Convert.ToDateTime(Console.ReadLine());
                        course.CourseEndDate = courseenddate;

                        System.Console.WriteLine("Enter UserId");
                        int userid = Convert.ToInt32(Console.ReadLine());
                        course.UserId = userid;

                        System.Console.WriteLine("Enter Category");
                        string category = Console.ReadLine();
                        course.Category = category;

                        System.Console.WriteLine("Enter Level");
                        string level = Console.ReadLine();
                        course.Level = level;

                        int RowsAffected = courseobj.AddCourse(course);

                        if (RowsAffected > 0)
                        {
                            System.Console.WriteLine("Course Added Successfully");
                        }
                        else
                        {
                            System.Console.WriteLine("Course cannot be added");
                        }
                        break;

                    case 4:
                        System.Console.WriteLine("---------------- Educators Courses --------------");
                        ds = courseobj.GetCoursesByUser(user.UserId);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"CourseId: {row["CourseId"]} Title: {row["Title"]} - Category: {row["Category"]} - Level: {row["Level"]}");
                            }
                        }
                        System.Console.WriteLine();
                        System.Console.WriteLine("--------------- Add Course Material ------------------");
                        Material material = new Material();
                        MaterialRepository mat = new MaterialRepository();

                        System.Console.WriteLine("Enter Courseid in which material is to be added");
                        int courseid = Convert.ToInt32(Console.ReadLine());

                        material.CourseId = courseid;

                        System.Console.WriteLine("Enter Material Title");
                        material.Title = Console.ReadLine();

                        System.Console.WriteLine("Enter Material Description");
                        material.Description = Console.ReadLine();

                        System.Console.WriteLine("Upload URL");
                        material.URL = Console.ReadLine();

                        System.Console.WriteLine("Enter Content Type");
                        material.ContentType = Console.ReadLine();


                        RowsAffected = mat.AddCourseMaterialById(material);
                        if (RowsAffected > 0)
                        {
                            System.Console.WriteLine("Material Added Successfully.......");
                        }
                        else
                        {
                            System.Console.WriteLine("Error adding material");
                        }
                        break;

                    case 5:
                        System.Console.WriteLine("----------------- Educators Courses -----------------");
                        ds = new DataSet();
                        userid = user.UserId;
                        ds = enrollment.EnrolledCourses(userid);

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            System.Console.WriteLine("Sorry! No courses availaible");
                        }
                        else
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"{row["EnrollmentId"]} - {row["UserId"]} - {row["CourseId"]} - {row["Title"]} - {row["Status"]}");
                            }
                        }

                        System.Console.WriteLine("--------------------- Get Course Material ------------------------");
                        MaterialRepository matrepo = new MaterialRepository();

                        ds = new DataSet();
                        System.Console.WriteLine("Enter courseid: ");
                        courseid = Convert.ToInt32(Console.ReadLine());
                        ds = matrepo.GetCourseMaterialById(courseid);

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            System.Console.WriteLine("Sorry! No material  availaible");
                        }
                        else
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"{row["Title"]} - {row["URL"]} - {row["ContentType"]}");
                            }
                        }
                        break;
                    case 6:
                        System.Console.WriteLine("---------------- Educators Courses --------------");
                        ds = courseobj.GetCoursesByUser(user.UserId);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"CourseId: {row["CourseId"]} Title: {row["Title"]} - Category: {row["Category"]} - Level: {row["Level"]}");
                            }
                        }

                        Course course1 = new Course();
                        CourseRepository courseRepo = new CourseRepository();
                        System.Console.WriteLine();
                        System.Console.WriteLine("---------------------- Update Course ----------------------\n");
                        System.Console.WriteLine("Enter courseid to update...");
                        courseid = Convert.ToInt32(Console.ReadLine());

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            if ((int)row["CourseId"] == courseid)
                            {
                                course1.CourseId = courseid;
                                System.Console.WriteLine("Enter Title");
                                course1.Title = Console.ReadLine();

                                System.Console.WriteLine("Enter Description");
                                course1.Description = Console.ReadLine();

                                System.Console.WriteLine("Enter Course Start Date");
                                course1.CourseStartDate = Convert.ToDateTime(Console.ReadLine());

                                System.Console.WriteLine("Enter Course End Date");
                                course1.CourseEndDate = Convert.ToDateTime(Console.ReadLine());

                                System.Console.WriteLine("Enter Category");
                                course1.Category = Console.ReadLine();

                                System.Console.WriteLine("Enter Level");
                                course1.Level = Console.ReadLine();

                                RowsAffected = courseRepo.UpdateCourse(course1);

                                if (RowsAffected > 0)
                                {
                                    System.Console.WriteLine("Course Updated successfully...");
                                }
                                else
                                {
                                    System.Console.WriteLine("Error Updating Course");
                                }
                            }
                        }
                        break;
                    case 7:
                        System.Console.WriteLine("---------------------- Your Courses ----------------------");
                        ds = courseobj.GetCoursesByUser(user.UserId);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"CourseId: {row["CourseId"]} Title: {row["Title"]} - Category: {row["Category"]} - Level: {row["Level"]}");
                            }
                        }
                        System.Console.WriteLine();
                        System.Console.WriteLine("------ Students Enrolled in your course --------------");

                        EnrollmentRepository en = new EnrollmentRepository();
                        System.Console.WriteLine("Enter courseid: ");
                        courseid = Convert.ToInt32(Console.ReadLine());

                        ds = en.StudentsInCourse(courseid);
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            System.Console.WriteLine($"{row["userid"]} - {row["title"]} - {row["status"]}");
                        }
                        break;

                    case 8:
                        System.Console.WriteLine("---------------- Your Courses --------------");
                        ds = courseobj.GetCoursesByUser(user.UserId);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"CourseId: {row["CourseId"]} Title: {row["Title"]} - Category: {row["Category"]} - Level: {row["Level"]}");
                            }
                        }
                        System.Console.WriteLine();
                        System.Console.WriteLine("--------------------- Enquiry List --------------");
                        EnquiryRepository enqRepo = new EnquiryRepository();
                        System.Console.WriteLine("Enter courseid: ");
                        courseid = Convert.ToInt32(Console.ReadLine());

                        ds = enqRepo.ViewEnquiryByCourseId(courseid);
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            System.Console.WriteLine($"{row["EnquiryId"]} - {row["UserId"]} - {row["Subject"]} - {row["Message"]} - {row["Status"]} - {row["Response"]}");
                        }
                        break;

                    case 9:
                        System.Console.WriteLine("---------------- Your Courses --------------");
                        ds = courseobj.GetCoursesByUser(user.UserId);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"CourseId: {row["CourseId"]} Title: {row["Title"]} - Category: {row["Category"]} - Level: {row["Level"]}");
                            }
                        }
                        System.Console.WriteLine();
                        System.Console.WriteLine("--------------------- Feedback List --------------");
                        FeedbackRepository feedbackrepo = new FeedbackRepository();
                        System.Console.WriteLine("Enter courseid: ");
                        courseid = Convert.ToInt32(Console.ReadLine());

                        ds = feedbackrepo.GetFeedbackByCourseID(courseid);
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            System.Console.WriteLine($"{row["FeedbackId"]} - {row["UserId"]} - {row["FeedMessage"]}");
                        }
                        break;

                    default:
                        System.Console.WriteLine("Invalid key");
                        break;
                }

                Console.WriteLine("Do you want to continue? Y/N");
                char reply = Convert.ToChar(Console.ReadLine());
                if (reply == 'Y')
                    Continue = true;
                else if (reply == 'N')
                {
                    Environment.Exit(0);
                }
            }
        }


        public static void StudentDashBoard(User user)
        {
            CourseRepository courseobj = new CourseRepository();
            EnrollmentRepository enrollment = new EnrollmentRepository();
            Course course = new Course();

            bool Continue = true;
            DataSet ds = new DataSet();

            while (Continue)
            {
                System.Console.WriteLine("Press 1: Show Availaible courses");
                System.Console.WriteLine("Press 2: Show My Enrolled Courses");
                System.Console.WriteLine("Press 3: Enroll in new course");
                System.Console.WriteLine("Press 4: Get Course Material");
                System.Console.WriteLine("Press 5: Give Feedback");
                System.Console.WriteLine("Press 6: Get Given Feedback");
                System.Console.WriteLine("Press 7: Enquiry Regarding Course");

                System.Console.WriteLine();
                System.Console.WriteLine("Enter Menu");
                int menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        System.Console.WriteLine("------------ Availaible Courses to Enroll ------------------------");
                        ds = new DataSet();
                        ds = enrollment.ShowAvailaibleCourses();
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            System.Console.WriteLine($"{row["courseid"]} - {row["title"]} - {row["coursestartdate"]} - {row["courseenddate"]}");
                        }
                        break;

                    case 2:
                        System.Console.WriteLine("----------------- Your Enrolled Courses ------------------------");

                        ds = new DataSet();
                        int userid = user.UserId;
                        ds = enrollment.EnrolledCourses(userid);

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            System.Console.WriteLine("Sorry! No courses availaible");
                        }
                        else
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"{row["EnrollmentId"]} - {row["UserId"]} - {row["CourseId"]} - {row["Title"]} - {row["Status"]}");
                            }
                        }
                        break;

                    case 3:
                        System.Console.WriteLine("------------ Availaible Courses to Enroll ------------------------");
                        ds = new DataSet();
                        ds = enrollment.ShowAvailaibleCourses();
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            System.Console.WriteLine($"{row["courseid"]} - {row["title"]} - {row["coursestartdate"]} - {row["courseenddate"]}");
                        }

                        System.Console.WriteLine("------------------ Start Enrolling in New Course ---------------------");

                        System.Console.WriteLine("Enter CourseId you want to enroll in");
                        int courseid = Convert.ToInt32(Console.ReadLine());

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            if ((int)row["courseid"] == courseid)
                            {
                                Enrollment enroll = new Enrollment();

                                enroll.UserId = user.UserId;
                                enroll.CourseId = courseid;
                                System.Console.WriteLine("Enter Enrollment Date");
                                enroll.EnrollmentDate = Convert.ToDateTime(Console.ReadLine());

                                System.Console.WriteLine("Enter Enrollment Status");
                                enroll.Status = Console.ReadLine();

                                // System.Console.WriteLine("Enter Title ");
                                enroll.Title = (string)row["Title"];
                                System.Console.WriteLine(row["Title"]);

                                int RowsAffected = enrollment.EnrollInNewCourse(enroll);

                                if (RowsAffected > 0)
                                {
                                    System.Console.WriteLine("Enrolled to course Successfully");
                                }
                                else
                                {
                                    System.Console.WriteLine("User cannot be Enrolled");
                                }
                            }

                        }
                        break;

                    case 4:
                        System.Console.WriteLine("----------------- Your Enrolled Courses -----------------");
                        ds = new DataSet();
                        userid = user.UserId;
                        ds = enrollment.EnrolledCourses(userid);

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            System.Console.WriteLine("Sorry! No courses availaible");
                        }
                        else
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"{row["EnrollmentId"]} - {row["UserId"]} - {row["CourseId"]} - {row["Title"]} - {row["Status"]}");
                            }
                        }

                        System.Console.WriteLine("--------------------- Get Course Material ------------------------");
                        MaterialRepository matrepo = new MaterialRepository();

                        ds = new DataSet();
                        System.Console.WriteLine("Enter courseid: ");
                        courseid = Convert.ToInt32(Console.ReadLine());
                        ds = matrepo.GetCourseMaterialById(courseid);

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            System.Console.WriteLine("Sorry! No material  availaible");
                        }
                        else
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"{row["Title"]} - {row["URL"]} - {row["ContentType"]}");
                            }
                        }
                        break;

                    case 5:
                        System.Console.WriteLine("----------------- Your Enrolled Courses -----------------");
                        ds = new DataSet();
                        userid = user.UserId;
                        ds = enrollment.EnrolledCourses(userid);

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            System.Console.WriteLine("Sorry! No courses availaible");
                        }
                        else
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"{row["EnrollmentId"]} - {row["UserId"]} - {row["CourseId"]} - {row["Title"]} - {row["Status"]}");
                            }
                        }

                        System.Console.WriteLine("---------------------------- Add Feedback --------------------------");
                        FeedbackRepository feedbackrepo = new FeedbackRepository();
                        Feedback feedback = new Feedback();

                        System.Console.WriteLine("Enter courseid");
                        courseid = Convert.ToInt32(Console.ReadLine());

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            if ((int)row["CourseId"] == courseid)
                            {
                                feedback.UserId = user.UserId;
                                feedback.CourseId = courseid;
                                System.Console.WriteLine("Enter Feedback Message");
                                feedback.FeedMessage = Console.ReadLine();

                                int RowsAffected = feedbackrepo.AddFeedback(feedback);
                                if (RowsAffected > 0)
                                {
                                    System.Console.WriteLine("Feedback Submitted....");
                                }
                                else
                                {
                                    System.Console.WriteLine("Unable to add feedback....");
                                }
                            }
                        }
                        break;

                    case 6:
                        System.Console.WriteLine("--------- View Feedback added by you --------------");
                        break;

                    case 7:
                        System.Console.WriteLine("----------------- Your Enrolled Courses -----------------");
                        ds = new DataSet();
                        userid = user.UserId;
                        ds = enrollment.EnrolledCourses(userid);

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            System.Console.WriteLine("Sorry! No courses availaible");
                        }
                        else
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                System.Console.WriteLine($"{row["EnrollmentId"]} - {row["UserId"]} - {row["CourseId"]} - {row["Title"]} - {row["Status"]}");
                            }
                        }

                        System.Console.WriteLine("---------------------------- Add Enquiry --------------------------");
                        EnquiryRepository enqRepo = new EnquiryRepository();
                        Enquiry enquiry = new Enquiry();

                        System.Console.WriteLine("Enter courseid");
                        courseid = Convert.ToInt32(Console.ReadLine());

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            if ((int)row["CourseId"] == courseid)
                            {
                                enquiry.UserId = user.UserId;
                                enquiry.CourseId = courseid;
                                System.Console.WriteLine("Enter Enquiry subject");
                                enquiry.Subject = Console.ReadLine();

                                System.Console.WriteLine("Enter Enquiry Message");
                                enquiry.Message = Console.ReadLine();

                                System.Console.WriteLine("Enter Enquiry Status");
                                enquiry.Status = Console.ReadLine();

                                System.Console.WriteLine("Enter Enquiry Response");
                                enquiry.Response = Console.ReadLine();

                                int RowsAffected = enqRepo.AddEnquiry(enquiry);
                                if (RowsAffected > 0)
                                {
                                    System.Console.WriteLine("Enquiry Submitted....");
                                }
                                else
                                {
                                    System.Console.WriteLine("Unable to add Enquiry....");
                                }
                            }
                        }

                        break;

                    default:
                        System.Console.WriteLine("Invalid Menu key");
                        break;
                }

                Console.WriteLine("Do you want to continue? Y/N");
                char reply = Convert.ToChar(Console.ReadLine());
                if (reply == 'Y' || reply == 'y')
                    Continue = true;
                else if (reply == 'N' || reply == 'n')
                {
                    Environment.Exit(0);
                }
                else
                {
                    System.Console.WriteLine("Invalid");
                }
            }
        }
    }
}