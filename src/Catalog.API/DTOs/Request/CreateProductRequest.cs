namespace Catalog.API.DTOs.Request
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
}
