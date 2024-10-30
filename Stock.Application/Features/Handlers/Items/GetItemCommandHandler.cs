using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.Items;
using Stock.Domain.Contracts.Items;

namespace Stock.Application.Features.Handlers.Items;

public class GetItemCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetItemCommand, ItemDto>
{
    public async Task<ItemDto> Handle(GetItemCommand command, CancellationToken cancellationToken)
    {
        var item = await unitOfWork.Items.FindAsync(command.Id, includeRelated:false, cancellationToken: cancellationToken);

        if(item == null!)
            return new ItemDto(0, string.Empty, string.Empty, decimal.Zero);

        return item.ToModel();
    }
}