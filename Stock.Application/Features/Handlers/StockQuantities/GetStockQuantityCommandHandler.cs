using MediatR;
using Microsoft.EntityFrameworkCore;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.StockQuantities;
using Stock.Domain.Contracts.StockQuantities;

namespace Stock.Application.Features.Handlers.StockQuantities;

public class GetStockQuantityCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetStockQuantityByIdCommand, StockQuantityDto>
{
    public async Task<StockQuantityDto> Handle(GetStockQuantityByIdCommand command, CancellationToken cancellationToken)
    {
        var stockQuantity = await unitOfWork.StockQuantities.FindAsync(
            command.Id,
            q => q.Include(i => i.Item), 
            cancellationToken);

        if (stockQuantity == null!)
            return new StockQuantityDto(0, decimal.Zero, decimal.Zero, string.Empty, 0, string.Empty);

        return stockQuantity.ToModel();
    }
}