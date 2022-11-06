

namespace LMS.Models
{

    public enum AnnouncementType { 
        ASSIGNMENT,
        ANNOUNCEMENT
    }

    
    public class Announcement
    {
       
        public int AnnouncementId { get; set; }
     
        public int ClassesId { get; set; }
        //public virtual Classes Classes { get; set; }        //Navigation attributes

       
        public string? Description { get; set; }
      
        public string? Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public AnnouncementType announcementType { get; set; }

        public DateTime DueDate { get; set; }

        public virtual List<AnnouncementFile>? AnnouncementFiles { get; set; } //Navigation attributes

        public virtual List<SubmissionFile>? SubmissionFiles { get; set; }  //navigation attributes







    }
}
