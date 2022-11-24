namespace LMS.DTOS.FileDto
{
    public class AddFileDTO
    {

        public string title { get; set; }
        public string description { get; set; }
        public string announcementType { get; set; }

        public DateTime dueDate { get; set; }

        public List<IFormFile> fileToUpload { get; set; }

    }
}