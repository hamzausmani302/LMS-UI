using System.Net.Http.Headers;
using System.Net.Http;

namespace LMS.Helpers
{
    public class functionalUtils
    {
        public static string encodeString(string filename) {
            return System.Web.HttpUtility.UrlEncode(filename);
        }


        public static async Task<bool> AuthenticateActor(string token , string sessionType)
        {
         
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string url = sessionType == "teacher" ? GlobalInfo.validateTeacherUrl : GlobalInfo.validateStudentUrl;
                HttpResponseMessage response = await client.GetAsync(url);

                return response.IsSuccessStatusCode;
         
            


        }


    }
}
