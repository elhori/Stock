using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.StockQuantities;
using Stock.Application.Resources;

namespace Stock.Application.Features.Handlers.StockQuantities;

public class UpdateStockQuantityCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateStockQuantityCommand, string>
{
    public async Task<string> Handle(UpdateStockQuantityCommand command, CancellationToken cancellationToken)
    {
        var stockQuantity = await unitOfWork.StockQuantities.FindAsync(command.Id, false, cancellationToken);

        if (stockQuantity == null!)
            return ResponseMessages.NotFound;

        stockQuantity.Update(command);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseMessages.Updated;
    }
}