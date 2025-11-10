using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        
        [StringLength(200)]
        public string Image { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string UrlSlug { get; set; } = string.Empty;
        
        // Navigation properties
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}

