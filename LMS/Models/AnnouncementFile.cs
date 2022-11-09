using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LMS.Models
{
    public class AnnouncementFile
    {

        public int Id { get; set; } 

        public string FileName { get; set; }


        public string MimeType { get; set; }
   

        public string FilePath { get; set; }

        
        public int AnnouncementId { get; set; }
        [JsonIgnore]
        public virtual Announcement Announcement { get; set; }          //Navigation reference



    }
}
