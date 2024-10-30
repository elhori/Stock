using Microsoft.EntityFrameworkCore;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.Items;
using Stock.Domain;
using Stock.Domain.Contracts.Items;
using Stock.Domain.Entities;

namespace Stock.Infrastructure.Persistence.Repositories;

public class ItemRepository(AppDbContext context) : AsyncRepository<Item>(context), IItemRepository
{
    public async Task<PaginatedResult<ItemDto>> GetItems(GetAllItemsCommand command, CancellationToken cancellationToken = default)
    {
        var data = context.Items.AsNoTracking();

        if (!string.IsNullOrEmpty(command.SearchQuery))
            data = data.Where(i => i.ItemName.Trim().ToUpper() == command.SearchQuery.Trim().ToUpper());

        var total = await data.CountAsync(cancellationToken);

        var skip = command.PageSize * (command.CurrentPage - 1);

        if (!await data.Skip(skip).AnyAsync(cancellationToken: cancellationToken))
            return new PaginatedResult<ItemDto>
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

        return new PaginatedResult<ItemDto>
        {
            CurrentPage = command.CurrentPage,
            PageSize = command.PageSize,
            TotalResults = total,
            Results = results
        };
    }
}