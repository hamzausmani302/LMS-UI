using LMS.DTOS.Announcements;
using LMS.Models;
using System.Net.Http.Headers;

namespace LMS.Services.Announcements { 
    public class AnnouncementService : IAnnouncementService
    {
        private readonly HttpClient httpClient;
        private readonly HttpContext httpContext;
        public AnnouncementService() {
            httpClient = new HttpClient();
            
        }
        public async Task<List<AnnouncementResponse>> getAnnouncementsOfClass(int classId , string token , string roleType)
        {

            string url = roleType != "teacher" ? GlobalInfo.getAnnouncementUrl : GlobalInfo.getAnnouncementTeacherUrl;
            url = url.Replace("[id]", classId.ToString());
            httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", token);
            List<AnnouncementResponse> response = await httpClient.GetFromJsonAsync<List<AnnouncementResponse>>(url);

            Console.WriteLine($"c = infor-1 = {response.Count}");
            if (response == null)
            {
                return new List<AnnouncementResponse>();
            }

            return response;
/*            return new List<Announcement>();
*/
            
        }
    }

}
