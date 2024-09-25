using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dtos.Product
{
    public class UpdateProductDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(100, ErrorMessage = "Title cannot be over 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ProduceDate { get; set; }

        [Required]
        [Phone]
        public string ManufacturePhone { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string ManufactureEmail { get; set; } = string.Empty;

        [Required]
        [Range(typeof(bool), "false", "true")]        
        public bool IsAvailable { get; set; }
    }
}
