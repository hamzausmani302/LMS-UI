using LMS.Models;

namespace LMS.Services.AssignmentsService
{
    public interface IAssignmentService
    {
        public Task<List<SubmissionFile>> getUserSubmissions(int announcementId, string token);
    }
}
