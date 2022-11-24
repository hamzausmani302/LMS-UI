using LMS.DTOS.Users;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using LMS.Models;


namespace LMS.Services.ClassesService
{
    public class ClassService: IClassService
    {
        private HttpClient _httpClient;
        public virtual System.Net.CookieCollection Cookies { get; set; }
        public ClassService() { _httpClient = new HttpClient(); }
        public async Task<List<LMS.Models.Class>> GetClasses(string tokenvalue , bool isUser=true)
        {
            Console.WriteLine(tokenvalue);
            string url = GlobalInfo.getClassUrl;
            if (!isUser) {
                url = GlobalInfo.getClassTeacherUrl;
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",tokenvalue);
            var result = await _httpClient.GetFromJsonAsync<List<LMS.Models.Class>>(url);
            
            Console.WriteLine($"total classes = {result.Count}");
            return result;
        }
        public async Task<List<LMS.DTOS.Users.UserDTO>> GetUsers(string tokenvalue, int classId)
        {
            Console.WriteLine(tokenvalue+" #### "+ classId);
            string url;

            url = GlobalInfo.getClassEnrolledUsers.Replace("[id]", classId.ToString()); ;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenvalue);
            var result = await _httpClient.GetFromJsonAsync<List<LMS.DTOS.Users.UserDTO>>(url);
            Console.WriteLine($"total users = {result.Count}");
            return result;
           
        }
    }
}
