using System.ComponentModel.DataAnnotations;

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
        [Range(typeof(bool), "true", "true", ErrorMessage = "The field Is Available must be checked.")]
        public bool? IsAvailable { get; set; }
    }
}
