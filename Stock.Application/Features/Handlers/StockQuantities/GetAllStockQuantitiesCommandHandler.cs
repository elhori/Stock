using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.StockQuantities;
using Stock.Domain;
using Stock.Domain.Contracts.StockQuantities;

namespace Stock.Application.Features.Handlers.StockQuantities;

public class GetAllStockQuantitiesCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllStockQuantitiesCommand, PaginatedResult<StockQuantityDto>>
{
    public async Task<PaginatedResult<StockQuantityDto>> Handle(GetAllStockQuantitiesCommand command, CancellationToken cancellationToken)
        => await unitOfWork.StockQuantities.GetStockQuantities(command, cancellationToken);
}