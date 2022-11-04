

using LMS.Models;
namespace LMS.DTOS.Users
{
    public class AuthenticateResponse
    {
        public string? id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? role { get; set; }
        public string? token { get; set; }

      
    }
}
