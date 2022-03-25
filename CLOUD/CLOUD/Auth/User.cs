using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CLOUD.Auth
{
    public class User : Entity
    {
        [Required]
        [NotNull]
        public string Username { get; set; }
        
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }

    }
}
