using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }

    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(200, ErrorMessage = "L'image ne peut pas dépasser 200 caractères")]
        public string Image { get; set; } = string.Empty;
    }
}

