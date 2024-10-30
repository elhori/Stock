using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.Items;
using Stock.Application.Resources;

namespace Stock.Application.Features.Handlers.Items;

public class DeleteItemCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteItemCommand, string>
{
    public async Task<string> Handle(DeleteItemCommand command, CancellationToken cancellationToken)
    {
        var item = await unitOfWork.Items.FindAsync(command.Id, includeRelated:false ,cancellationToken);

        if (item == null!)
            return ResponseMessages.NotFound;

        await unitOfWork.Items.DeleteAsync(item, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseMessages.Deleted;
    }
}