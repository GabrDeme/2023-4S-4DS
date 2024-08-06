using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsTest.Domains
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string? Name { get; set; }

        [Column(TypeName = "DECIMAL")]
        [Required]
        public decimal Price { get; set; }

    }
}
