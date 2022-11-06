using LMS.Models;
namespace LMS.Services.Announcements
{
    public interface IAnnouncementService
    {
        public Task<List<Announcement>> getAnnouncementsOfClass(int classId , string token);

    }
}
