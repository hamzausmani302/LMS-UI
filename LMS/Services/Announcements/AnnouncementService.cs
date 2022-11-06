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
        public async Task<List<Announcement>> getAnnouncementsOfClass(int classId , string token)
        {
            string url = GlobalInfo.getAnnouncementUrl;
            httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", token);
            List<Announcement> response = await httpClient.GetFromJsonAsync<List<Announcement>>(url);
            if (response == null) {
                return new List<Announcement>();
            }

            return response;


            
        }
    }

}
