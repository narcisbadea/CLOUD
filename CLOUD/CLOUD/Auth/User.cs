using System.ComponentModel.DataAnnotations;
using DotnetExample;

namespace JwtWebApiTutorial
{
    public class User : Entity
    {
        [Required]
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
