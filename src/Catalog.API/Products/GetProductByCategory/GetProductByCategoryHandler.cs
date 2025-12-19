
namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryRequest(string Category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    public class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryHandler> logger) : IQueryHandler<GetProductByCategoryRequest, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryRequest query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetProductByCategoryHandler with {@Query}", query);

            var result = await session.Query<Product>()
                .Where(x => x.Category.Contains(query.Category))
                .ToListAsync();

            return new GetProductByCategoryResult(result);
        }
    }
}
