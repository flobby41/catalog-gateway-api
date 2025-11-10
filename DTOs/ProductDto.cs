using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public string UrlSlug { get; set; } = string.Empty;
    }

    public class CreateProductDto
    {
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
        public string Description { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le prix est requis")]
        [Range(0, double.MaxValue, ErrorMessage = "Le prix doit être positif")]
        public decimal Price { get; set; }
        
        [StringLength(200, ErrorMessage = "L'image ne peut pas dépasser 200 caractères")]
        public string Image { get; set; } = string.Empty;
        
        public List<int> Categories { get; set; } = new List<int>();
    }
}

