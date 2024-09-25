using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AuthV4.Models.Dto
{
    public class RegisterRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [JsonPropertyName("UserName")]
        public string? UserName { get; set; }
        [Required]
        [JsonPropertyName("Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [JsonPropertyName("Roles")]
        public string[]? Roles { get; set; }
    }
}
