using System.Text.RegularExpressions;

namespace ECommerceAPI.Services
{
    public class SlugService
    {
        public static string GenerateSlug(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // Convert to lowercase
            var slug = input.ToLowerInvariant();

            // Replace Swedish characters
            slug = slug.Replace("å", "a")
                      .Replace("ä", "a")
                      .Replace("ö", "o")
                      .Replace("Å", "a")
                      .Replace("Ä", "a")
                      .Replace("Ö", "o");

            // Remove all non-alphanumeric characters except spaces and hyphens
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");

            // Replace spaces with hyphens
            slug = slug.Replace(" ", "-");

            // Remove multiple consecutive hyphens
            slug = Regex.Replace(slug, @"-+", "-");

            // Remove leading and trailing hyphens
            slug = slug.Trim('-');

            return slug;
        }
    }
}

