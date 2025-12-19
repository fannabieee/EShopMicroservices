

namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductRequest(Guid Id) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);
    public class DeleteProductHandler(IDocumentSession session, ILogger<DeleteProductHandler> logger) : ICommandHandler<DeleteProductRequest, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling DeleteProductRequest with {@Request}", request);

            var product = await session.LoadAsync<Product>(request.Id);
            if (product == null)
            {
                logger.LogWarning("Product with Id {ProductId} not found.", request.Id);
                return new DeleteProductResult(false);
            }

            session.Delete(product);
            await session.SaveChangesAsync();
            return new DeleteProductResult(true);
        }
    }
}
