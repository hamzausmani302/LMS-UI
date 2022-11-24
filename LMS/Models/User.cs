using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LMS.Models
{
   
    public  class User
    {
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }

       
       
        [JsonIgnore]
        public string? PasswordHash { get; set; }

        public int Batch { get; set; }

       /* public virtual List<Classes> Classes { get; set; }

        public virtual List<SubmissionFile> SubmissionFiles { get; set; }*/
        //public  List<UserCourse> UserCourse { get; set; }
        
    }
}
