
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsSuccess);
    public class UpdateProductHandler(IDocumentSession session, ILogger<UpdateProductHandler> logger) : ICommandHandler<UpdateProductRequest, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductRequest query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if (product == null)
            {
                logger.LogWarning("Product with Id {ProductId} not found.", query.Id);
                return new UpdateProductResult(false);
            }

            product.Name = query.Name;
            product.Category = query.Category;
            product.Description = query.Description;
            product.ImageFile = query.ImageFile;
            product.Price = query.Price;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }
    }
}
