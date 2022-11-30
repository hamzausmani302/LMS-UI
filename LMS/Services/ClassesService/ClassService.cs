using LMS.DTOS.Users;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using LMS.Models;
using LMS.DTOS.ClassesDTO;
using Newtonsoft.Json;

namespace LMS.Services.ClassesService
{
    public class ClassService: IClassService
    {
        private HttpClient _httpClient;
        public virtual System.Net.CookieCollection Cookies { get; set; }
        public ClassService() { _httpClient = new HttpClient(); }


        public async Task<HttpResponseMessage> AddUserToClassUtils(string code, string token) {
            string url = GlobalInfo.enrollClassUrl.Replace("[id]", code);
            Console.WriteLine(url);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            return response;

        }
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

        public async Task<ClassDTO> AddClass(AddClassDTO dto , string token) {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(GlobalInfo.addClassUrl, dto);
            Console.WriteLine(response.StatusCode);

            if (!response.IsSuccessStatusCode) {
                return new ClassDTO();
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
            ClassDTO classDTO = JsonConvert.DeserializeObject<ClassDTO>(responseContent);
            return classDTO;



        }
     }
}
