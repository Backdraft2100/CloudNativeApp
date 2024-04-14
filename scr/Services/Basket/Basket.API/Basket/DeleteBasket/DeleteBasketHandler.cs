
namespace Basket.API.DeleteBasket;

public record DeleteBasketCommand(string userName) : ICommand<DeleteBasketResult>;
public record DeleteBasketResult(bool IsSuccess);

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.userName).NotEmpty().WithMessage("Username is required");
    }
}

public class DeleteBasketHandler
    (IBasketRepository repository)
    : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        //delete from DB
        await repository.DeleteBasket(command.userName);

        //session.delele
        return new DeleteBasketResult(true);
    }
}
