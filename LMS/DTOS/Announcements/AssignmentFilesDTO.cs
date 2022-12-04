namespace LMS.DTOS.Announcements
{
    public class AssignmentFilesDTO
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public int AnnouncementId { get; set; }
        public string StudentId { get; set; }
    }
}
