using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LMS.Models
{
    public class SubmissionFile
    {
       

        public int Id { get; set; }

        public string FileName { get; set; }


        public string MimeType { get; set; }


        public string FilePath { get; set; }

        public int AnnouncementId { get; set; }

        public virtual Announcement Announcement { get; set; }          //Navigation reference

        public string? StudentId { get; set; }

  
        public virtual User User { get; set; }




    }
}
