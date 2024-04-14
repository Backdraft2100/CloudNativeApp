namespace Basket.API.GetBasket;

// public record GetBasketRequest();
public record GetBasketResponse(ShoppingCart Cart);

public class GetBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(Constants.Routes.GetBasket, async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));

            var response = result.Adapt<GetBasketResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBasket")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get basket")
        .WithDescription("Get basket");
    }
}