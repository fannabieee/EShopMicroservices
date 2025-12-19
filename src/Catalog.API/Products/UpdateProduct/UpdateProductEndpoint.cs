
namespace Catalog.API.Products.UpdateProduct
{
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products",
                async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductRequest>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateProductResult>();
                return Results.Ok(response);
            })
            .WithName("UpdateProduct")
            .Produces<UpdateProductResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("UpdateProduct")
            .WithDescription("Updates an existing product in the catalog.");
        }
    }
}
