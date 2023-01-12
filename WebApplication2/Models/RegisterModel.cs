using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class RegisterModel
    {
        public string? Account { get; set; }
        public string? Password { get; set; }

        public string? newPassword { get; set; }

        public string? Name { get; set; }

        public int? Phone { get; set; }
    }
}
