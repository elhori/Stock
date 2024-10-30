using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.Items;
using Stock.Domain;
using Stock.Domain.Contracts.Items;

namespace Stock.Application.Features.Handlers.Items;

public class GetAllItemsCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllItemsCommand, PaginatedResult<ItemDto>>
{
    public async Task<PaginatedResult<ItemDto>> Handle(GetAllItemsCommand command, CancellationToken cancellationToken)
        => await unitOfWork.Items.GetItems(command, cancellationToken: cancellationToken);
}