using LMS.Models;
using LMS.DTOS.ClassesDTO;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LMS.DTOS.Announcements
{
    public class AnnouncementResponse
    {
        public int AnnouncementId { get; set; }
        
        public int ClassesId { get; set; }
        public virtual ClassDTO Class { get; set; }

        
        public string? Description { get; set; }
       
        public string? Title { get; set; }

        public DateTime CreatedAt { get; set; }



        public DateTime DueDate { get; set; }

        public string announcementType { get; set; }
        public List<AnnouncementFile> announcementFiles { get; set; }

       /* public AnnouncementResponse(Announcement announcement) {
            AnnouncementId = announcement.AnnouncementId;
            ClassesId = announcement.ClassesId;
            Description = announcement.Description;
            Title = announcement.Title;
            CreatedAt = announcement.CreatedAt;
            DueDate = announcement.DueDate;
            announcementFiles = announcement?.AnnouncementFiles == null ? new List<AnnouncementFile>() : announcement?.AnnouncementFiles;
            announcementType = announcement.announcementType;
            Class = new ClassDTO(announcement.Classes);

            
        }*/
        public AnnouncementResponse() { }

    }
}
