using Stock.Application.Features.Commands.StockQuantities;
using Stock.Domain;
using Stock.Domain.Contracts.StockQuantities;
using Stock.Domain.Entities;

namespace Stock.Application.Contracts.Repositories;

public interface IStockQuantityRepository : IAsyncRepository<StockQuantity>
{
    Task<PaginatedResult<StockQuantityDto>> GetStockQuantities(GetAllStockQuantitiesCommand command, CancellationToken cancellationToken = default);
}