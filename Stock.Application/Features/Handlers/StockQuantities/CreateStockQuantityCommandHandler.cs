using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.StockQuantities;
using Stock.Application.Resources;
using Stock.Domain.Entities;

namespace Stock.Application.Features.Handlers.StockQuantities;

public class CreateStockQuantityCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateStockQuantityCommand, string>
{
    public async Task<string> Handle(CreateStockQuantityCommand command, CancellationToken cancellationToken)
    {
        // TODO: Calculate the Original Stock Quantity
        var stockQuantity = new StockQuantity(command);

        await unitOfWork.StockQuantities.AddAsync(stockQuantity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseMessages.Added;
    }
}