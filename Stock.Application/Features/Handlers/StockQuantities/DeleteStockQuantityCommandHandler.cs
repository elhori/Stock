using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.StockQuantities;
using Stock.Application.Resources;

namespace Stock.Application.Features.Handlers.StockQuantities;

public class DeleteStockQuantityCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteStockQuantityCommand, string>
{
    public async Task<string> Handle(DeleteStockQuantityCommand command, CancellationToken cancellationToken)
    {
        var stockQuantity = await unitOfWork.StockQuantities.FindAsync(command.Id, false, cancellationToken);

        if (stockQuantity == null!)
            return ResponseMessages.NotFound;

        await unitOfWork.StockQuantities.DeleteAsync(stockQuantity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseMessages.Deleted;
    }
}