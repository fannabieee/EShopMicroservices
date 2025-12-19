namespace Catalog.API.Products.DeleteProduct
{
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}",
                async (Guid id, ISender sender) =>
            {
                var command = new DeleteProductRequest(id);
                var result = await sender.Send(command);
                var response = result.Adapt<DeleteProductResult>();
                return Results.Ok(response);
            })
            .WithName("DeleteProduct")
            .Produces<DeleteProductResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("DeleteProduct")
            .WithDescription("Deletes a product from the catalog.");
        }
    }
}
