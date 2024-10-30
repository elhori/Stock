using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.Items;
using Stock.Application.Resources;

namespace Stock.Application.Features.Handlers.Items;

public class UpdateItemCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateItemCommand, string>
{
    public async Task<string> Handle(UpdateItemCommand command, CancellationToken cancellationToken)
    {
        var item = await unitOfWork.Items.FindAsync(command.Id, includeRelated: false, cancellationToken);

        if (item == null!)
            return ResponseMessages.NotFound;

        item.Update(command);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseMessages.Updated;
    }
}