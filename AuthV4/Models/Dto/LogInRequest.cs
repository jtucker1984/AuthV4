using System.ComponentModel.DataAnnotations;

namespace AuthV4.Models.Dto
{
    public class LogInRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
