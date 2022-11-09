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
     }
}
