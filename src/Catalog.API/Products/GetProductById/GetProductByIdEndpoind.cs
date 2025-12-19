namespace Catalog.API.Products.GetProductById
{
    public class GetProductByIdEndpoind : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (ISender sender, Guid id) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Product is not null
                    ? result.Product.Adapt<Product>()
                    : null;
                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<Product>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("GetProductById")
            .WithDescription("Get a product by its Id in catalog");
        }
    }
}
