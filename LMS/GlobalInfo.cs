using NuGet.Common;

namespace LMS
{
    public class GlobalInfo
    {
        public static string apiUrl = "https://localhost:7064";
        public static string liveUrl = "https://ipt-lms-1.herokuapp.com";
        public static string azureUrl = "https://learningmanagementsystem-ipt.azurewebsites.net";

        public static string urlToConsume = azureUrl;
        public static string userLoginUrl = $"{urlToConsume}/api/user/Users/Login";
        public static string teacherLoginUrl = $"{urlToConsume}/api/teacher/Teacher/Login";

        //Couese
        public static string getCoursesUrl = $"{urlToConsume}/api/Course/all";


        public static string getAnnouncementUrl = $"{urlToConsume}/api/user/Users/annoucements/class/[id]";
        public static string getAnnouncementTeacherUrl = $"{urlToConsume}/api/teacher/Teacher/annoucements/class/[id]";
    public static string addAnnouncementUrl = $"{urlToConsume}/api/teacher/Teacher/upload/web/class/[id]";


        //class
        public static string getClassUrl = $"{urlToConsume}/api/user/Users/classes";
        public static string getClassTeacherUrl = $"{urlToConsume}/api/teacher/Teacher/classes";
        public static string addClassUrl = $"{urlToConsume}/api/teacher/Teacher/class/add";
        public static string enrollClassUrl = $"{urlToConsume}/api/user/Users/add/class/web/[id]";

   
        public static string addSubmissionFileUrl = $"{urlToConsume}/api/user/Users/upload/web/assignment/[id]";

        public static string getSubmissionFileUrl = $"{urlToConsume}/api/user/Users/assignments/[id]";

        public static string getClassEnrolledUsers= $"{urlToConsume}/api/teacher/Teacher/class/students/[id]";


        

        public static string getAllSubmittedFilesInAssignment = $"{urlToConsume}/api/teacher/Teacher/assignments/[id]";     //announcementId




        public static string getSubmissionFileDownloadUrlTeacher = $"{urlToConsume}/api/teacher/Teacher/submissions/Files/[id]?AuthToken=[token]";            //download submission for teacher
        public static string getAnnouncementsFileDownloadUrl = $"{urlToConsume}/api/teacher/Teacher/announcements/Files/[id]?AuthToken=[token]";

        public static string getSubmissionFileDownloadUrlUser = $"{urlToConsume}/api/user/Users/submissions/Files/[id]?AuthToken=[token]";            //download submission for teacher
        public static string getAnnouncementsFileDownloadUrlUser = $"{urlToConsume}/api/user/Users/announcements/Files/[id]?AuthToken=[token]";


        //validation endpoints
        public static string validateStudentUrl = $"{urlToConsume}/api/user/Users/Authenticate";
        public static string validateTeacherUrl = $"{urlToConsume}/api/teacher/Teacher/Authenticate";

    }
}
