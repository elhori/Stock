using Microsoft.EntityFrameworkCore;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.StockQuantities;
using Stock.Domain;
using Stock.Domain.Contracts.ReceivingInvoices;
using Stock.Domain.Contracts.StockQuantities;
using Stock.Domain.Entities;

namespace Stock.Infrastructure.Persistence.Repositories;

public class StockQuantityRepository(AppDbContext context) : AsyncRepository<StockQuantity>(context), IStockQuantityRepository
{
    public async Task<PaginatedResult<StockQuantityDto>> GetStockQuantities(GetAllStockQuantitiesCommand command, CancellationToken cancellationToken = default)
    {
        var data = context.StockQuantities
            .Include(i => i.Item)
            .AsNoTracking();

        var total = await data.CountAsync(cancellationToken);

        var skip = command.PageSize * (command.CurrentPage - 1);

        if (!await data.Skip(skip).AnyAsync(cancellationToken: cancellationToken))
            return new PaginatedResult<StockQuantityDto>
            {
                CurrentPage = command.CurrentPage,
                PageSize = command.PageSize,
                TotalResults = 0,
                Results = []
            };

        var results = await data
            .Skip(skip)
            .Take(command.PageSize)
            .Select(i => i.ToModel())
            .ToListAsync(cancellationToken);

        return new PaginatedResult<StockQuantityDto>
        {
            CurrentPage = command.CurrentPage,
            PageSize = command.PageSize,
            TotalResults = total,
            Results = results
        };
    }
}