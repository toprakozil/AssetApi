using Domain.Common;

namespace Domain.User
{
    public class User : AuditableSoftDeletableEntity
    {
        public string UserName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; } = null!;
    }
}
