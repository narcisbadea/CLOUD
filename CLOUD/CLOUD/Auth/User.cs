using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CLOUD.Auth
{
    public class User : Entity
    {
        [Required]
        [NotNull]
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
