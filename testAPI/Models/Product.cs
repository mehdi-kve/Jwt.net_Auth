using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testAPI.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ProduceDate { get; set; }
        [StringLength(50)]
        public string ManufacturePhone { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string ManufactureEmail { get; set; } = string.Empty;
        public bool? IsAvailable { get; set; }
    }
}
