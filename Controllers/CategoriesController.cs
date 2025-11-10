using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Data;
using ECommerceAPI.DTOs;
using ECommerceAPI.Models;
using ECommerceAPI.Services;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ECommerceContext _context;

        public CategoriesController(ECommerceContext context)
        {
            _context = context;
        }

        // GET: api/categories
        // GET: api/categories?slug={slug}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories([FromQuery] string? slug)
        {
            IQueryable<Category> query = _context.Categories
                .Include(c => c.ProductCategories)
                .ThenInclude(pc => pc.Product);

            if (!string.IsNullOrEmpty(slug))
            {
                query = query.Where(c => c.Slug == slug);
            }

            var categories = await query.ToListAsync();

            var categoryDtos = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image,
                Slug = c.Slug,
                Products = c.ProductCategories.Select(pc => new ProductDto
                {
                    Id = pc.Product.Id,
                    Name = pc.Product.Name,
                    Description = pc.Product.Description,
                    Price = pc.Product.Price,
                    Image = pc.Product.Image,
                    UrlSlug = pc.Product.UrlSlug
                }).ToList()
            }).ToList();

            return Ok(categoryDtos);
        }

        // GET: api/categories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _context.Categories
                .Include(c => c.ProductCategories)
                .ThenInclude(pc => pc.Product)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Image = category.Image,
                Slug = category.Slug,
                Products = category.ProductCategories.Select(pc => new ProductDto
                {
                    Id = pc.Product.Id,
                    Name = pc.Product.Name,
                    Description = pc.Product.Description,
                    Price = pc.Product.Price,
                    Image = pc.Product.Image,
                    UrlSlug = pc.Product.UrlSlug
                }).ToList()
            };

            return Ok(categoryDto);
        }

        // POST: api/categories
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new Category
            {
                Name = createCategoryDto.Name,
                Image = createCategoryDto.Image,
                Slug = SlugService.GenerateSlug(createCategoryDto.Name)
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Image = category.Image,
                Slug = category.Slug,
                Products = new List<ProductDto>()
            };

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, categoryDto);
        }

        // DELETE: api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            // Remove product categories first
            var productCategories = await _context.ProductCategories
                .Where(pc => pc.CategoryId == id)
                .ToListAsync();
            
            _context.ProductCategories.RemoveRange(productCategories);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

