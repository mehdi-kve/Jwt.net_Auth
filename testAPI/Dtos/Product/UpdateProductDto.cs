using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testAPI.Dtos.Product
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
        [Range(typeof(bool), "false", "true")]        
        public bool IsAvailable { get; set; }
    }
}
