using System.Net.Http.Headers;
using System.Net.Http;
using LMS.Models;

namespace LMS.Services.AssignmentsService
{
    public class AssignmentService : IAssignmentService
    {

        private readonly HttpClient httpClient;

        public AssignmentService() { 
            httpClient = new HttpClient();
        }

        public async Task<List<SubmissionFile>> getUserSubmissions( int announcementId ,  string token) {


            string url = GlobalInfo.getAllSubmittedFilesInAssignment.Replace("[id]", announcementId.ToString());
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await  httpClient.GetFromJsonAsync<List<SubmissionFile>>(url);
            
            if (response == null) {
                return new List<SubmissionFile>();
            }

            return response;
        }
    }
}
