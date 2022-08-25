using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirLines.Models
{
    public class User
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50),DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required,MaxLength(10),MinLength(10),DataType(DataType.PostalCode)]
        public string?  PanNumber { get; set; }
        [Required,MinLength(8),MaxLength(10),DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required, MinLength(8), MaxLength(10), DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? Status { get; set; }
        [Required]
        public int RoleId { get; set; }
        public User()
        {
            Status = "Pending";
        }
    }
}
