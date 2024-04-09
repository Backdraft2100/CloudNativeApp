namespace Catalog.API.GetProductsByCategory;

// public record GetProductByCategoryRequest(string Category) : IQuery<GetProductByCategoryRequest>;

public record GetProductsByCategoryResponse(IEnumerable<Product> Products);

public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(Constants.Routes.GetProductsByCategory, async (string Category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCategoryQuery(Category));

            var response = result.Adapt<GetProductsByCategoryResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductByCategory")
        .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get product by category")
        .WithDescription("Get products by category");
    }
}
