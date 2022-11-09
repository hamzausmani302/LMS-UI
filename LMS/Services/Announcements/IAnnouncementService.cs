using LMS.DTOS.Announcements;
using LMS.Models;
namespace LMS.Services.Announcements
{
    public interface IAnnouncementService
    {
        public Task<List<AnnouncementResponse>> getAnnouncementsOfClass(int classId , string token ,string roleType);

    }
}
