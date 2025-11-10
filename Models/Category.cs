using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string Image { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string Slug { get; set; } = string.Empty;
        
        // Navigation properties
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}

