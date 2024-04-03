using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQueryHandler<in TQuery, TRresponse>
    : IRequestHandler<TQuery, TRresponse>
    where TQuery : IQuery<TRresponse>
    where TRresponse : notnull
{ }
