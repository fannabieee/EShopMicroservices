namespace Catalog.API.Products.GetProductByCategory
{
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (ISender sender, string category) =>
            {
                var result = await sender.Send(new GetProductByCategoryRequest(category));
                var response = result.Adapt<GetProductByCategoryReponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductByCategory")
            .Produces<Product>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("GetProductById")
            .WithDescription("Get a product by its category in catalog");
        }
    }
}
