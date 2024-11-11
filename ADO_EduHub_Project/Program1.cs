// using System.Data;
// using System.Reflection.Metadata;
// using System.Runtime.InteropServices;

// namespace ADO_EduHub_Project
// {
//     internal class Program1
//     {
//         static void Main(string[] args)
//         {
//             UserRepository repo = new UserRepository();
//             User user;

//             int ID;
//             int result;
//             DataSet ds = new DataSet();
//             int entry;
//             bool Continue = true;
//             char reply;

//             System.Console.WriteLine("..................................................");

//             while (Continue)
//             {
//                 System.Console.WriteLine("Press 0: To exit\nPress 1: For All Teachers\nPress 2: For All Students\nPress 3: To add new user\nPress 4: To update user\nPress 5: To Delete user");

//                 entry = Convert.ToInt32(Console.ReadLine());

//                 switch (entry)
//                 {
//                     case 0:
//                         Environment.Exit(0);
//                         break;

//                     case 1:
//                         System.Console.WriteLine("Show all Teachers");
//                         ds = repo.GetAllTeachers();
//                         foreach (DataRow row in ds.Tables[0].Rows)
//                         {
//                             System.Console.WriteLine($"Id :{row["userId"]} Teacher name : {row["username"]}");
//                         }
//                         break;

//                     case 2:
//                         System.Console.WriteLine("Showing all students");
//                         ds = repo.GetAllStudents();
//                         foreach (DataRow row in ds.Tables[0].Rows)
//                         {
//                             System.Console.WriteLine($"Id :{row["userId"]} Student name : {row["username"]}");
//                         }
//                         break;

//                     case 3:
                        // System.Console.WriteLine("------------------ Enter User Details --------------");
                        // user = new User();

                        // System.Console.WriteLine("Enter UserName");
                        // string username = Console.ReadLine();
                        // bool res = repo.UserExists(username);

                        // if(res){
                        //     System.Console.WriteLine("UserName already exists");
                        //     break;
                        // }
                        // else{
                        //     user.UserName = username;

                        //     System.Console.WriteLine("Enter Email");
                        //     user.Email = Console.ReadLine();

                        //     System.Console.WriteLine("Enter Password");
                        //     user.Password = Console.ReadLine();

                        //     System.Console.WriteLine("Enter MobileNumber");
                        //     user.MobileNumber = Console.ReadLine();

                        //     System.Console.WriteLine("Enter UserRole");
                        //     user.UserRole = Console.ReadLine();

                        //     System.Console.WriteLine("Enter ProfileImage");
                        //     user.ProfileImage = Console.ReadLine();

                        //     int RowsAffected = repo.AddUser(user);

                        //     if (RowsAffected >0){
                        //         System.Console.WriteLine("User Added Successfully");
                        //     }
                        //     else{
                        //         System.Console.WriteLine("User cannot be added");
                        //     }
                        // }

//                         break;

//                     default:
//                         Console.WriteLine("Invalid Key");
//                         break;

//                 }

                // Console.WriteLine("Do you want to continue? Y/N");
                // reply = Convert.ToChar(Console.ReadLine());
                // if (reply == 'Y')
                //     Continue = true;
                // else if (reply == 'N')
                // {
                //     Environment.Exit(0);
                // }
//             }
//         }
//     }
// }