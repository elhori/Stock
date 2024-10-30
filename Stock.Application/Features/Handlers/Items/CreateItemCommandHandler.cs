using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.Items;
using Stock.Application.Resources;
using Stock.Domain.Entities;

namespace Stock.Application.Features.Handlers.Items;

public class CreateItemCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateItemCommand, string>
{
    public async Task<string> Handle(CreateItemCommand command, CancellationToken cancellationToken)
    {
        if (await unitOfWork.Items.AnyAsync(i => i.ItemName == command.ItemName, cancellationToken))
            return ResponseMessages.AlreadyExists;

        var item = new Item(command);

        await unitOfWork.Items.AddAsync(item, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseMessages.Added;
    }
}